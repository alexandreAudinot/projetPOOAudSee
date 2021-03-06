﻿using System;
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
    /// Interaction logic for GameInfo.xaml
    /// </summary>
    public partial class GameInfo : UserControl
    {
        public GameInfo()
        {
            InitializeComponent();
        }

        public void updateGameInfos()
        {
            player.Content = "Joueur " + (World.Instance.currentPlayer+1);
            turn.Content = "Tour " + (World.Instance.nbTours+1) + "/" + World.Instance.maxnbTours;
        }
    }
}
