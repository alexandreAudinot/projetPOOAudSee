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
        private String mapSize;
        public static String scene;

        private List<UnitInfo> unitInfoList;

        public MainWindow()
        {
            InitializeComponent();

            Menu.Visibility = System.Windows.Visibility.Visible;
            ModeSelection.Visibility = System.Windows.Visibility.Hidden;
            GameScene.Visibility = System.Windows.Visibility.Hidden;
            scene = "Menu";

            unitInfoList = new List<UnitInfo>();
            unitInfoList.Add(unitInfo1);
            unitInfo1.mapView = mapView;
            unitInfoList.Add(unitInfo2);
            unitInfo2.mapView = mapView;
            unitInfoList.Add(unitInfo3);
            unitInfo3.mapView = mapView;
            unitInfoList.Add(unitInfo4);
            unitInfo4.mapView = mapView;
            unitInfoList.Add(unitInfo5);
            unitInfo5.mapView = mapView;
            unitInfoList.Add(unitInfo6);
            unitInfo6.mapView = mapView;
            unitInfoList.Add(unitInfo7);
            unitInfo7.mapView = mapView;
            unitInfoList.Add(unitInfo8);
            unitInfo8.mapView = mapView;
        }

        public UnitInfo getUnitInfo(int i)
        {
            return unitInfoList.ElementAt(i);
        }

        private void NewGame(object sender, RoutedEventArgs e)
        {
            Menu.Visibility = System.Windows.Visibility.Hidden;
            ModeSelection.Visibility = System.Windows.Visibility.Visible;
            typeP1 = "Elf";
            typeP2 = "Orc";
            mapSize = "Normal";
            descriptionMap.Text = "Normale :\nTaille : 14x14\nNombre de tours : 30\nNombre d'unités par joueur : 8";
            scene = "ModeSelection";
        }

        private void LoadGame(object sender, RoutedEventArgs e)
        {

        }


        //Race selection for player 1
        private void ElfeSelectionP1(object sender, RoutedEventArgs e)
        {
            typeP1 = "Elf";
            imgP1.Source = new BitmapImage(new Uri(@"pack://application:,,/Ressources/elfe.png"));
        }

        private void OrcSelectionP1(object sender, RoutedEventArgs e)
        {
            typeP1 = "Orc";
            imgP1.Source = new BitmapImage(new Uri(@"pack://application:,,/Ressources/orc.png"));
        }

        private void NainSelectionP1(object sender, RoutedEventArgs e)
        {
            typeP1 = "Dwarf";
            imgP1.Source = new BitmapImage(new Uri(@"pack://application:,,/Ressources/nain.png"));
        }

        private void AleatoireSelectionP1(object sender, RoutedEventArgs e)
        {
            Random rdm = new Random();
            int n = rdm.Next(0, 3);
            switch (n)
            {
                case 0:
                    typeP1 = "Elf";
                    imgP1.Source = new BitmapImage(new Uri(@"pack://application:,,/Ressources/elfe.png"));
                    break;
                case 1:
                    typeP1 = "Orc";
                    imgP1.Source = new BitmapImage(new Uri(@"pack://application:,,/Ressources/orc.png"));
                    break;
                case 2:
                    typeP1 = "Dwarf";
                    imgP1.Source = new BitmapImage(new Uri(@"pack://application:,,/Ressources/nain.png"));
                    break;
            }
        }

        //Race selection for player 2
        private void ElfeSelectionP2(object sender, RoutedEventArgs e)
        {
            typeP2 = "Elf";
            imgP2.Source = new BitmapImage(new Uri(@"pack://application:,,/Ressources/elfe.png"));
        }

        private void OrcSelectionP2(object sender, RoutedEventArgs e)
        {
            typeP2 = "Orc";
            imgP2.Source = new BitmapImage(new Uri(@"pack://application:,,/Ressources/orc.png"));
        }

        private void NainSelectionP2(object sender, RoutedEventArgs e)
        {
            typeP2 = "Dwarf";
            imgP2.Source = new BitmapImage(new Uri(@"pack://application:,,/Ressources/nain.png"));
        }

        private void AleatoireSelectionP2(object sender, RoutedEventArgs e)
        {
            Random rdm = new Random();
            int n = rdm.Next(0, 3);
            switch (n)
            {
                case 0:
                    typeP2 = "Elf";
                    imgP2.Source = new BitmapImage(new Uri(@"pack://application:,,/Ressources/elfe.png"));
                    break;
                case 1:
                    typeP2 = "Orc";
                    imgP2.Source = new BitmapImage(new Uri(@"pack://application:,,/Ressources/orc.png"));
                    break;
                case 2:
                    typeP2 = "Dwarf";
                    imgP2.Source = new BitmapImage(new Uri(@"pack://application:,,/Ressources/nain.png"));
                    break;
            }
        }


        private void DemoSelection(object sender, RoutedEventArgs e)
        {
            mapSize = "Demo";
            descriptionMap.Text = "Demo :\nTaille : 6x6\nNombre de tours : 5\nNombre d'unités par joueur : 4";
        }

        private void SmallSelection(object sender, RoutedEventArgs e)
        {
            mapSize = "Small";
            descriptionMap.Text = "Petite :\nTaille : 10x10\nNombre de tours : 20\nNombre d'unités par joueur : 6";
        }

        private void NormalSelection(object sender, RoutedEventArgs e)
        {
            mapSize = "Normal";
            descriptionMap.Text = "Normale :\nTaille : 14x14\nNombre de tours : 30\nNombre d'unités par joueur : 8";
        }


        private void ValidateMode(object sender, RoutedEventArgs e)
        {
            ModeSelection.Visibility = System.Windows.Visibility.Hidden;
            Monteur m;

            switch(mapSize)
            {
                case "Demo":
                    m = new MonteurDemo();
                    break;
                case "Small":
                    m = new MonteurSmall();
                    break;
                default:
                    m = new MonteurNormal();
                    break;
            }
            World.Instance.addPlayer(nameP1.Text, typeP1);
            World.Instance.addPlayer(nameP2.Text, typeP2);
            CreateGame.init();

            mapView.init(this);
            playerInfo1.setPlayer(World.Instance.players.ElementAt(0));
            playerInfo2.setPlayer(World.Instance.players.ElementAt(1));
            scene = "Game";
            GameScene.Visibility = System.Windows.Visibility.Visible;
            mapView.InvalidateVisual();
            updateInfos();
        }

        private void mapView_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            mapView.onLeftClick(e.GetPosition(mapView));
        }

        private void mapView_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            mapView.onRightClick(e.GetPosition(mapView));
        }

        public void updateInfos()
        {
            playerInfo1.updateInfos();
            playerInfo2.updateInfos();
            gameInfo.updateGameInfos();
            InvalidateVisual();
        }

        private void ButtonEndTurn(object sender, RoutedEventArgs e)
        {
            mapView.endTurn();
        }

        private void ButtonSave(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonQuit(object sender, RoutedEventArgs e)
        {
            GameScene.Visibility = System.Windows.Visibility.Hidden;
            Menu.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
