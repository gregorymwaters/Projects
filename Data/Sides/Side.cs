using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GyroScope.Data.Enums;

namespace GyroScope.Data.Sides
{
    ///<summary>
    /// A base class for Sides
    /// </summary>
    public abstract class Side : IMenuItem
    {
        ///<summary>
        /// Gets Calories for a Side
        /// </summary>
        /// 
        public abstract uint Calories { get; }

        ///<summary>
        /// Gets or Sets Size enum for a Side
        /// </summary>
        /// 

        public abstract Size Size { get; set; }

        ///<summary>
        /// Gets Price of a Side
        /// </summary>
        /// 
        public abstract decimal Price { get; }

        public abstract string Name { get; }

        public abstract IEnumerable<string> SpecialInstructions { get; }
    }
}
