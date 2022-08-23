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
using RoundRegister;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for PaymentOptions.xaml
    /// </summary>
    public partial class PaymentOptions : UserControl
    {
        /// <summary>
        /// declaration of total value for other Enums of CardReader class in the future
        /// </summary>
        private double Total = 0.0;

        /// <summary>
        /// Event handlers depending on which payment option is chosen
        /// </summary>
        public event EventHandler PaymentProcess;
        public event EventHandler CashProcess;

        /// <summary>
        /// Constructor
        /// </summary>
        public PaymentOptions()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Overload constructor if Total is needed in the future
        /// </summary>
        /// <param name="total"></param>
        public PaymentOptions(double total)
        {
            InitializeComponent();
            

        }

        /// <summary>
        /// public variable for total
        /// </summary>
        public double total
        {
            get { return Total; }
            set { Total = value; }
        }

        /// <summary>
        /// Click handler for Credit/Debit currently only handles approved as per design document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreditDebit_Click(object sender, RoutedEventArgs e)
        {
            CardTransactionResult cardTransaction = CardReader.RunCard(Total);
            switch (cardTransaction)
            {
                case CardTransactionResult.Approved:
                    RecieptPrinter.PrintLine("Debit/Credit: " + cardTransaction.ToString());
                    PaymentProcess?.Invoke(cardTransaction, new EventArgs());
                    break;
                case CardTransactionResult.Declined:
                    break;
                case CardTransactionResult.IncorrectPin:
                    break;
                case CardTransactionResult.InsufficientFunds:
                    break;
                case CardTransactionResult.ReadError:
                    break;
            }
        }

        /// <summary>
        /// Button handler that transfers control over to Cash Payment User Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cash_Click(object sender, RoutedEventArgs e)
        {
            RecieptPrinter.PrintLine("Cash Payment");
            CashProcess?.Invoke(this, new EventArgs());
        }
    }
}
