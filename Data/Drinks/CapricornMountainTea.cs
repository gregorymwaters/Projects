using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace GyroScope.Data.Drinks
{
    /// <summary>
    /// Class definition for Capricorn Mountain Tea
    /// </summary>
    public class CapricornMountainTea : Drink, INotifyPropertyChanged, IMenuItem
    {
        /// <summary>
        /// private backing variable for default setting
        /// </summary>
        private bool honey = false;
        /// <summary>
        /// Overridden getter for price inherited from Drink
        /// </summary>
        public override decimal Price { get { return 2.50m; } }

        /// <summary>
        /// Overridden Calories getter inherited from Drink
        /// </summary>
        public override uint Calories {
            get 
            {
                if(honey)
                {
                    return 64;
                }
                else
                {
                    return 0;
                }
            } 
        }

        /// <summary>
        /// Getter and setter for private backing variable honey
        /// </summary>
        public bool Honey { get { return honey; } set { honey = value; PropertyChanged?.Invoke(Honey, new PropertyChangedEventArgs("Honey Changed")); } }

        public override string Name
        {
            get { return "Capricorn Mountain Tea"; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            if(Honey)
            {
                return "Capricorn Mountain Tea";
            }
            else
            {
                return "Capricorn Mountain Tea No Honey";
            }
        }

        public override List<string> SpecialInstructions { get { return new List<string>(); } }


    }
}
