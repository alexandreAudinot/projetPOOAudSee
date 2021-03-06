﻿using System;
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

        private bool gameOver;

        private const int TILE_WIDTH  = 100;//79;
        private const int TILE_HEIGHT = 100;//69;

        private const int TILE_DISTANCE_X = TILE_WIDTH;//79;
        private const int TILE_DISTANCE_Y = TILE_HEIGHT * 3 / 4;//52;
        private const int TILE_SHIFT      = TILE_WIDTH/2;//40;

        private const int NB_MAX_UNITS = 8;

        private Dictionary<Tile,   ImageSource> tileTable;
        private Dictionary<string, ImageSource> unitTable;
        private ImageSource selectedTileImg;
        private ImageSource suggestedTileImg;

        private Position selectedTile;
        private Unit selectedUnit;
        private List<Position> suggestedTiles;

        public void init(MainWindow mw)
        {
            mainWindow = mw;
            world = World.Instance;

            gameOver = false;

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
            suggestedTileImg = BitmapFrame.Create(new Uri(@"pack://application:,,/Ressources/suggested.png"));
            suggestedTiles = new List<Position>();

            Width = world.board.size * TILE_DISTANCE_X + 50;
            Height = world.board.size * TILE_DISTANCE_Y + 25;
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
                return new Point(pos.x * TILE_DISTANCE_X + TILE_DISTANCE_X, pos.y * TILE_DISTANCE_Y + TILE_DISTANCE_Y / 2 + 12);
            else
                return new Point(pos.x * TILE_DISTANCE_X + TILE_DISTANCE_X - TILE_SHIFT, pos.y * TILE_DISTANCE_Y + TILE_DISTANCE_Y / 2 + 12);
        }
        private Position toCoords(Point p)
        {
            Position pos = new Position(0, 0);
            int x = (int)p.X % TILE_DISTANCE_X;
            int y = (int)p.Y % (TILE_DISTANCE_Y * 2);
            //Console.WriteLine("x;y = " + x + ";" + y);

            if (y < TILE_DISTANCE_Y * 2 / 3)
            {
                if (x < TILE_DISTANCE_X / 2)
                {
                    if (x - 2 * y < 0)
                    {
                        pos.y = (int)(p.Y / TILE_DISTANCE_Y); 
                        //Console.WriteLine("--1");
                        pos.x = (int)(p.X / TILE_DISTANCE_X) - 1;
                    }
                    else
                    {
                        pos.y = (int)(p.Y / TILE_DISTANCE_Y) - 1; 
                        //Console.WriteLine("--2");
                        pos.x = (int)(p.X / TILE_DISTANCE_X);
                    }
                }
                else
                {
                    if ((x-50) + 2 * y < 50)
                    {
                        pos.y = (int)(p.Y / TILE_DISTANCE_Y) - 1; 
                        //Console.WriteLine("--3");
                        pos.x = (int)(p.X / TILE_DISTANCE_X);
                    }
                    else
                    {
                        pos.y = (int)(p.Y / TILE_DISTANCE_Y); 
                        //Console.WriteLine("--4");
                        pos.x = (int)(p.X / TILE_DISTANCE_X);
                    }
                }
            }
            else if (y < TILE_DISTANCE_Y)
            {
                pos.y = (int)(p.Y / TILE_DISTANCE_Y);
                if (x < TILE_DISTANCE_X / 2)
                {
                    pos.x = (int)(p.X / TILE_DISTANCE_X) - 1; 
                    //Console.WriteLine("--5");
                }
                else
                {
                    pos.x = (int)(p.X / TILE_DISTANCE_X); 
                    //Console.WriteLine("--6");
                }
            }
            else if (y < TILE_DISTANCE_Y + TILE_DISTANCE_Y * 2 / 3)
            {
                if (x < TILE_DISTANCE_X / 2)
                {
                    if (x + 2 * (y - TILE_DISTANCE_Y) < 50)
                    {
                        pos.y = (int)(p.Y / TILE_DISTANCE_Y) - 1; 
                        //Console.WriteLine("--7");
                        pos.x = (int)(p.X / TILE_DISTANCE_X) - 1;
                    }
                    else
                    {
                        pos.y = (int)(p.Y / TILE_DISTANCE_Y); 
                        //Console.WriteLine("--8");
                        pos.x = (int)(p.X / TILE_DISTANCE_X);
                    }
                }
                else
                {
                    if ((x - 50) - 2 * (y - TILE_DISTANCE_Y) < 0)
                    {
                        pos.y = (int)(p.Y / TILE_DISTANCE_Y); 
                        //Console.WriteLine("--9");
                        pos.x = (int)(p.X / TILE_DISTANCE_X);
                    }
                    else
                    {
                        pos.y = (int)(p.Y / TILE_DISTANCE_Y) - 1; 
                        //Console.WriteLine("--10");
                        pos.x = (int)(p.X / TILE_DISTANCE_X);
                    }
                }
            }
            else
            {
                pos.y = (int)(p.Y / TILE_DISTANCE_Y); 
                //Console.WriteLine("--11/12");
                pos.x = (int)(p.X / TILE_DISTANCE_X);
            }

            if (pos.x < 0 || pos.x >= world.board.size || pos.y < 0 || pos.y >= world.board.size)
                return null;

            return pos;
        }
        /*private double distanceSquared(Point p1, Point p2)
        {
            double dx = p1.X - p2.X;
            double dy = p1.Y - p2.Y;
            return dx * dx + dy * dy;
        }*/

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
            if(selectedUnit != null)
            {
                //Sélection de l'algorithme de l'IA ici
                int algo = mainWindow.getAlgo();
                if (algo != 2)
                {
                    List<Position> l;
                    if(algo == 1)
                        l = selectedUnit.getMoveSuggestions();
                    else
                        l = selectedUnit.getMoveSuggestions2();

                    foreach (Position p in l)
                    {
                        drawElement(suggestedTileImg, p, drawingContext);
                        //Console.WriteLine("sugg - " + p.x + ";" + p.y);
                    }
                    InvalidateVisual();
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
                        unitType = unit.GetType().ToString();
                        unitTable.TryGetValue(unitType, out img);
                        drawElement(img, pos, drawingContext);
                        nbUnits = World.Instance.unitCount(pos);
                        drawText(nbUnits.ToString(), Brushes.White, pos, drawingContext);
                    }
                }
            }
        }

        public void updateUnitInfos()
        {
            int nbUnits = 0;
            if (selectedTile != null)
            {
                nbUnits = World.Instance.unitCount(selectedTile);
                List<Unit> list = World.Instance.getUnitList(selectedTile);
                UnitInfo unitInfo;

                for (int i = 0; i < nbUnits; i++)
                {
                    unitInfo = mainWindow.getUnitInfo(i);
                    unitInfo.AssociatedUnit = list.ElementAt(i);
                    unitInfo.Visibility = System.Windows.Visibility.Visible;
                    if (i == 0)
                    {
                        unselectAll();
                        unitInfo.select();
                    }
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

            if (pos != null)
            {
                selectedTile = pos;

                mainWindow.printError("");

                unselectAll();
                updateUnitInfos();

                InvalidateVisual();
            }
        }
        public void onRightClick(Point p)
        {
            mainWindow.printError("");

            Position pos = toCoords(p);
            if(pos != null)
                moveUnit(pos);
        }

        private void moveUnit(Position pos)
        {
            try
            {
                selectedUnit.move(pos);
            }
            catch(Exception e)
            {
                mainWindow.printError(e.Message);
            }
            mainWindow.updateInfos();
            InvalidateVisual();
        }

        public void endTurn()
        {
            if (gameOver)
            {
                return;
            }
            else
            {
                world.endTurn();
                if (world.stateGame)
                {
                    mainWindow.updateInfos();
                }
                else
                {
                    gameOver = true;
                    endGame();
                }
            }
        }

        private void endGame()
        {
            mainWindow.endGame();
        }

        public void MovementKeyPressed(Key key)
        {
            if (selectedUnit == null)
                return;

            int x = selectedUnit.position.x;
            int y = selectedUnit.position.y;

            switch (key)
            {
                case Key.NumPad7:
                    if (y % 2 == 0)
                        moveUnit(new Position(x,     y - 1));
                    else
                        moveUnit(new Position(x - 1, y - 1));
                    break;
                case Key.NumPad8:
                    if (y % 2 == 0)
                        moveUnit(new Position(x + 1, y - 1));
                    else
                        moveUnit(new Position(x,     y - 1));
                    break;
                case Key.NumPad4:
                    moveUnit(new Position(x - 1, y));
                    break;
                case Key.NumPad5:
                    moveUnit(new Position(x + 1, y));
                    break;
                case Key.NumPad1:
                    if (y % 2 == 0)
                        moveUnit(new Position(x,     y + 1));
                    else
                        moveUnit(new Position(x - 1, y + 1));
                    break;
                case Key.NumPad2:
                    if (y % 2 == 0)
                        moveUnit(new Position(x + 1, y + 1));
                    else
                        moveUnit(new Position(x,     y + 1));
                    break;
                default:
                    break;
            }
        }
    }
}
