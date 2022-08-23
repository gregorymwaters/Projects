using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GyroScope.Data.Enums;
using System.ComponentModel;

namespace GyroScope.Data.Sides
{
    public class TaurusTabuleh : Side, INotifyPropertyChanged, IMenuItem
    {
        /// <summary>
        /// Establishing and initializing private backing
        /// variables for the class
        /// </summary>
        /// 
        private string name = "Tarus Tabuleh";
        /// <summary>
        /// The default Size of Tarus Tabuleh
        /// </summary>
        private Size size = Size.Small;

        /// <summary>
        /// Public facing getters and setters
        /// </summary>


        /// <summary>
        /// The Size of Tarus Tabuleh
        /// </summary>
        public override Size Size
        {
            get { return size; }
            set { size = value; PropertyChanged?.Invoke(Size, new PropertyChangedEventArgs("Size Changed")); }
        }

        /// <summary>
        /// The Price of Tarus Tabuleh
        /// </summary>
        public override decimal Price
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return 1.50m;
                    case Size.Medium:
                        return 2.00m;
                    case Size.Large:
                        return 2.50m;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// The Calories of Tarus Tabuleh
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return 124;
                    case Size.Medium:
                        return 186;
                    case Size.Large:
                        return 248;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// The name of the class
        /// </summary>
        public override string Name
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return "Small " + name;
                    case Size.Medium:
                        return "Medium " + name;
                    case Size.Large:
                        return "Large " + name;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// ToString override
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            switch (Size)
            {
                case Size.Small:
                    return "Small " + name;
                case Size.Medium:
                    return "Medium " + name;
                case Size.Large:
                    return "Large " + name;
                default:
                    throw new NotImplementedException();
            }
        }

        public override IEnumerable<string> SpecialInstructions { get { return new List<string>(); } }
    }
}
