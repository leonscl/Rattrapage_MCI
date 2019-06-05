using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rattrapage_MCI_cuisine
{
    class ChefCuisine
    {
        public void DispatcheTache(string Commande, int[] ChefPartie) { }
        public void RetireRecetteCarte() { }
        public void VerifieRecetteRealisable() { }

        //public Counter CounterPlate { get; set; }


        public List<ChefPartie> Cookers { get; set; }

        private readonly object LockCookers = new object();

        public ChefCuisine(int cookers, Plongeur washer, Counter counterplate = null)
        {
            // this.CounterPlate = counterplate;
            this.Cookers = new List<ChefPartie>();
            washer.StartWorking().Start();

            // Oven oven = new Oven();

            for (int i = 0; i <= cookers; i++)
            {
                this.Cookers.Add(new ChefPartie(i, washer));
            }
        }

        /* public void CarryOrder(Order cmd)
        {
            foreach (var item in cmd.Dishes)
            {
                Console.WriteLine("Ajouté un nouveau plat au threadpool");
                ThreadPool.QueueUserWorkItem(state => PrepareDish(item));
            }
        } */

        /// <summary>
        /// Prepare a recipe
        /// </summary>
        /// <param name="recipe">The recipe to prepare</param>
        private void PrepareDish(Plat dish)
        {
            Console.WriteLine("Début de la préparation du plat");
            /* foreach (var step in dish.Recipe.Steps)
            {
                ChefPartie cooker;
                { cooker = this.ElectCooker(); } while (cooker == null) ;

                if (step.Order == dish.Recipe.Steps.Count()) cooker.PrepareStep(step, dish);
                else cooker.PrepareStep(step);
            }
            if (dish.CurrentOrder.Dishes.All(o => o.Ready)) dish.CurrentOrder.Ready = true; */
        }
    }
}
