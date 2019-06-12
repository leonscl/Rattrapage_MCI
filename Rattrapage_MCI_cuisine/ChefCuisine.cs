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

        public ChefCuisine()
        {
            Ingredient ToDoAll = new Ingredient(200, ConservationIgr.AMBIANT);

            Couvert fork = new Couvert(200, TypeCouvert.fourchette);
            Couvert knife = new Couvert(200, TypeCouvert.couteau);
            Couvert spoon = new Couvert(200, TypeCouvert.cuilliereCafe);

            Verre glass_entry = new Verre(50, TypeVerre.verre_champagne);
            Verre glass_water = new Verre(50, TypeVerre.verre_eau);
            Verre glass_wine = new Verre(50, TypeVerre.verre_vin);

            Assiette plate_entry = new Assiette(50, TypeAssiette.petite);
            Assiette plate_main = new Assiette(50, TypeAssiette.plate);
            Assiette plate_dessert = new Assiette(50, TypeAssiette.dessert);
            Console.WriteLine("Matériel prêt");

            Plongeur plongeur = new Plongeur();
        }

        private List<Order> liste_commande;
        public void CarryOrder()
        {
            liste_commande = Kitchen.Instance;
            this.liste_commande.First();

        }

        /// <summary>
        /// Prepare a recipe
        /// </summary>
        /// <param name="recipe">The recipe to prepare</param>
        private void PrepareDish(Dish dish)
        {
            Console.WriteLine("Début de la préparation du plat");
            
            DishReady readyToEat = new DishReady();
        }

        private ChefPartie ElectCooker()
        {
            lock (LockCookers)
            {
                foreach (var cooker in this.Cookers)
                {
                    if (cooker.IsAvailable) return cooker;
                }
                return null;
            }
        }
        public void ChefCuisineWorkThread()
        {
            Console.WriteLine("Thread Chef Cuisine prêt");
            while (true)
            {
                //récupération des commandes des groupe
                List<Order> groupCustomer = Order.Entriees.WaitLine.Groups;
                
                if (groupCustomer.Count > 0)
                {
                    CustomerGroup group = groupCustomer.First();
                    PlaceCustomerGroup(groupCustomer, group, Room.Instance);
                    Room.Instance.WaitLine.Groups.Remove(group);
                }

                Thread.Sleep(2000);
            }

        }
    }
}
