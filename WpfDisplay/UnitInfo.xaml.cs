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
    /// Interaction logic for UnitInfo.xaml
    /// </summary>
    public partial class UnitInfo : UserControl
    {
        public MapView mapView { private get; set; }
        private Unit associatedUnit;
        public Unit AssociatedUnit
        {
            get
            {
                return associatedUnit;
            }
            set
            {
                associatedUnit = value;
                updateInfos();
            }
        }

        public UnitInfo()
        {
            InitializeComponent();
        }

        public void updateInfos()
        {
            string unitType;

            if (associatedUnit != null)
            {
                unitType = associatedUnit.GetType().ToString();
                img.Source = mapView.getImageFromType(unitType);
                attaque.Content = associatedUnit.att;
                defense.Content = associatedUnit.def;
                pv.Content = associatedUnit.hp;
                deplacement.Content = associatedUnit.nbDeplacement;
                if (unitType == "ProjetPOO.Orc")
                {
                    blocAnneaux.Visibility = System.Windows.Visibility.Visible;
                    anneaux.Content = ((Orc)associatedUnit).pvOrc;
                }
                else
                {
                    blocAnneaux.Visibility = System.Windows.Visibility.Hidden;
                }
            }
        }

        private void onClick(object sender, MouseButtonEventArgs e)
        {
            mapView.unselectAll();
            select();
        }

        public void select()
        {
            mapView.setSelectedUnit(associatedUnit);
            selected.Visibility = System.Windows.Visibility.Visible;
        }
        public void unselect()
        {
            selected.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
