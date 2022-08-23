using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyroScope.Data.Treats
{
    /// <summary>
    /// Class definition for Cancer Havleh Cake
    /// Inherits from Treat
    /// </summary>
    public class CancerHalvaCake : Treat, IMenuItem
    {
        /// <summary>
        /// Override method for Calories inherited from Treat base class
        /// </summary>
        public override uint Calories { get { return 272; } }
        /// <summary>
        /// Override method for getting Price inherited from Treat base class
        /// </summary>
        public override decimal Price { get { return 3.00m; } }

        public override string Name { get { return "Cancer Halva Cake"; } }
        public override string ToString()
        {
            return Name;
        }

        public override IEnumerable<string> SpecialInstructions { get { return new List<string>(); } }
    }
}
