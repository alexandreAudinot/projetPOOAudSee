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
using System.Windows.Shapes;

namespace WpfDisplay
{
    /// <summary>
    /// Interaction logic for HelpPopup.xaml
    /// </summary>
    public partial class HelpPopup : Window
    {
        public HelpPopup()
        {
            InitializeComponent();
            textBloc.Text =
                "Le but du jeu est d'avoir le plus d'anneaux. Plusieurs unités sur la même case ne génère qu'un seul anneau. \n\n" +
                "Le coût de déplacement varie selon les cases et les unités. En général, il est de 1.\n" +
                "Mais il est différent dans les cas suivants.\n" +
                "Les elfes ne peuvent pas traverser les déserts.\n" +
                "Les elfes ne payent que 0.5 depl. en traversant une forêt.\n" +
                "Les orques ne payent que 0.5 depl. en traversant une plaine.\n" +
                "Les nains ne payent que 0.5 depl. en traversant une plaine.\n" +
                "Les nains peuvent voyager gratuitement dans les montagnes.\n\n" +
                "Le coût d'une attaque est toujours de 1.\n" +
                "Seuls les orques génèrent un anneau quand ils tuent une unité adverse, mais ils n'acquièrent pas d'anneaux sur les cases Forêt.\n" +
                "Les nains n'acquièrent pas de points dans les plaines.\n\n" +
                "Les elfes ont 50% de chance de fuir un combat perdu (où ils devaient mourir), il se replient sur une case adjacente accessible.\n" +
                "(Dans le cas inverse, l'unité mourra)\n\n" +
                "Il est conseillé d'éparpiller au maximum ses unités, en attaquant l'adversaire dès que possible.\n" +
                "L'évaluation du nombre d'anneaux est lancé lors de l'activation du sort de Saruman, ou si un des joueurs perd la partie avant.\n";
   
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
