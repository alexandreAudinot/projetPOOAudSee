using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private Dictionary<Tile, ImageSource> tileTable;

        World world;

        public void init()
        {
            world = World.Instance;

            tileTable = new Dictionary<Tile, ImageSource>();

            tileTable.Add(Monteur.forestTile, BitmapFrame.Create(new Uri(@"pack://application:,,/Ressources/foret.png")));
            tileTable.Add(Monteur.desertTile, BitmapFrame.Create(new Uri(@"pack://application:,,/Ressources/desert.png")));
            tileTable.Add(Monteur.mountainTile, BitmapFrame.Create(new Uri(@"pack://application:,,/Ressources/montagne.png")));
            tileTable.Add(Monteur.plainTile, BitmapFrame.Create(new Uri(@"pack://application:,,/Ressources/plaine.png")));
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            Console.WriteLine("====================frame");
            //if(MainWindow.scene == "Game")
            {
                //drawMap(drawingContext);
                //drawingContext.DrawImage(BitmapFrame.Create(new Uri(@"pack://application:,,/Ressources/foret.png")), new Rect(10, 10, 40, 40));
                drawUnits(drawingContext);
            }
        }

        private Tuple<float, float> toPixels(Position pos)
        {
            return new Tuple<float, float>(pos.x*10, pos.y*10);
        }

        private void DrawElement(ImageSource img, Position pos, DrawingContext dc)
        {
            Tuple<float, float> realPos = toPixels(pos);
            dc.DrawImage(img, new Rect(realPos.Item1 - TILE_WIDTH / 2, realPos.Item2 - TILE_HEIGHT / 2, TILE_WIDTH, TILE_HEIGHT));
        }

        private void drawMap(DrawingContext drawingContext)
        {
            int width = World.Instance.board.size;
            int height = World.Instance.board.size;

            Position pos;
            ImageSource img;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    pos = new Position(i, j);
                    Tile tile = World.Instance.board.getTile(pos);
                    tileTable.TryGetValue(tile, out img);
                    DrawElement(img, pos, drawingContext);
                }
            }
        }

        private void drawUnits(DrawingContext drawingContext)
        {

        }

    }
}
