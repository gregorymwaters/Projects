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
using GyroScope.Data.Entrees;
using GyroScope.Data.Enums;

namespace PointOfSale.ItemCustomizations
{
    /// <summary>
    /// Interaction logic for GyroCustomization.xaml
    /// </summary>
    public partial class GyroCustomization : UserControl
    {
        public Gyro Gyro;
        public event EventHandler FinishGyro;
        public GyroCustomization()
        {
            InitializeComponent();
        }

        public void AddItem(Gyro gyro)
        {
            Gyro = gyro;
            PitaCheckbox.IsChecked = Gyro.Pita;
            TomatoCheckbox.IsChecked = Gyro.Tomato;
            PeppersCheckbox.IsChecked = Gyro.Peppers;
            OnionCheckbox.IsChecked = Gyro.Onion;
            LettuceCheckbox.IsChecked = Gyro.Lettuce;
            EggplantCheckbox.IsChecked = Gyro.Eggplant;
            TzatiskiCheckbox.IsChecked = Gyro.Tzatziki;
            MintChutneyCheckbox.IsChecked = Gyro.MintChutney;
            WingSauceCheckbox.IsChecked = Gyro.WingSauce;
            switch (Gyro.Meat)
            {
                case DonerMeat.Beef:
                    BeefRadio.IsChecked = true;
                    break;
                case DonerMeat.Chicken:
                    ChickenRadio.IsChecked = true;
                    break;
                case DonerMeat.Lamb:
                    LambRadio.IsChecked = true;
                    break;
                case DonerMeat.Pork:
                    PorkRadio.IsChecked = true;
                    break;
            }   
        }

        public void FinishItem(object sender, RoutedEventArgs e)
        {
            Gyro.Pita = (bool)PitaCheckbox.IsChecked;
            Gyro.Tomato = (bool)TomatoCheckbox.IsChecked;
            Gyro.Peppers = (bool)PeppersCheckbox.IsChecked;
            Gyro.Onion = (bool)OnionCheckbox.IsChecked;
            Gyro.Lettuce = (bool)LettuceCheckbox.IsChecked;
            Gyro.Eggplant = (bool)EggplantCheckbox.IsChecked;
            Gyro.Tzatziki = (bool)TzatiskiCheckbox.IsChecked;
            Gyro.MintChutney = (bool)MintChutneyCheckbox.IsChecked;
            Gyro.WingSauce = (bool)WingSauceCheckbox.IsChecked;
            if ((bool)BeefRadio.IsChecked) Gyro.Meat = DonerMeat.Beef;
            if ((bool)ChickenRadio.IsChecked) Gyro.Meat = DonerMeat.Chicken;
            if ((bool)LambRadio.IsChecked) Gyro.Meat = DonerMeat.Lamb;
            if ((bool)PorkRadio.IsChecked) Gyro.Meat = DonerMeat.Pork;
            FinishGyro?.Invoke(this, new EventArgs());
        }
    }
}
