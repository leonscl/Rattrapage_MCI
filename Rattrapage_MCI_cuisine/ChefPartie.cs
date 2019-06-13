using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rattrapage_MCI_cuisine
{
    class ChefPartie
    {
        /// Identification du chef de partie
        public int Id { get; set; }

        /// Disponibilité
        public bool IsAvailable { get; set; }

        /// Tools manager to lease tools
        public ToolsManager ToolsStorage { get; set; }
        //public List<string> CounterDishes { get => counterDishes; set => counterDishes = value; }

        /// instanciation du chef de de partie
        public ChefPartie(int id)
        {
            this.Id = id;
            this.ToolsStorage = ToolsManager.GetInstance();
            this.IsAvailable = true;
        }

        //private List<string> counterDishes;

        public void PrepareReady(Order order)
        {
            IsAvailable = false;

            DishReady dishReady1 = new DishReady(order.IdOrder, "entrees");
            DishReady dishReady2 = new DishReady(order.IdOrder, "plats");
            DishReady dishReady3 = new DishReady(order.IdOrder, "desserts");


            Kitchen.Instance.CounterDishes.DishReadies.Add(dishReady1);
            Kitchen.Instance.CounterDishes.DishReadies.Add(dishReady2);
            Kitchen.Instance.CounterDishes.DishReadies.Add(dishReady3);

            Thread.Sleep(1000);

            Console.WriteLine("Commande prête");
            this.IsAvailable = true;
        }

        /// Lease the differents tools needed for a specific step
        private bool LeaseNeededTools(List<Outil> tools)
        {
            foreach (var item in tools)
            {
                Stopwatch s = new Stopwatch();
                s.Start();
                while (s.Elapsed < TimeSpan.FromSeconds(5))
                {
                    if (this.ToolsStorage.LeaseTool(item))
                    {
                        item.IsAvailable = true;
                        break;
                    }
                }
                s.Stop();
            }
            return tools.All(tool => tool.IsAvailable);
        }

        
    }
}

