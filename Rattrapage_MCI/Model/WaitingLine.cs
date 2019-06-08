using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Rattrapage_MCI.Model
{
    class WaitingLine
    {

        //propriétés
        private static List<CustomerGroup> groups;
        private Thread lineThread;

        //constructeur
        public WaitingLine()
        {
            Groups = new List<CustomerGroup>();

            lineThread = new Thread(WaitingLineThread);
            lineThread.Start();
        }

        //thread de la fille d'attente
        public void WaitingLineThread()
        {
            Console.WriteLine("Thread fille d'attente actif");

            CustomerGroup customer1 = new CustomerGroup();
            CustomerGroup customer2 = new CustomerGroup();
            CustomerGroup customer3 = new CustomerGroup();

            Groups.Add(customer1);
            Groups.Add(customer2);
            Groups.Add(customer3);

            Thread.Sleep(5000);

            while (true)
            {

                Random rand = new Random();
                int possibility = rand.Next(0,2);

                
                if (possibility == 0)
                {
                    Thread.Sleep(10000);
                }
                else
                {
                    CustomerGroup customer = new CustomerGroup();
                    Groups.Add(customer);
                    Thread.Sleep(10000);
                }
                Thread.Sleep(1000);

            }

        }

        //Getter et setter
        public Thread LineThread { get => lineThread; set => lineThread = value; }
        internal static List<CustomerGroup> Groups { get => groups; set => groups = value; }
    }
}
