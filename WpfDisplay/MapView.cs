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
    class MapView : Canvas
    {
        private const float TILE_WIDTH = 79;
        private const float TILE_HEIGHT = 69;

        private Dictionary<Tile,   ImageSource> tileTable;
        private Dictionary<string, ImageSource> unitTable;
        ImageSource selectedTileImg;

        World world;

        public void init()
        {
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
                return new Point(pos.x * 79, pos.y * 52);
            else
                return new Point(pos.x * 79 + 40, pos.y * 52);
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
                    if(pos.x * pos.y > 25)
                        drawElement(selectedTileImg, pos, drawingContext);
                }
            }
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
                        Console.WriteLine("====== unit ======" + World.Instance.nbUnity);
                        unitType = unit.GetType().ToString();
                        unitTable.TryGetValue(unitType, out img);
                        drawElement(img, pos, drawingContext);
                        nbUnits = World.Instance.unitCount(pos);
                        drawText(nbUnits.ToString(), Brushes.Black, pos, drawingContext);
                    }
                }
            }
        }

    }
}
