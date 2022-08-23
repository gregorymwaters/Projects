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
using GyroScope.Data.Entrees;
using GyroScope.Data.Drinks;
using GyroScope.Data.Sides;
using GyroScope.Data.Treats;
using GyroScope.Data.Enums;
using GyroScope.Data;
using RoundRegister;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for OrderSummaryControl.xaml
    /// </summary>
    public partial class OrderSummaryControl : UserControl, INotifyPropertyChanged
    {
        /// <summary>
        /// Private testing variables to ensure behavior
        /// First is populating List property
        /// </summary>
        private decimal Total = 0.0m;
        private decimal SubTotal = 0.0m;
        private decimal Tax = 0.0m;

        /// <summary>
        /// Stand in private variable for orderNumber integer
        /// </summary>
        private uint orderNum = 1;

        /// <summary>
        /// Stand in DateTime getter for testing purposes
        /// </summary>
        private string time = DateTime.Now.ToShortTimeString();

        /// <summary>
        /// Event handlers for property changed and remove item button
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler RemoveSelectedItem;

        /// <summary>
        /// Holds list binding for the ListBox to display the order
        /// </summary>
        private List<IMenuItem> orderItems;

        /// <summary>
        /// Main constructor of OrderSummaryControl class
        /// Calls test method TextPopulate() for functionality testing
        /// </summary>
        public OrderSummaryControl()
        {
            InitializeComponent();
            this.DataContext = this;
            PropertyChanged += OnPropertyChanged;
            TextPopulate();
            orderItems = new List<IMenuItem>();
        }

        /// <summary>
        /// Helper method to populated both the header TextBox and ListViewBox for displaying order
        /// </summary>
        public void TextPopulate()
        {
            OrderNumberBox.Text = "Order Number " + orderNum + "\n" + DateTime.Now.ToString(); 
            TotalTextBox.Items.Add("SubTotal $" + SubTotal);
            TotalTextBox.Items.Add("Tax $" + Tax);
            TotalTextBox.Items.Add("Total $" + Total);
        }

        /// <summary>
        /// Handler for CancelOrder button
        /// Clears all lists and updates text
        /// </summary>
        public void CancelOrder()
        {
            OrderTextBox.Items.Clear();
            TotalTextBox.Items.Clear();
            orderItems.Clear();
            TextPopulate();

        }

        /// <summary>
        /// Handler for CompleteOrder button
        /// Clears all lists and updates text
        /// </summary>
        public void CompleteOrder()
        {
            RecieptPrinter.PrintLine("Order Number " + orderNum.ToString());
            RecieptPrinter.PrintLine(DateTime.Now.ToString());
            for (int i = 0; i < OrderTextBox.Items.Count; i++)
            {
                RecieptPrinter.PrintLine(OrderTextBox.Items[i].ToString());
            }

            for (int j = 0; j < TotalTextBox.Items.Count; j++)
            {
                RecieptPrinter.PrintLine(TotalTextBox.Items[j].ToString());
            }
            RecieptPrinter.CutTape();

            OrderTextBox.Items.Clear();
            TotalTextBox.Items.Clear();
            orderItems.Clear();
            TextPopulate();
        }

        public void OnCollectionChanged(object sender, CollectionChangeEventArgs e)
        {

        }
        /// <summary>
        /// Updater method called when master OrderList is modified in the ItemCustomization namespace controllers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ///Formatting spacer for the list
            string spacer = "    ";
            ///Clears the text box each time the method is called
            OrderTextBox.Items.Clear();
            TotalTextBox.Items.Clear();

            ///Checks if the sender is IEnumerable, in this case a List
            if (sender is Order order)
            {
                ///Sets decimal that controls the subtotal to 0.0 prior to the loop
                orderNum = order.Number;
                Total = Math.Round(order.Total, 2);
                SubTotal = Math.Round(order.SubTotal,2);
                Tax = Math.Round(order.Tax, 2);

                ///Loops through the IEnermerable object checking to see the type of each object
                foreach (object x in order.CurrentOrder)
                {         
                    if(x is Entree entree )
                    {
                        orderItems.Add(x as IMenuItem);
                        ///Adds the name to the text box
                        OrderTextBox.Items.Add(entree);
                        ///Loops through IEnermrable List<string> of special instructions for printing
                        for(int i = 0;  i < entree.SpecialInstructions.Count(); i++)
                        {
                            OrderTextBox.Items.Add(spacer + entree.SpecialInstructions.ElementAt(i));
                        }
                    }

                    if (x is Drink drink)
                    {
                        orderItems.Add(x as IMenuItem);
                        OrderTextBox.Items.Add(drink);
                    }

                    if (x is Side side)
                    {
                        orderItems.Add(x as IMenuItem);
                        OrderTextBox.Items.Add(side);
                    }

                    if(x is Treat treat)
                    {
                        orderItems.Add(x as IMenuItem);
                        OrderTextBox.Items.Add(treat);
                    }
                }
            }


            TextPopulate();
        }

        /// <summary>
        /// Event router for removal of items from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveSelected_Click(object sender, RoutedEventArgs e)
        {
            PropertyChanged?.Invoke(OrderTextBox.SelectedItem, new PropertyChangedEventArgs("Remove Item"));
        }

        public decimal total
        {
            get
            {
                return Total;
            }
        }
    }
}
