using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GyroScope.Data.Enums;
using System.ComponentModel;

namespace GyroScope.Data.Treats
{
    /// <summary>
    /// A class representing "Aquarius Ice" - an itialian iced soda
    /// </summary>
    public class AquariusIce : Treat, INotifyPropertyChanged, IMenuItem
    {
        private AquariusIceFlavor flavor = AquariusIceFlavor.Lemon;
        private Size size = Size.Small;
        /// <summary>
        /// The name of AquariousIce object instance
        /// </summary>
        public override string Name
        {
            get
            {
                string name = "";
                switch(Size)
                {
                    case Size.Small:
                        name += "Small ";
                        break;
                    case Size.Medium:
                        name += "Medium ";
                        break;
                    case Size.Large:
                        name += "Large ";
                        break;
                }
                switch(Flavor)
                {
                    case AquariusIceFlavor.Lemon:
                        name += "Lemon ";
                        break;
                    case AquariusIceFlavor.Orange:
                        name += "Orange ";
                        break;
                    case AquariusIceFlavor.BlueRaspberry:
                        name += "BlueRaspberry ";
                        break;
                    case AquariusIceFlavor.Watermellon:
                        name += "Watermellon ";
                        break;
                    case AquariusIceFlavor.Strawberry:
                        name += "Strawberry ";
                        break;
                    case AquariusIceFlavor.Mango:
                        name += "Mango ";
                        break;
                }
                name += "Aquarius Ice";
                return name;
            }
        }
            

        /// <summary>
        /// The size of this Aquarius Ice    
        /// </summary>
        public Size Size { get { return size; } set { size = value;} }

        /// <summary>
        /// The flavor of this Aquarius Ice
        /// </summary>
        public AquariusIceFlavor Flavor { get { return flavor; } set { flavor = value;} }

        /// <summary>
        /// The calories of this Aquarius Ice
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch (Flavor)
                {
                    case AquariusIceFlavor.Lemon:
                    case AquariusIceFlavor.Orange:
                    case AquariusIceFlavor.Mango:
                    case AquariusIceFlavor.Watermellon:
                        return 45;
                    case AquariusIceFlavor.BlueRaspberry:
                    case AquariusIceFlavor.Strawberry:
                        return 170;
                    default:
                        throw new NotImplementedException($"Unknown Flavor {Flavor}");
                }
            }
        }

        /// <summary>
        /// The price of this Aquarius Ice
        /// </summary>
        public override decimal Price 
        { 
            get
            {
                switch(Size)
                {
                    case Size.Small:
                        return 2.00m;
                    case Size.Medium:
                        return 2.50m;
                    case Size.Large:
                        return 3.00m;
                    default:
                        throw new NotImplementedException($"Unknown Size {Size}");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return Name;
        }

        public override IEnumerable<string> SpecialInstructions { get { return new List<string>(); } }
    }
}
