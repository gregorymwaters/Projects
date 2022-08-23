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
using GyroScope.Data.Treats;
using GyroScope.Data.Enums;

namespace PointOfSale.ItemCustomizations
{
    /// <summary>
    /// Interaction logic for TreatsCustomization.xaml
    /// </summary>
    public partial class TreatsCustomization : UserControl
    {
        /// <summary>
        /// backing variables for temporary storage
        /// </summary>
        public AquariusIce Ice;
        public event EventHandler FinishAI;
        public TreatsCustomization()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializaes the customization window with correct items ticked
        /// </summary>
        /// <param name="ice"></param>
        public void AddItem(AquariusIce ice)
        {
            Ice = ice;
            switch(Ice.Flavor)
            {
                case AquariusIceFlavor.BlueRaspberry:
                    BlueRaspberryRadio.IsChecked = true;
                    break;
                case AquariusIceFlavor.Lemon:
                    LemonRadio.IsChecked = true;
                    break;
                case AquariusIceFlavor.Mango:
                    MangoRadio.IsChecked = true;
                    break;
                case AquariusIceFlavor.Orange:
                    OrangeRadio.IsChecked = true;
                    break;
                case AquariusIceFlavor.Strawberry:
                    StrawberryRadio.IsChecked = true;
                    break;
                case AquariusIceFlavor.Watermellon:
                    WatermelonRadio.IsChecked = true;
                    break;
            }
            switch(Ice.Size)
            {
                case GyroScope.Data.Enums.Size.Small:
                    SmallSideRadio.IsChecked = true;
                    break;
                case GyroScope.Data.Enums.Size.Medium:
                    MediumSideRadio.IsChecked = true;
                    break;
                case GyroScope.Data.Enums.Size.Large:
                    LargeSideRadio.IsChecked = true;
                    break;
            }
        }

        /// <summary>
        /// Pulls customizations from window and applies to temp object
        /// raises event and attaches customized item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinishItem(object sender, RoutedEventArgs e)
        {
            if ((bool)BlueRaspberryRadio.IsChecked) Ice.Flavor = AquariusIceFlavor.BlueRaspberry;
            if ((bool)LemonRadio.IsChecked) Ice.Flavor = AquariusIceFlavor.Lemon;
            if ((bool)MangoRadio.IsChecked) Ice.Flavor = AquariusIceFlavor.Mango;
            if ((bool)OrangeRadio.IsChecked) Ice.Flavor = AquariusIceFlavor.Orange;
            if ((bool)StrawberryRadio.IsChecked) Ice.Flavor = AquariusIceFlavor.Strawberry;
            if ((bool)WatermelonRadio.IsChecked) Ice.Flavor = AquariusIceFlavor.Watermellon;

            if ((bool)SmallSideRadio.IsChecked) Ice.Size = GyroScope.Data.Enums.Size.Small;
            if ((bool)MediumSideRadio.IsChecked) Ice.Size = GyroScope.Data.Enums.Size.Medium;
            if ((bool)LargeSideRadio.IsChecked) Ice.Size = GyroScope.Data.Enums.Size.Large;
            FinishAI?.Invoke(this, new EventArgs());
        }
    }
}
