using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyroScope.Data
{
    /// <summary>
    /// Implimentation of the IMenuItem Interface
    /// </summary>
    public interface IMenuItem
    {
        /// <summary>
        /// Gets the price of the implimenting class
        /// </summary>
        public decimal Price { get; }
        /// <summary>
        /// Gets the calories for the implimenting class
        /// </summary>
        public uint Calories { get; }
        /// <summary>
        /// Gets SpecialInstructions List<string> for the implimenting class
        /// </summary>
        public IEnumerable<string> SpecialInstructions { get; }
        /// <summary>
        /// Gets the Name of the implimenting class
        /// </summary>
        public string Name { get; }
    }
}
