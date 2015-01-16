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
    /// Interaction logic for PlayerInfo.xaml
    /// </summary>
    public partial class PlayerInfo : UserControl
    {
        private Player associatedPlayer;
        public PlayerInfo()
        {
            InitializeComponent();
        }

        public void setPlayer(Player p)
        {
            associatedPlayer = p;
            name.Content = p.nom + " : " + p.listUnit.First().getLeType();
        }

        public void updateInfos()
        {
            points.Content = associatedPlayer.score;
            nbUnits.Content = associatedPlayer.listUnit.Count;
        }
    }
}
