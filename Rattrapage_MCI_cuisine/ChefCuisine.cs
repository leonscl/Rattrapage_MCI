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
        
        public List<ChefPartie> Cookers { get; set; }

        private Couvert fork;
        private Couvert knife;
        private Couvert spoon;

        private Verre glass_entry;
        private Verre glass_water;
        private Verre glass_wine;

        private Assiette plate_entry;
        private Assiette plate_main;
        private Assiette plate_dessert;

        private Plongeur plongeur;
        private ChefPartie chefPartie1;
        private ChefPartie chefPartie2;
        private CommisCuisine commisCuisine;

        //Propriétés
        private Thread chefCuisineThread;


        public ChefCuisine()
        {
            Ingredient ToDoAll = new Ingredient(200, ConservationIgr.AMBIANT);

            Fork = new Couvert(200, TypeCouvert.fourchette);
            Knife = new Couvert(200, TypeCouvert.couteau);
            Spoon = new Couvert(200, TypeCouvert.cuilliereCafe);

            Glass_entry = new Verre(50, TypeVerre.verre_champagne);
            Glass_water = new Verre(50, TypeVerre.verre_eau);
            Glass_wine = new Verre(50, TypeVerre.verre_vin);

            Plate_entry = new Assiette(50, TypeAssiette.petite);
            Plate_main = new Assiette(50, TypeAssiette.plate);
            Plate_dessert = new Assiette(50, TypeAssiette.dessert);
            Console.WriteLine("Matériel prêt");

            ChefCuisineThread = new Thread(ChefCuisineWorkThread);
            ChefCuisineThread.Start();

            Plongeur = new Plongeur();
            ChefPartie1 = new ChefPartie(1);
            ChefPartie2 = new ChefPartie(2);
            commisCuisine = new CommisCuisine();


        }

        private Order order;
        private List<Order> liste_commande;


        //thread du Chef de cuisine
        public void ChefCuisineWorkThread()
        {
            Console.WriteLine("Le thread Chef de cuisine prêt");
            while (true)
            {
                //Récupération de la liste des Commandes envoyées 
                Liste_commande = Kitchen.Instance.CounterOrder.ListOrders;

                if (Liste_commande.Count() > 0)
                {
                    Console.WriteLine("Chef Cuisine : Commande reçue");
                    Order = Liste_commande.First();
                    Thread.Sleep(2000);
                    if (ChefPartie1.IsAvailable == true)
                    {
                        commisCuisine.PrepareStep();
                        ChefPartie1.PrepareReady(Order);
                        Console.WriteLine("ChefPartie1 s'occupe de la commande");
                    }

                    else if (ChefPartie2.IsAvailable == true)
                    {
                        commisCuisine.PrepareStep();
                        ChefPartie2.PrepareReady(Order);
                        Console.WriteLine("ChefPartie2 s'occupe de la commande");
                    }

                    Liste_commande.Remove(Order);
                }
                Thread.Sleep(3000);
            }

        }



        //prend en compte une commande et assigne au chef de partie
        public void CarryOrder()
        {
            Liste_commande = Kitchen.Instance.CounterOrder.ListOrders;

            if (Liste_commande != null)
            {
                Console.WriteLine("Chef Cuisine : Commande reçue");
                Order = Liste_commande.First();
                Thread.Sleep(2000);
                if (ChefPartie1.IsAvailable == true)
                {
                    commisCuisine.PrepareStep();
                    ChefPartie1.PrepareReady(Order);
                    Console.WriteLine("ChefPartie1 s'occupe de la commande");
                }
                
                else if (ChefPartie2.IsAvailable == true)
                {
                    commisCuisine.PrepareStep();
                    ChefPartie2.PrepareReady(Order);
                    Console.WriteLine("ChefPartie2 s'occupe de la commande");
                }
                
                Liste_commande.Remove(Order);
            }

        }

        internal Order Order { get => order; set => order = value; }
        internal List<Order> Liste_commande { get => liste_commande; set => liste_commande = value; }
        internal Couvert Fork { get => fork; set => fork = value; }
        internal Couvert Knife { get => knife; set => knife = value; }
        internal Couvert Spoon { get => spoon; set => spoon = value; }
        internal Verre Glass_entry { get => glass_entry; set => glass_entry = value; }
        internal Verre Glass_water { get => glass_water; set => glass_water = value; }
        internal Verre Glass_wine { get => glass_wine; set => glass_wine = value; }
        internal Assiette Plate_entry { get => plate_entry; set => plate_entry = value; }
        internal Assiette Plate_main { get => plate_main; set => plate_main = value; }
        internal Assiette Plate_dessert { get => plate_dessert; set => plate_dessert = value; }
        internal Plongeur Plongeur { get => plongeur; set => plongeur = value; }
        internal ChefPartie ChefPartie1 { get => chefPartie1; set => chefPartie1 = value; }
        internal ChefPartie ChefPartie2 { get => chefPartie2; set => chefPartie2 = value; }
        internal CommisCuisine CommisCuisine { get => commisCuisine; set => commisCuisine = value; }
        public Thread ChefCuisineThread { get => chefCuisineThread; set => chefCuisineThread = value; }
    }
}
