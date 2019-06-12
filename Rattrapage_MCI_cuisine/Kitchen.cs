using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rattrapage_MCI_cuisine
{
    class Kitchen
    {
        private static Kitchen instance;
        private static readonly object padlock = new object();

        public Kitchen()
        {
            CounterOrder counter_order = new CounterOrder();
            CounterDishes counter_dishes = new CounterDishes();
            CounterPlate counter_plate = new CounterPlate();

            ChefCuisine chefCuisine = new ChefCuisine();
            Console.WriteLine("Cuisine prête");
        }

        public static Kitchen Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new Kitchen();
                        }
                    }
                }
                return instance;
            }
        }
    }
}
