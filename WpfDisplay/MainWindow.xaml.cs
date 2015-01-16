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
            Intro.Visibility = System.Windows.Visibility.Hidden;
            ModeSelection.Visibility = System.Windows.Visibility.Hidden;
            GameScene.Visibility = System.Windows.Visibility.Hidden;
            Epilogue.Visibility = System.Windows.Visibility.Hidden;
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

        private void goToMenu()
        {
            Intro.Visibility = System.Windows.Visibility.Hidden;
            ModeSelection.Visibility = System.Windows.Visibility.Hidden;
            GameScene.Visibility = System.Windows.Visibility.Hidden;
            Victoire.Visibility = System.Windows.Visibility.Hidden;
            Epilogue.Visibility = System.Windows.Visibility.Hidden;
            World.Clean();
            scene = "Menu";
            Menu.Visibility = System.Windows.Visibility.Visible;
        }

        private void NewGame(object sender, RoutedEventArgs e)
        {
            Menu.Visibility = System.Windows.Visibility.Hidden;
            Intro.Visibility = System.Windows.Visibility.Visible;
            typeP1 = "Elf";
            typeP2 = "Orc";
            mapSize = "Normal";
            descriptionMap.Text = "Normale :\nTaille : 14x14\nNombre de tours : 30\nNombre d'unités par joueur : 8";
            scene = "Intro";
        }

        private void LoadGame(object sender, RoutedEventArgs e)
        {
            SaveGame save = new SaveGame();

            try
            {
                save.loadOnDisk(load.Text + ".txt");
            }
            catch(Exception ex)
            {
                errorLoad.Text = ex.Message;
                return;
            }

            Menu.Visibility = System.Windows.Visibility.Hidden;
            
            initVisualElements();
        }

        private void SkipIntro(object sender, RoutedEventArgs e)
        {
            Intro.Visibility = System.Windows.Visibility.Hidden;
            scene = "ModeSelection";
            ModeSelection.Visibility = System.Windows.Visibility.Visible;
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
            if(typeP1 == typeP2)
            {
                errorMode.Text = "Les deux joueurs doivent avoir des types différents";
                return;
            }
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

            initVisualElements();
        }

        private void initVisualElements()
        {
            mapView.init(this);
            playerInfo1.setPlayer(World.Instance.players.ElementAt(0));
            playerInfo2.setPlayer(World.Instance.players.ElementAt(1));
            scene = "Game";
            errorLoad.Text = "";
            errorMode.Text = "";
            error.Text = "";
            mapView.InvalidateVisual();
            GameScene.Visibility = System.Windows.Visibility.Visible;
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
            unitInfo1.updateInfos();
            unitInfo2.updateInfos();
            unitInfo3.updateInfos();
            unitInfo4.updateInfos();
            unitInfo5.updateInfos();
            unitInfo6.updateInfos();
            unitInfo7.updateInfos();
            unitInfo8.updateInfos();
            mapView.updateUnitInfos();
            InvalidateVisual();
        }

        private void ButtonEndTurn(object sender, RoutedEventArgs e)
        {
            mapView.endTurn();
        }

        private void ButtonSave(object sender, RoutedEventArgs e)
        {
            SaveGame save = new SaveGame();
            String resul = save.saveOnDisk();
            Console.WriteLine("game saved : " + resul);
            error.Text = "game saved : " + resul;
        }

        private void ButtonQuit(object sender, RoutedEventArgs e)
        {
            goToMenu();
        }

        public void printError(string s)
        {
            error.Text = s;
        }

        private void QuitGame(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.Key)
            {
                case Key.Enter:
                    if (scene == "Game")
                    {
                        mapView.endTurn();
                    }
                    break;
                case Key.NumPad7:
                case Key.NumPad8:
                case Key.NumPad4:
                case Key.NumPad5:
                case Key.NumPad1:
                case Key.NumPad2:
                    if (scene == "Game")
                    {
                        mapView.MovementKeyPressed(e.Key);
                    }
                    break;
                default:
                    break;
            }
        }

        public void endGame()
        {
            GameScene.Visibility = System.Windows.Visibility.Hidden;
            scene = "Victoire";
            string gagnant = World.Instance.gagnant();
            if(gagnant == "Match nul")
                victory.Text = gagnant;
            else
                victory.Text = gagnant + " à remporté la victoire !";
            Victoire.Visibility = System.Windows.Visibility.Visible;
        }

        private void GoBackToMenu(object sender, RoutedEventArgs e)
        {
            goToMenu();
        }

        private void GoToEpilogue(object sender, RoutedEventArgs e)
        {
            Victoire.Visibility = System.Windows.Visibility.Hidden;
            scene = "Victoire";
            Epilogue.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
