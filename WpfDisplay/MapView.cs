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

        ImageSource tileForest = BitmapFrame.Create(new Uri(@"pack://application:,,/Resources/foret.png"));
        ImageSource tileDesert = BitmapFrame.Create(new Uri(@"pack://application:,,/Resources/desert.png"));
        ImageSource tileMountain = BitmapFrame.Create(new Uri(@"pack://application:,,/Resources/montagne.png"));
        ImageSource tilePlain= BitmapFrame.Create(new Uri(@"pack://application:,,/Resources/plaine.png"));

        World world;

        public void init()
        {
            world = World.Instance;
        }

        public void processFrame()
        {
            drawMap();
            drawUnits();
        }

        private void drawMap()
        {
            //World.Instance.board.
        }

        private void drawUnits()
        {

        }

    }
}
