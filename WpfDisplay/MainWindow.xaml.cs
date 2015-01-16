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

            this.WindowState = WindowState.Maximized;
            this.ResizeMode = ResizeMode.NoResize;
            goToMenu();

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

            initTexts();
        }

        private void initTexts()
        {
            textIntro1.Text = "Morgoth, un seigneur du mal très puissant, terrorisait la terre du milieu. Un alliance d'un nouveau genre fut forgée entre les elfes, les orques, et les nains pour tenter de l'arrêter. Après une bataille féroce, Morgoth fut défait devant la montagne du destin.\n\n" +
                "Afin d'empêcher une nouvelle guerre, les peuples choisirent d'équilibrer les forces sur la terre du milieu. Ainsi, avec l'aide bienveillante de Sauron, ils créent un certain nombre d'anneaux de pouvoir, qu'ils distribuent à parts égales aux elfes, orques et nains.\n\n" +
                "Ainsi, les grands peuples ne se querelleront plus car ils détiennent tous des pouvoirs équivalents.";
            textIntro2.Text = "Mais ce que les anciens ne savaient pas, c'est que le contrôle de la majorité des anneaux de pouvoir peut bouleverser la vie sur la terre du milieu. En effet, le fourbe Sarumane, sorcier humain et chef du conseil blanc, a dans le secret créé un enchantement magique. Au bout d'un temps imparti, le contrôle de la majorité des anneaux de contrôle vous permettra de retrouver l'anneau unique, capable de contrôler tous les autres anneaux, pour conquérir le monde.";

            textVictory.Text = "Vous avez retrouvé l'anneau magique et vous vous empressez de l'enfiler à votre doigt. Enfin ! Vous êtes devenu invincible et vous vous préparez à envahir le monde.\n\n" +
                "Alors Sauron apparut et utilisa l'anneau unique pour vous corrompre. Il vous a utilisé comme un serviteur pour collecter tous les anneaux de pouvoirs pour retrouver l'anneau unique. Maintenant, vous lui avez rendu son pouvoir initial. Vous êtes l'être le plus haït de la terre du milieu. Mais au moins, vous n'avez pas perdu !";
            textMatchNul.Text = "L'enchantement n'a pu départager le vainqueur, mais un serviteur de Saruman vous rapportera bien l'anneau.\n\n" +
                "Oh mais surprise ! Il a decidé de le séparer en 2 en utilisant la méthode Salomon. Vous perdez tous les deux vos pouvoirs.\n\n" + 
                "Vous avez gagné une moitié d'anneau, mais c'est toujours mieux que le Gollum qui lui, a tout perdu.";
        }

        public UnitInfo getUnitInfo(int i)
        {
            return unitInfoList.ElementAt(i);
        }

        private void goToMenu()
        {
            Intro1.Visibility = System.Windows.Visibility.Hidden;
            Intro2.Visibility = System.Windows.Visibility.Hidden;
            ModeSelection.Visibility = System.Windows.Visibility.Hidden;
            GameScene.Visibility = System.Windows.Visibility.Hidden;
            Victoire.Visibility = System.Windows.Visibility.Hidden;
            Tie.Visibility = System.Windows.Visibility.Hidden;
            World.Clean();
            scene = "Menu";
            Menu.Visibility = System.Windows.Visibility.Visible;
        }

        private void NewGame(object sender, RoutedEventArgs e)
        {
            Menu.Visibility = System.Windows.Visibility.Hidden;
            Intro1.Visibility = System.Windows.Visibility.Visible;
            typeP1 = "Elf";
            typeP2 = "Orc";
            mapSize = "Normal";
            descriptionMap.Text = "Normale :\nTaille : 14x14\nNombre de tours : 30\nNombre d'unités par joueur : 8";
            scene = "Intro1";
        }

        private void LoadGame(object sender, RoutedEventArgs e)
        {
            SaveManager save = new SaveManager();

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

        private void GoToIntro2(object sender, RoutedEventArgs e)
        {
            Intro1.Visibility = System.Windows.Visibility.Hidden;
            scene = "Intro2";
            Intro2.Visibility = System.Windows.Visibility.Visible;
        }

        private void SkipIntro(object sender, RoutedEventArgs e)
        {
            Intro2.Visibility = System.Windows.Visibility.Hidden;
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
            descriptionMap.Text = "Comté :\nTaille : 6x6\nNombre de tours : 5\nNombre d'unités par joueur : 4";
        }

        private void SmallSelection(object sender, RoutedEventArgs e)
        {
            mapSize = "Small";
            descriptionMap.Text = "Erebor :\nTaille : 10x10\nNombre de tours : 20\nNombre d'unités par joueur : 6";
        }

        private void NormalSelection(object sender, RoutedEventArgs e)
        {
            mapSize = "Normal";
            descriptionMap.Text = "Terre du milieu :\nTaille : 14x14\nNombre de tours : 30\nNombre d'unités par joueur : 8";
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
            m.initForXaml();

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
            SaveManager save = new SaveManager();
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

        public void setActivePlayer(int player)
        {
            if (player == 0)
            {
                playerInfo1.BorderThickness = new Thickness(5);
                playerInfo2.BorderThickness = new Thickness(0);
                playerInfo1.Height += 10;
                playerInfo2.Height -= 10;
            }
            else
            {
                playerInfo1.BorderThickness = new Thickness(0);
                playerInfo2.BorderThickness = new Thickness(5);
                playerInfo1.Height -= 10;
                playerInfo2.Height += 10;
            }
        }

        public void endGame()
        {
            GameScene.Visibility = System.Windows.Visibility.Hidden;
            string gagnant = World.Instance.gagnant();
            if(gagnant == "Match nul")
            {
                scene = "Match nul";
                Tie.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                scene = "Victoire";
                victory.Text = gagnant + " à remporté la victoire !";
                Victoire.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void GoBackToMenu(object sender, RoutedEventArgs e)
        {
            goToMenu();
        }
    }
}
