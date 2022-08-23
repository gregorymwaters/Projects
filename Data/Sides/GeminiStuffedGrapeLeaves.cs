using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GyroScope.Data.Enums;
using System.ComponentModel;

namespace GyroScope.Data.Sides
{
    public class GeminiStuffedGrapeLeaves : Side, INotifyPropertyChanged, IMenuItem
    {
        /// <summary>
        /// Establishing and initializing private backing
        /// variables for the class
        /// </summary>
        /// 
        private string name = "Gemini Stuffed Grape Leaves";
        /// <summary>
        /// The default Size of Gemini Stuffed Grape Leaves
        /// </summary>
        private Size size = Size.Small;

        /// <summary>
        /// Public facing getters and setters
        /// </summary>


        /// <summary>
        /// The Size of Gemini Stuffed Grape Leaves
        /// </summary>
        public override Size Size
        {
            get { return size; }
            set { size = value; PropertyChanged?.Invoke(Size, new PropertyChangedEventArgs("Size Changed")); }
        }

        /// <summary>
        /// The Price of Gemini Stuffed Grape Leaves
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
        /// The Calories of Gemini Stuffed Grape Leaves
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return 360;
                    case Size.Medium:
                        return 540;
                    case Size.Large:
                        return 720;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

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
