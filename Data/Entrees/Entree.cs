using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace GyroScope.Data.Entrees
{
    /// <summary>
    /// A base class for Entrees sold
    /// </summary>
    public abstract class Entree : INotifyPropertyChanged, IMenuItem
    {
        ///<summary>
        /// Price of the Entree
        /// </summary>
        public abstract decimal Price { get; }

        ///<summary>
        /// Calories of the Entree
        /// </summary>
        /// 
        public abstract uint Calories { get; }

        ///<summary>
        /// List<string> of special instructions for the Entree
        /// </summary>
        /// 
        public abstract IEnumerable<string> SpecialInstructions { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public abstract string Name { get; }


    }
}
