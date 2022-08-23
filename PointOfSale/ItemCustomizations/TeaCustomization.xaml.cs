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

namespace PointOfSale.ItemCustomizations
{
    /// <summary>
    /// Interaction logic for TeaCustomization.xaml
    /// </summary>
    public partial class TeaCustomization : UserControl
    {
        /// <summary>
        /// Public backing variable to hold current iteration
        /// </summary>
        public CapricornMountainTea Drink;

        /// <summary>
        /// Event that triggers once custimization is done
        /// </summary>
        public event EventHandler FinishTea;
        /// <summary>
        /// Cunstructor for the control TeaCustomization
        /// </summary>
        public TeaCustomization()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Adds the initial object to populate the control on load
        /// </summary>
        /// <param name="tea"></param>
        public void AddItem(CapricornMountainTea tea)
        {
            Drink = tea;
            if(Drink.Honey) HoneyRadio.IsChecked = Drink.Honey;
            else PlainRadio.IsChecked = Drink.Honey;
        }

        /// <summary>
        /// Click event handler, invokes FinishTea event
        /// </summary>
        /// <param name="sender">AddItemButtom</param>
        /// <param name="e">Click</param>
        public void FinishItem(object sender, RoutedEventArgs e)
        {
            if ((bool)HoneyRadio.IsChecked) Drink.Honey = true;
            else Drink.Honey = false;
            FinishTea?.Invoke(this, new EventArgs());
        }
    }


}
