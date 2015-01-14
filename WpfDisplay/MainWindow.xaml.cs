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

using ProjetPOO;

namespace WpfDisplay
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private String typeP1, typeP2;
        public static String scene;

        public MainWindow()
        {
            InitializeComponent();
            scene = "Menu";
        }

        private void NewGame(object sender, RoutedEventArgs e)
        {
            Menu.Visibility = System.Windows.Visibility.Hidden;
            ModeSelection.Visibility = System.Windows.Visibility.Visible;
            typeP1 = "Elf";
            typeP2 = "Elf";
            scene = "ModeSelection";
        }

        private void LoadGame(object sender, RoutedEventArgs e)
        {

        }

        private void ElfeSelectionP1(object sender, RoutedEventArgs e)
        {
            typeP1 = "Elf";
        }

        private void OrcSelectionP1(object sender, RoutedEventArgs e)
        {
            typeP1 = "Orc";
        }

        private void NainSelectionP1(object sender, RoutedEventArgs e)
        {
            typeP1 = "Dwarf";
        }

        private void AleatoireSelectionP1(object sender, RoutedEventArgs e)
        {
            Random rdm = new Random();
            int n = rdm.Next(0, 3);
            switch (n)
            {
                case 0:
                    typeP1 = "Elf";
                    break;
                case 1:
                    typeP1 = "Orc";
                    break;
                case 2:
                    typeP1 = "Dwarf";
                    break;
            }
        }

        private void test(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("====== button ======");
            mapView.InvalidateVisual();
        }

        private void ValidateMode(object sender, RoutedEventArgs e)
        {
            ModeSelection.Visibility = System.Windows.Visibility.Hidden;

            MonteurSmall m = new MonteurSmall();
            World.Instance.addPlayer("Joueur 1", typeP1);
            World.Instance.addPlayer("Joueur 2", typeP2);

            mapView.init();
            scene = "Game";
            GameScene.Visibility = System.Windows.Visibility.Visible;
            mapView.InvalidateVisual();
        }
    }
}
