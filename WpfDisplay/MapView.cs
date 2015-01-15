using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using System.Windows.Input;

using ProjetPOO;

using System.Windows.Controls;


namespace WpfDisplay
{
    public class MapView : Canvas
    {
        private MainWindow mainWindow;
        private World world;

        private const float TILE_WIDTH = 79;
        private const float TILE_HEIGHT = 69;
        private const int NB_MAX_UNITS = 8;

        private const int TILE_DISTANCE_X = 52;
        private const int TILE_DISTANCE_Y = 79;
        private const int TILE_SHIFT = 40;

        private Dictionary<Tile,   ImageSource> tileTable;
        private Dictionary<string, ImageSource> unitTable;
        private ImageSource selectedTileImg;

        private Position selectedTile;
        private Unit selectedUnit;
        private List<Position> suggestedTiles;

        public void init(MainWindow mw)
        {
            mainWindow = mw;
            world = World.Instance;

            tileTable = new Dictionary<Tile,   ImageSource>();
            unitTable = new Dictionary<string, ImageSource>();

            tileTable.Add(Monteur.forestTile,    BitmapFrame.Create(new Uri(@"pack://application:,,/Ressources/foret.png")));
            tileTable.Add(Monteur.desertTile,    BitmapFrame.Create(new Uri(@"pack://application:,,/Ressources/desert.png")));
            tileTable.Add(Monteur.mountainTile,  BitmapFrame.Create(new Uri(@"pack://application:,,/Ressources/montagne.png")));
            tileTable.Add(Monteur.plainTile,     BitmapFrame.Create(new Uri(@"pack://application:,,/Ressources/plaine.png")));

            unitTable.Add("ProjetPOO.Elf",   BitmapFrame.Create(new Uri(@"pack://application:,,/Ressources/elfe.png")));
            unitTable.Add("ProjetPOO.Dwarf", BitmapFrame.Create(new Uri(@"pack://application:,,/Ressources/nain.png")));
            unitTable.Add("ProjetPOO.Orc",   BitmapFrame.Create(new Uri(@"pack://application:,,/Ressources/orc.png")));

            selectedTileImg = BitmapFrame.Create(new Uri(@"pack://application:,,/Ressources/selected.png"));
            selectedTile = null;
            selectedUnit = null;
            suggestedTiles = new List<Position>();
        }

        public ImageSource getImageFromType(string type)
        {
            ImageSource img;
            unitTable.TryGetValue(type, out img);
            return img;
        }

        public void setSelectedUnit(Unit unit)
        {
            selectedUnit = unit;
        }

        public void unselectAll()
        {
            selectedUnit = null;
            UnitInfo unitInfo;

            for (int i = 0; i < 8; i++)
            {
                unitInfo = mainWindow.getUnitInfo(i);
                unitInfo.unselect();
            }
            mainWindow.InvalidateVisual();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if(MainWindow.scene == "Game")
            {
                drawMap(drawingContext);
                drawUnits(drawingContext);
            }
        }

        private Point toPixels(Position pos)
        {
            if(pos.y % 2 == 0)
                return new Point(pos.x * TILE_DISTANCE_Y,              pos.y * TILE_DISTANCE_X);
            else
                return new Point(pos.x * TILE_DISTANCE_Y + TILE_SHIFT, pos.y * TILE_DISTANCE_X);
        }
        private Position toCoords(Point p)
        {
            /*int doubleY = (int)(p.Y / (TILE_HEIGHT / 2)) - 1; //coordinate y in half-tiles
            int roughX = (int)((p.X - (TILE_WIDTH / 2)) / (.75f * TILE_WIDTH)); //rough x value of the intersection near t, not 100% accurate
            //the 2 coords near the intersection
            int x1 = roughX;
            int x2 = roughX + 1;
            int y1 = (doubleY + 2) / 2 - 1; // the +2 and -1 are used to counteract the fact that negative values are rounded up and not down when cast to int (and -1 is the only negative value that matters)
            int y2 = (doubleY + 2) / 2 - 1; //same as above
            if ((doubleY + 2) % 2 != 0) //not between 2 tiles of the same line. +2 deals with negative values (-1 is the only one that matters)
            {
                if (roughX % 2 == 0) //between an upper-left tile and a lower-right tile
                    y2++;
                else //between a lower-left tile and an upper-right tile
                    y1++;
            }
            Position c1 = new Position(x1, y1);
            Position c2 = new Position(x2, y2);

            //determining which one is closest
            if (distanceSquared(p, toPixels(c1)) > distanceSquared(p, toPixels(c2)))
                return c2;
            else
                return c1;*/

            Position pos = new Position(0, 0);

            pos.x = (int)p.X;
            pos.y = (int)p.Y;

            return pos;
        }
        private double distanceSquared(Point p1, Point p2)
        {
            double dx = p1.X - p2.X;
            double dy = p1.Y - p2.Y;
            return dx * dx + dy * dy;
        }

