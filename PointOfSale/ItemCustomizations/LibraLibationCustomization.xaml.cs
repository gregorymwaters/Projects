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
using GyroScope.Data.Drinks;
using GyroScope.Data.Enums;

namespace PointOfSale.ItemCustomizations
{
    /// <summary>
    /// Interaction logic for LibraLibationCustomization.xaml
    /// </summary>
    public partial class LibraLibationCustomization : UserControl
    {
        public LibraLibation Drink;
        public event EventHandler FinishLL;
        public LibraLibationCustomization()
        {
            InitializeComponent();
        }

        public void AddItem(LibraLibation drink)
        {
            Drink = drink;
            switch(Drink.Flavor)
            {
                case LibraLibationFlavor.Biral:
                    BiralRadio.IsChecked = true;
                    break;
                case LibraLibationFlavor.Orangeade:
                    OrangeadeRadio.IsChecked = true;
                    break;
                case LibraLibationFlavor.PinkLemonada:
                    PinkLemonadaRadio.IsChecked = true;
                    break;
                case LibraLibationFlavor.SourCherry:
                    SourCherryRadio.IsChecked = true;
                    break;
            }
            if(Drink.Sparkling)
            {
                SparklingRadio.IsChecked = true;
            }
            else
            {
                StillRadio.IsChecked = true;
            }
        }

        public void FinishItem(object sender, RoutedEventArgs e)
        {
            if ((bool) BiralRadio.IsChecked) Drink.Flavor = LibraLibationFlavor.Biral;
            if ((bool) OrangeadeRadio.IsChecked) Drink.Flavor = LibraLibationFlavor.Orangeade;
            if ((bool) PinkLemonadaRadio.IsChecked) Drink.Flavor = LibraLibationFlavor.PinkLemonada;
            if ((bool) SourCherryRadio.IsChecked) Drink.Flavor = LibraLibationFlavor.SourCherry;
            
            if ((bool)SparklingRadio.IsChecked)
            {
                Drink.Sparkling = true;
            }
            else
            {
                Drink.Sparkling = false;
            }

            FinishLL?.Invoke(this, new EventArgs());
        }
    }
}
