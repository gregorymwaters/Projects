using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GyroScope.Data.Entrees;
using GyroScope.Data.Drinks;
using GyroScope.Data.Sides;
using GyroScope.Data.Treats;

namespace GyroScope.Data
{
    public static class Menu
    {

        public static List<IMenuItem> Entrees { get; }
        public static List<IMenuItem> Drinks { get; }
        public static List<IMenuItem> Sides { get; }
        public static List<IMenuItem> Treats { get; }

        public static List<IMenuItem> FullMenu { get; }

        static Menu()
        {
            Entrees.Add(new LeoLambGyro());
            FullMenu.Add(new LeoLambGyro());
            Entrees.Add(new PiscesFishDish());
            FullMenu.Add(new PiscesFishDish());
            Entrees.Add(new ScorpioSpicyGyro());
            FullMenu.Add(new ScorpioSpicyGyro());
            Entrees.Add(new VirgoClassicGyro());
            FullMenu.Add(new VirgoClassicGyro());

            Drinks.Add(new CapricornMountainTea());
            FullMenu.Add(new CapricornMountainTea());
            Drinks.Add(new LibraLibation());
            FullMenu.Add(new LibraLibation());

            Sides.Add(new AriesFries());
            FullMenu.Add(new AriesFries());
            Sides.Add(new GeminiStuffedGrapeLeaves());
            FullMenu.Add(new GeminiStuffedGrapeLeaves());
            Sides.Add(new SagittariusGreekSalad());
            FullMenu.Add(new SagittariusGreekSalad());
            Sides.Add(new TaurusTabuleh());
            FullMenu.Add(new TaurusTabuleh());

            Treats.Add(new AquariusIce());
            FullMenu.Add(new AquariusIce());
            Treats.Add(new CancerHalvaCake());
            FullMenu.Add(new CancerHalvaCake());
        }
    }
}