        private void drawElement(ImageSource img, Position pos, DrawingContext dc)
        {
            Point realPos = toPixels(pos);
            dc.DrawImage(img, new Rect(realPos.X - TILE_WIDTH / 2, realPos.Y - TILE_HEIGHT / 2, TILE_WIDTH, TILE_HEIGHT));
        }
        private void drawText(string text, Brush brush, Position pos, DrawingContext dc)
        {
            Point realPos = toPixels(pos);
            FormattedText fText = new FormattedText(text,
                                                    new CultureInfo("fr-FR"),
                                                    FlowDirection.LeftToRight,
                                                    new Typeface(new FontFamily("Arial"),
                                                    FontStyles.Normal,
                                                    FontWeights.Normal,
                                                    new FontStretch()),
                                                    16D,
                                                    brush);
            dc.DrawText(fText, realPos);
        }

        private void drawMap(DrawingContext drawingContext)
        {
            int width = World.Instance.board.size;
            int height = World.Instance.board.size;

            Position pos;
            ImageSource img;
            Tile tile;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    pos = new Position(i, j);
                    tile = World.Instance.board.getTile(pos);
                    tileTable.TryGetValue(tile, out img);
                    drawElement(img, pos, drawingContext);
                }
            }
            if(selectedTile != null)
                drawElement(selectedTileImg, selectedTile, drawingContext);
        }

        private void drawUnits(DrawingContext drawingContext)
        {
            int width = World.Instance.board.size;
            int height = World.Instance.board.size;

            Position pos;
            ImageSource img;
            string unitType;
            Unit unit;
            int nbUnits;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    pos = new Position(i, j);
                    unit = World.Instance.getUnit(pos);
                    if (unit != null)
                    {
                        unitType = unit.GetType().ToString();
                        unitTable.TryGetValue(unitType, out img);
                        drawElement(img, pos, drawingContext);
                        nbUnits = World.Instance.unitCount(pos);
                        drawText(nbUnits.ToString(), Brushes.White, pos, drawingContext);
                    }
                }
            }
        }

        private void updateUnitInfos()
        {
            int nbUnits = World.Instance.unitCount(selectedTile);
            List<Unit> list = World.Instance.getUnitList(selectedTile);
            UnitInfo unitInfo;

            for (int i = 0; i < nbUnits; i++)
            {
                unitInfo = mainWindow.getUnitInfo(i);
                unitInfo.AssociatedUnit = list.ElementAt(i);
                unitInfo.Visibility = System.Windows.Visibility.Visible;
                if(i == 0)
                {
                    unitInfo.select();
                }
            }
            for (int i = nbUnits; i < NB_MAX_UNITS; i++)
            {
                mainWindow.getUnitInfo(i).Visibility = System.Windows.Visibility.Hidden;
            }
        }

        public void onLeftClick(Point p)
        {
            Position pos = toCoords(p);
            selectedTile = pos;

            unselectAll();
            updateUnitInfos();

            Console.WriteLine("====select (" + p.X + ";" + p.Y + ") " + pos.x + ";" + pos.y + " --> " + World.Instance.unitCount(pos));
            InvalidateVisual();
        }
        public void onRightClick(Point p)
        {
            Position pos = toCoords(p);

            moveUnit(pos);

            Console.WriteLine("====move " + pos.x + ";" + pos.y + " --> " + World.Instance.unitCount(pos));
            InvalidateVisual();
        }

        private void moveUnit(Position pos)
        {
            selectedUnit.move(pos);
            mainWindow.updateInfos();
        }

        public void endTurn()
        {
            world.endTurn();
            mainWindow.updateInfos();
        }
    }
}
