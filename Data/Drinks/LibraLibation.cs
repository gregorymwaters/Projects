using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GyroScope.Data.Enums;
using System.ComponentModel;

namespace GyroScope.Data.Drinks
{
    public class LibraLibation : Drink, INotifyPropertyChanged, IMenuItem
    {
        /// <summary>
        /// Private backing variables for LibraLibation
        /// </summary>
        private LibraLibationFlavor flavor = LibraLibationFlavor.Orangeade;
        private bool sparkling = true;
        private string name = "";

        /// <summary>
        /// public getters and setters for private variables
        /// public variable for Flavor of type LibraLibationFlavor Enum
        /// </summary>
        public LibraLibationFlavor Flavor { get { return flavor; } set { flavor = value; PropertyChanged?.Invoke(Flavor, new PropertyChangedEventArgs("Flavor Changed")); } }

        /// <summary>
        /// boolian to keep track of Sparkling property either Aprkling or Still
        /// </summary>
        public bool Sparkling { get { return sparkling; } set { sparkling = value; PropertyChanged?.Invoke(Sparkling, new PropertyChangedEventArgs("Sparkling Changed")); } }
        /// <summary>
        /// Override Price getter inherited from Drink abstract class
        /// </summary>
        public override decimal Price { get { return 1.00m; } }

        /// <summary>
        /// Calories calculation based on Flavor Enum
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch (flavor)
                {
                    case LibraLibationFlavor.Orangeade:
                        return 180;
                    case LibraLibationFlavor.Biral:
                        return 120;
                    case LibraLibationFlavor.PinkLemonada:
                        return 41;
                    case LibraLibationFlavor.SourCherry:
                        return 100;
                    default:
                        throw new NotImplementedException($"Unknown Flavor {Flavor}");
                }
            }
        }

        /// <summary>
        /// Populates correct name string for output
        /// </summary>
        public override string Name
        {
            get
            {
                name = "";
                if (!sparkling)
                {
                    name += "Still ";
                }
                else
                {
                    name += "Sparkling ";
                }
                switch (flavor)
                {
                    case LibraLibationFlavor.Orangeade:
                        name += "Orangeade ";
                        break;
                    case LibraLibationFlavor.Biral:
                        name += "Biral ";
                        break;
                    case LibraLibationFlavor.PinkLemonada:
                        name += "Pink Lemonada ";
                        break;
                    case LibraLibationFlavor.SourCherry:
                        name += "Sour Cherry ";
                        break;
                }
                name += "Libra Libation";
                return name;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Override of default ToString Method
        /// returns Name property
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }

        public override IEnumerable<string> SpecialInstructions { get { return new List<string>(); } }
    }
}
