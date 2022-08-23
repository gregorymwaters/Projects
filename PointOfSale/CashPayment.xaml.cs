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
    /// Interaction logic for CashPayment.xaml
    /// </summary>
    public partial class CashPayment : UserControl
    {
        /// <summary>
        /// private backing variables for keeping track of various totals
        /// </summary>
        private double total { get; set; }
        private double runTotal { get; set; }
        public double inTotal { get; set; }
        public double Change { get; set; }
        /// <summary>
        /// Boolean flag to ensure that the change is "dispensed" and drawer updated before finishing the sale
        /// </summary>
        private bool changeGiven { get; set; }

        /// <summary>
        /// Event handler for once the cash transaction is complete
        /// </summary>
        public event EventHandler FinishOrderEvent;

        /// <summary>
        /// Constructor
        /// </summary>
        public CashPayment()
        {
            InitializeComponent();
            ///Resets drawer on construction
            CashDrawer.ResetDrawer();
            ///Method call for populating UI
            Populate();
            TotalText.Text = total.ToString();
            ///Ensures flag is initially set to false
            changeGiven = false;
        }

        /// <summary>
        /// Takes in double total from the order summary so change can be calculated
        /// </summary>
        /// <param name="_total"></param>
        public void TotalInput(double _total)
        {
            Change = 0.0;
            inTotal = 0.0;
            total = Math.Round(_total, 2);
            runTotal = Math.Round(total, 2);
            TotalText.Text = total.ToString();
            Populate();
        }

        /// <summary>
        /// Updates all text fields in the UI
        /// Placed in one method for ease
        /// </summary>
        public void Populate()
        {
            HundredsText.Text = CashDrawer.Hundreds.ToString();
            FiftiesText.Text = CashDrawer.Fifties.ToString();
            TwentiesText.Text = CashDrawer.Twenties.ToString();
            TensText.Text = CashDrawer.Tens.ToString();
            FivesText.Text = CashDrawer.Fives.ToString();
            OnesText.Text = CashDrawer.Ones.ToString();
            QuartersText.Text = CashDrawer.Quarters.ToString();
            DimesText.Text = CashDrawer.Dimes.ToString();
            NicklesText.Text = CashDrawer.Nickels.ToString();
            PenniesText.Text = CashDrawer.Pennies.ToString();
            TotalText.Text = total.ToString();
            InputTotalText.Text = inTotal.ToString();
            ChangeDueText.Text = Math.Round(runTotal,2).ToString();
        }


        /// <summary>
        /// Handles adding hundreds to the drawer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HundredPlusButton_Click(object sender, RoutedEventArgs e)
        {
            CashDrawer.Hundreds++;
            runTotal -= 100.00;
            inTotal += 100.00;
            Populate();
        }

        /// <summary>
        /// Handles adding fifties to the drawer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FiftyPlusButton_Click(object sender, RoutedEventArgs e)
        {
            CashDrawer.Fifties++;
            runTotal -= 50.00;
            inTotal += 50.00;
            Populate();
        }

        /// <summary>
        /// Handles adding twenties to the drawer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TwentyPlusButton_Click(object sender, RoutedEventArgs e)
        {
            CashDrawer.Twenties++;
            runTotal -= 20.00;
            inTotal += 20.00;
            Populate();
        }

        /// <summary>
        /// Handles adding tens to the drawer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TenPlusButton_Click(object sender, RoutedEventArgs e)
        {
            CashDrawer.Tens++;
            runTotal -= 10.00;
            inTotal += 10.00;
            Populate();
        }

        /// <summary>
        /// Handles adding fives to the drawer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FivePlusButton_Click(object sender, RoutedEventArgs e)
        {
            CashDrawer.Fives++;
            runTotal -= 5.00;
            inTotal += 5.00;
            Populate();
        }

        /// <summary>
        /// Handles adding ones to the drawer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnePlusButton_Click(object sender, RoutedEventArgs e)
        {
            CashDrawer.Ones++;
            runTotal -= 1.00;
            inTotal += 1.00;
            Populate();
        }

        /// <summary>
        /// Handles adding quarterss to the drawer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuarterPlusButton_Click(object sender, RoutedEventArgs e)
        {
            CashDrawer.Quarters++;
            runTotal -= 0.25;
            inTotal += 0.25;
            Populate();
        }

        /// <summary>
        /// Handles adding dimes to the drawer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DimePlusButton_Click(object sender, RoutedEventArgs e)
        {
            CashDrawer.Dimes++;
            runTotal -= 0.10;
            inTotal += 0.10;
            Populate();
        }

        /// <summary>
        /// Handles adding nickles to the drawer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NicklePlusButton_Click(object sender, RoutedEventArgs e)
        {
            CashDrawer.Nickels++;
            runTotal -= 0.05;
            inTotal += 0.05;
            Populate();
        }

        /// <summary>
        /// Handles adding pennies to the drawer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PennyPlusButton_Click(object sender, RoutedEventArgs e)
        {
            CashDrawer.Pennies++;
            runTotal -= 0.01;
            inTotal += 0.01;
            Populate();
        }

        /// <summary>
        /// Calculates change by demonination using a greedy algorithm that always uses
        /// highest value currency first
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetChange_Click(object sender, RoutedEventArgs e)
        {
            ///Ensures that if not enough money has been entered the button does nothing
            if(runTotal <= 0)
            {
                ///Creation of temp variables to keep track of various totals for the recipt
                double tempTotal;
                Change = runTotal;
                Math.Round(runTotal *= -1, 2);
                changeGiven = true;
                if((runTotal % 100.00) < runTotal)
                {
                    CashDrawer.Hundreds -= (int)(runTotal % 100.00);
                    tempTotal = runTotal % 100.00;
                    runTotal = tempTotal;
                }
                if ((runTotal % 50.00) < runTotal)
                {
                    CashDrawer.Fifties -= (int)(runTotal % 50.00);
                    tempTotal = runTotal % 50.00;
                    runTotal = tempTotal;
                }
                if ((runTotal % 20.00) < runTotal)
                {
                    CashDrawer.Twenties -= (int)(runTotal % 20.00);
                    tempTotal = runTotal % 20.00;
                    runTotal = tempTotal;
                }
                if ((runTotal % 10.00) < runTotal)
                {
                    CashDrawer.Tens -= (int)(runTotal % 10.00);
                    tempTotal = runTotal % 10.00;
                    runTotal = tempTotal;
                }
                if ((runTotal % 5.00) < runTotal)
                {
                    CashDrawer.Fives -= (int)(runTotal % 5.00);
                    tempTotal = runTotal % 5.00;
                    runTotal = tempTotal;
                }
                if ((runTotal % 1.00) < runTotal)
                {
                    CashDrawer.Ones -= (int)(runTotal % 1.00);
                    tempTotal = runTotal % 1.00;
                    runTotal = tempTotal;
                }
                if ((runTotal % 0.25) < runTotal)
                {
                    CashDrawer.Quarters -= (int)(runTotal % 0.25);
                    tempTotal = runTotal % 0.25;
                    runTotal = tempTotal;
                }
                if ((runTotal % 0.10) < runTotal)
                {
                    CashDrawer.Dimes -= (int)(runTotal % 0.10);
                    tempTotal = runTotal % 0.10;
                    runTotal = tempTotal;
                }
                if ((runTotal % 0.05) < runTotal)
                {
                    CashDrawer.Nickels -= (int)(runTotal % 0.05);
                    tempTotal = runTotal % 0.05;
                    runTotal = tempTotal;
                }
                if ((runTotal % 0.01) < runTotal)
                {
                    CashDrawer.Pennies -= (int)(runTotal % 0.01);
                    tempTotal = runTotal % 0.01;
                    runTotal = tempTotal;
                }
                Populate();
            }
        }

        private void FinishOrder_Click(object sender, RoutedEventArgs e)
        {
            ///Checks if change has been given, otherwise the button does nothing
            if(changeGiven)
            {
                ///Resets the flag for next transaction
                changeGiven = false;
                ///Formats the recipt
                RecieptPrinter.PrintLine("Total: " + total.ToString());
                RecieptPrinter.PrintLine("Customer Paid: " + inTotal.ToString());
                RecieptPrinter.PrintLine("Change Returned: " + Change.ToString());
                ///Raises flag so new order behavior can be restarted
                FinishOrderEvent?.Invoke(this, new EventArgs());
            }
        }


    }
}
