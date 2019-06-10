using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Rattrapage_MCI.Model.Actions;

namespace Rattrapage_MCI.Model
{
    class CustomerGroup
    {

        //Propriétés
        private int idCustomer;
        private static int idCustomerTrack = 0;

        private string stateGroup;
        private Dish currentMeal = null;

        private Thread groupThread;

        private int customerNumber;
        private Table table = null;
        private Order order = null;

        private List<string> entriees = null;
        private List<string> plats = null;
        private List<string> deserts = null;

        private bool canbeDeleted = false;

        //Constructeur
        public CustomerGroup()
        {
            IdCustomer = IdCustomerTrack;
            
            Random rand = new Random();
            CustomerNumber = rand.Next(2, 11);

            Entriees = new List<string>();
            Plats = new List<string>();
            Deserts = new List<string>();

            groupThread = new Thread(CustomerGroupThread);
            groupThread.Start();
            /*Console.WriteLine("Thread Group de clients " + IdCustomer);*/

            IdCustomerTrack++;
        }

        //thread du Groupe de clients
        public void CustomerGroupThread()
        {
            try
            {
                Console.WriteLine("Thread Group de clients " + IdCustomer);
                while (true)
                {
                    switch (StateGroup)
                    {
                        case "paid":
                            Paid();
                            Console.WriteLine("state paid pour le groupe " + IdCustomer);
                            break;

                        case "waiting":
                            Console.WriteLine("Les Clients du groupe " + IdCustomer + " sont en attente");
                            Thread.Sleep(6000);
                            break;

                        case "ordering":
                            Console.WriteLine("Les Clients du groupe " + IdCustomer + ": On refléchie");
                            ChooseOrder(Room.Instance.Card);
                            Thread.Sleep(3000);
                            break;

                        case "eating":
                            Console.WriteLine("Les Clients du groupe " + IdCustomer + " mangent");
                            Eat();
                            break;

                        case "waitingRid":
                            Console.WriteLine("Les Clients du groupe " + IdCustomer + " sont en attente de débarasser le plat");
                            Thread.Sleep(5000);
                            break;

                        case "cash out":
                            CashOut();
                            break;

                        case "waitingPay":
                            Console.WriteLine("Les Clients du groupe " + IdCustomer + " sont en attente de payer");
                            Thread.Sleep(5000);
                            break;
                    }
                    Thread.Sleep(1000);

                }
            }
            catch (ThreadAbortException)
            {
                Console.WriteLine("Les Clients du groupe " + IdCustomer + " sont partis ");
            }


        }

        //méthode pour choisir ce qu'ils vont manger (rand pour simuler des choix différents)
        public void ChooseOrder(Card card)
        {
            Random rand = new Random();

            for (int i = 0 ; i<= CustomerNumber; i++)
            {
                Entriees.Add(card.Entriees[rand.Next(0, 3)]);
                Plats.Add(card.Plats[rand.Next(0, 3)]);
                Deserts.Add(card.Deserts[rand.Next(0, 3)]);
            }

            StateGroup = "OrderComplete";

            Console.WriteLine("Groupe n°" + table.IdTable + " veut commander");

            //Ajout de l'action à la toDoliste pour le rankChief
            actionDelegate myActionDelegate = new actionDelegate(Table.TheSquare.RankChief.TakeOrder);
            Actions toDo = new Actions(myActionDelegate, this);
            Table.TheSquare.RankChief.ToDoRankChief.Add(toDo);
        }


        //méthode en cour de création
        public void Eat()
        {
            //Thread.Sleep(5000);

            if (CurrentMeal.TypeDish == "entrees")
            {
                Console.WriteLine("Le groupe n°" + IdCustomer + " mange son " + CurrentMeal.TypeDish);
                Thread.Sleep(15000);
                StateGroup = "waitingRid";
            }
            else if (CurrentMeal.TypeDish == "plats")
            {
                Console.WriteLine("Le groupe n°" + IdCustomer + " mange son " + CurrentMeal.TypeDish);
                Thread.Sleep(25000);
                StateGroup = "waitingRid";
            }
            else if (CurrentMeal.TypeDish == "desserts")
            {
                Console.WriteLine("Le groupe n°" + IdCustomer + " mange son " + CurrentMeal.TypeDish);
                Thread.Sleep(10000);
                Table.NeedCleaning = true;
                StateGroup = "cash out";
            }

            //récupérer la liste des waiters suivant le carré donc suivant où sont les clients
            //récupérer le waiter qui a la liste de chose à faire la moins grande
            List<Waiter> waiters = Table.TheSquare.Waiters;
            Waiter theWaiter = waiters.OrderBy(x => x.ToDoWaiter.Count()).First();
            //Ajout de l'action à la toDoliste pour le waiter
            actionDelegate myActionDelegate = new actionDelegate(theWaiter.RiddingDish);
            Actions toDo = new Actions(myActionDelegate, this);
            theWaiter.ToDoWaiter.Add(toDo);

        }


        public void CashOut()
        {
            Move("Table", "le HeadWaiter");
            Table.CustomerGroup = null;
            Room.Instance.WaitingPay.Groups.Add(this);
            StateGroup = "waitingPay";
        }


        public void Paid()
        {
            if(this.CanbeDeleted == true)
            {
                Table = null;
                Order = null;
                CurrentMeal = null;
                Room.Instance.WaitingPay.EndGroups.Remove(this);
                StateGroup = null;
                //Console.WriteLine("Les Clients du groupe " + IdCustomer + " sont partis");
                groupThread.Abort(this);

            }
            Console.WriteLine("paid a été activé pour le groupe " + IdCustomer);
        }

        public void Move(string depart, string arrivée)
        {
            Console.WriteLine("je me déplace de " + depart + " vers " + arrivée);
        }

        //getter et setter
        public int CustomerNumber { get => customerNumber; set => customerNumber = value; }
        public int IdCustomer { get => idCustomer; set => idCustomer = value; }
        internal Table Table { get => table; set => table = value; }
        public static int IdCustomerTrack { get => idCustomerTrack; set => idCustomerTrack = value; }
        public string StateGroup { get => stateGroup; set => stateGroup = value; }
        
        public List<string> Entriees { get => entriees; set => entriees = value; }
        public List<string> Plats { get => plats; set => plats = value; }
        public List<string> Deserts { get => deserts; set => deserts = value; }
        internal Order Order { get => order; set => order = value; }
        internal Dish CurrentMeal { get => currentMeal; set => currentMeal = value; }
        public bool CanbeDeleted { get => canbeDeleted; set => canbeDeleted = value; }
    }
}
