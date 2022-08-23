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
using GyroScope.Data.Sides;
using GyroScope.Data.Enums;

namespace PointOfSale.ItemCustomizations
{
    /// <summary>
    /// Interaction logic for SideCustomization.xaml
    /// </summary>
    public partial class SideCustomization : UserControl
    {
        public Side Side;
        public event EventHandler FinishSide;
        public SideCustomization()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Adds Item to temporary variable for customization
        /// </summary>
        /// <param name="side"></param>
        public void AddItem(Side side)
        {
            Side = side;
            switch(side.Size)
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
        /// Raises event on customization and attaches instance to event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinishItem(object sender, RoutedEventArgs e)
        {
            if ((bool)SmallSideRadio.IsChecked) Side.Size = GyroScope.Data.Enums.Size.Small;
            if ((bool)MediumSideRadio.IsChecked) Side.Size = GyroScope.Data.Enums.Size.Medium;
            if ((bool)LargeSideRadio.IsChecked) Side.Size = GyroScope.Data.Enums.Size.Large;
            FinishSide?.Invoke(this, new EventArgs());
        }
    }
}
