using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GyroScope.Data.Enums;
using System.ComponentModel;

namespace GyroScope.Data.Entrees
{
    /// <summary>
    /// Abstract base class for all Gyro type Entree objects on the menu
    /// Inherits from Entree base class
    /// </summary>
    public abstract class Gyro : Entree, INotifyPropertyChanged, IMenuItem
    {
        /// <summary>
        /// Special Instructions All Ingredients
        /// All getters and setters inherited from this class have private backing variables
        /// in the child class objects
        /// </summary>
        /// 

        /// <summary>
        /// public abstract variable for Pita bool
        /// </summary>
        public abstract bool Pita { get; set; }
        /// <summary>
        /// public abstract variable for Tomato bool
        /// </summary>
        public abstract bool Tomato { get; set; }
        /// <summary>
        /// public abstract variable for Onion bool
        /// </summary>
        public abstract bool Onion { get; set; }
        /// <summary>
        /// public abstract variable for Lettuce bool
        /// </summary>
        public abstract bool Lettuce { get; set; }
        /// <summary>
        /// public abstract variable for Tzatsiki bool
        /// </summary>
        public abstract bool Tzatziki { get; set; }
        /// <summary>
        /// public abstract variable for Peppers bool
        /// </summary>
        public abstract bool Peppers { get; set; }
        /// <summary>
        /// public abstract variable for Wing Suace bool
        /// </summary>
        public abstract bool WingSauce { get; set; }
        /// <summary>
        /// public abstract variable for Eggplant bool
        /// </summary>
        public abstract bool Eggplant { get; set; }
        /// <summary>
        /// public abstract variable for Mint Chutney bool
        /// </summary>
        public abstract bool MintChutney { get; set; }
        /// <summary>
        /// public abstract variable for Meat variable of enum type DonerMeat
        /// </summary>
        public abstract DonerMeat Meat { get; set; }
    }
}
