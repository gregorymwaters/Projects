using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyroScope.Data.Entrees
{
    public class PiscesFishDish : Entree, IMenuItem
    {
        public override decimal Price { get { return 5.99m; } }
        public override uint Calories { get { return 726; } }
        public override List<string> SpecialInstructions { get { return new List<string>(); } }

        public override string Name {get {return "Pisces Fish Dish";} }
        public override string ToString() { return "Pisces Fish Dish"; }

    }
}
