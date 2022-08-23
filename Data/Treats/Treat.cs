using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GyroScope.Data.Enums;

namespace GyroScope.Data.Treats
{
    /// <summary>
    /// Base class definition for Treat namespace menu items
    /// </summary>
    public abstract class Treat : IMenuItem
    {
        /// <summary>
        /// Abstract getter for Price from an object
        /// </summary>
        public abstract decimal Price { get; }
        /// <summary>
        /// Abstract getter for Claories from an object
        /// </summary>
        public abstract uint Calories { get; }

        public abstract string Name { get; }

        public abstract IEnumerable<string> SpecialInstructions { get; }
    }
}
