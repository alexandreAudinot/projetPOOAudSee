using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfDisplay
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow INSTANCE;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void New_Game(object sender, RoutedEventArgs e)
        {
            ((Grid)FindName("Menu")).Visibility = System.Windows.Visibility.Hidden;
            ((Grid)FindName("ModeSelection")).Visibility = System.Windows.Visibility.Visible;
        }

        private void Load_Game(object sender, RoutedEventArgs e)
        {

        }

        private void ElfeSelectionP1(object sender, RoutedEventArgs e)
        {

        }

        private void OrcSelectionP1(object sender, RoutedEventArgs e)
        {

        }

        private void NainSelectionP1(object sender, RoutedEventArgs e)
        {

        }

        private void AleatoireSelectionP1(object sender, RoutedEventArgs e)
        {

        }

        private void test(object sender, RoutedEventArgs e)
        {
            //((Canvas)FindName("Map")).
        }
    }
}
