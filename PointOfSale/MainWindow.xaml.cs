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
using System.ComponentModel;
using PointOfSale.ItemCustomizations;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public UIElement CurrentControl = new UIElement();
        public event PropertyChangedEventHandler PropertyChanged;
        public MenuItemSelectionControl Menu;
        public OrderSummaryControl Order;
        public PaymentOptions Options;
        public CashPayment CashPay;

        /// <summary>
        /// Main Window hook, establishes control context for display
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Menu = new MenuItemSelectionControl(this);
            Options = new PaymentOptions();
            CashPay = new CashPayment();
            Menu.PropertyChanged += OrderSummary.OnPropertyChanged;
            OrderSummary.PropertyChanged += Menu.Remove;
            Options.PaymentProcess += Complete;
            Options.CashProcess += Cash;
            CashPay.FinishOrderEvent += Complete;
            CurrentControl = Menu;
            currentControl.Content = CurrentControl;
            
        }

        /// <summary>
        /// Method for changing control based on actions elsewhere in the design
        /// </summary>
        /// <param name="change"></param>
        public void ChangeControl(UIElement change)
        {
            currentControl.Content = change;
        }

        /// <summary>
        /// Functionality for "Back To Menu" Button, simply changes UI contrl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackToMenuButton_Click(object sender, RoutedEventArgs e)
        {
            currentControl.Content = Menu;
        }

        /// <summary>
        /// Functionality for Cancel Order button
        /// Updates master OrderItems list and OrderSummary display and order number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelOrderButton_Click(object sender, RoutedEventArgs e)
        {
            Menu.OrderItems.Clear();
            Menu.CancelOrder();
            OrderSummary.CancelOrder();
            currentControl.Content = Menu;
        }

        /// <summary>
        /// Functionality for Complete Order button
        /// Updates Order number and resets master OrderITems list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompleteButton_Click(object sender, RoutedEventArgs e)
        {
            currentControl.Content = Options;
        }

        private void Complete(object sender, EventArgs e)
        {
            OrderSummary.CompleteOrder();
            Menu.CompleteOrder();
            currentControl.Content = Menu;
        }

        private void Cash(object sender, EventArgs e)
        {
            CashPay.TotalInput((double)OrderSummary.total);
            currentControl.Content = CashPay;
        }
    }
}
