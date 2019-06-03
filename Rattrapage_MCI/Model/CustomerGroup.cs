using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rattrapage_MCI.Model
{
    class CustomerGroup
    {

        //Propriétés
        private int idCustomer;
        private static int idCustomerTrack = 0;

        private string stateGroup;
        private string currentMeal;

        private Thread groupThread;

        private int customerNumber;
        private Table table = null;

        private List<string> entriees = null;
        private List<string> plats = null;
        private List<string> deserts = null;

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
            Console.WriteLine("Thread Group de clients " + IdCustomer);
            while (true)
            {
                switch (StateGroup)
                {
                    case "paid":

                        break;

                    case "waiting":
                        Console.WriteLine("Les Clients du groupe " + IdCustomer + " sont en attente");
                        Thread.Sleep(6000);
                        break;

                    case "ordering":
                        Console.WriteLine("Groupe de la Table " + Table.IdTable + ": On refléchie");
                        ChooseOrder(Room.Instance.Card);
                        Thread.Sleep(3000);
                        break;

                    case "eating":
                        Console.WriteLine("Groupe de la Table " + Table.IdTable + " mangent");
                        Eat();
                        break;

                    case "cash out":
                        cashOut();
                        break;

                }

            }

        }
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

        }

        public void Eat()
        {
            Thread.Sleep(5000);
            
            if (CurrentMeal == null)
            {
                CurrentMeal = "entry";
            }
            else if (CurrentMeal == "entry")
            {
                StateGroup = "waiting";
                CurrentMeal = "main";
            }
            else if (CurrentMeal == "main")
            {
                StateGroup = "waiting";
                CurrentMeal = "desert";
            }
            else if (CurrentMeal == "desert")
            {
                StateGroup = "cash out";
                //GroupTable.NeedCleaning = true;
            }
            else
            {
                StateGroup = "needCleaning";
            }
        }

        public void cashOut()
        {

        }



        //getter et setter
        public int CustomerNumber { get => customerNumber; set => customerNumber = value; }
        public int IdCustomer { get => idCustomer; set => idCustomer = value; }
        internal Table Table { get => table; set => table = value; }
        public static int IdCustomerTrack { get => idCustomerTrack; set => idCustomerTrack = value; }
        public string StateGroup { get => stateGroup; set => stateGroup = value; }
        public string CurrentMeal { get => currentMeal; set => currentMeal = value; }
        public List<string> Entriees { get => entriees; set => entriees = value; }
        public List<string> Plats { get => plats; set => plats = value; }
        public List<string> Deserts { get => deserts; set => deserts = value; }
    }
}
