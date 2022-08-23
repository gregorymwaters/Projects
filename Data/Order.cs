using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace GyroScope.Data
{
    public class Order : INotifyCollectionChanged, INotifyPropertyChanged
    {
        /// <summary>
        /// List object to hold current order as list of IMenuItems
        /// </summary>
        private List<IMenuItem> currentOrder;
        /// <summary>
        /// Implimentation of the observable collection
        /// </summary>
        public ObservableCollection<IMenuItem> OCurrentOrder;
        /// <summary>
        /// private variable to handle order numbers
        /// </summary>
        private uint orderNumber = 1;
        /// <summary>
        /// private backing variables for money totals
        /// </summary>
        private decimal salesTaxRate = 0.09m;
        private decimal subtotal = 0.0m;
        private decimal total = 0.0m;

        /// <summary>
        /// private backing variable to total calories
        /// </summary>
        private uint calories;

        /// <summary>
        /// Event handlers for various event being raised within the class
        /// </summary>
        public event NotifyCollectionChangedEventHandler NotifyChange;
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Constructor for the order class
        /// Creates new collections for order handling
        /// </summary>
        public Order()
        {
            currentOrder = new List<IMenuItem>();
            OCurrentOrder = new ObservableCollection<IMenuItem>(currentOrder);
        }

        /// <summary>
        /// public facing variable for order number
        /// </summary>
        public uint Number { get { return orderNumber; } }

        /// <summary>
        /// public facing variable for the entire current order
        /// </summary>
        public List<IMenuItem> CurrentOrder { get { return currentOrder; } }

        /// <summary>
        /// public getter that totals the calories of the current order
        /// </summary>
        public uint Calories
        {
            get
            {
                calories = 0;
                foreach(IMenuItem mi in currentOrder)
                {
                    calories += mi.Calories;
                }
                return calories;
            }
        }

        /// <summary>
        /// Public getter that totals the subtotal
        /// </summary>
        public decimal SubTotal
        {
            get
            {
                subtotal = 0.0m;
                foreach (IMenuItem mi in currentOrder)
                {
                    subtotal += mi.Price;
                }
                return subtotal;
            }
        }

        /// <summary>
        /// Public getter that calculates how much tax is added
        /// </summary>
        public decimal Tax
        {
            get
            {
                return SubTotal * salesTaxRate;
            }
        }

        /// <summary>
        /// public getter that calculates the full total plus tax
        /// </summary>
        public decimal Total
        {
            get
            {
                total = 0.0m;
                total = (SubTotal * salesTaxRate) + SubTotal;
                return total;
            }
        }

        /// <summary>
        /// Method that adds IMenuItem to the current order
        /// Raises event on Addition to collection
        /// </summary>
        /// <param name="menuItem"></param>
        public void AddItem(IMenuItem menuItem)
        {
            currentOrder.Add(menuItem);
            OCurrentOrder.Add(menuItem);
            CollectionChanged?.Invoke(OCurrentOrder , new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add));
        }

        /// <summary>
        /// Method that removes an IMenuItem from the current order
        /// Raises event on Subtraction from the collection
        /// </summary>
        /// <param name="menuItem"></param>
        public void Remove(IMenuItem menuItem)
        {
            currentOrder.Remove(menuItem);
            CollectionChanged?.Invoke(OCurrentOrder, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove));
        }

        /// <summary>
        /// Method for handling cancel button
        /// </summary>
        public void CancelOrder()
        {
            currentOrder.Clear();
        }

        /// <summary>
        /// Method for handling complete order button
        /// </summary>
        public void CompleteOrder()
        {
            currentOrder.Clear();
            orderNumber++;
        }


    }
}
