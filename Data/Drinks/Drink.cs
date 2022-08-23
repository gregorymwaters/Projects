using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyroScope.Data.Drinks
{
    /// <summary>
    /// Abstract base class for Drink menu items
    /// </summary>
    public abstract class Drink: IMenuItem
    {
        /// <summary>
        /// Getter for Price
        /// </summary>
        public abstract decimal Price { get; }
        /// <summary>
        /// Getter for Calories
        /// </summary>
        public abstract uint Calories { get; }

        public abstract string Name { get; }

        public abstract IEnumerable<string> SpecialInstructions { get; }
    }
}
