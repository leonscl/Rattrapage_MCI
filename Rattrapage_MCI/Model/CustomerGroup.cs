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
        private int idCustomer;
        private static int idCustomerTrack = 0;

        private Thread groupThread;

        private int customerNumber;
        private Table table = null;

        //Constructeur
        public CustomerGroup(int numberCustomers)
        {
            IdCustomer = idCustomerTrack;
            idCustomerTrack++;

            CustomerNumber = numberCustomers;

            groupThread = new Thread(CustomerGroupThread);
            groupThread.Start();
            Console.WriteLine("Thread Group de clients");

        }

        //thread du Groupe de clients
        public static void CustomerGroupThread()
        {
            while (true)
            {

            }

        }

        public int CustomerNumber { get => customerNumber; set => customerNumber = value; }
        public int IdCustomer { get => idCustomer; set => idCustomer = value; }
        internal Table Table { get => table; set => table = value; }
    }
}
