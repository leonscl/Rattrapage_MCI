using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rattrapage_MCI.Model
{
    class HeadWaiter
    {

        private Thread headWaiterThread;

        private List<Table> freeTables;

        //constructeur
        public HeadWaiter()
        {

            headWaiterThread = new Thread(HeadwaiterWorkThread);
            headWaiterThread.Start();
            Console.WriteLine("Thread headWaiter");
        }

        //thread du headWaiter
        public static void HeadwaiterWorkThread()
        {
            while (true)
            {
                
            }
            
        }

        //fonction pour donner une table à un client
        public void PlaceCustomerGroup(CustomerGroup group, Room room)
        {
            Console.Write("HeadWaiter : Combien etes-vous? ");
            Console.WriteLine("Customers: nous sommes " + group.CustomerNumber);

            Predicate<Table> predicate = FindFreeTables;
            FreeTables = new List<Table>();
            FreeTables.AddRange(room.Square1.Tables.FindAll(predicate));
            FreeTables.AddRange(room.Square2.Tables.FindAll(predicate));

            //afficher les tables libres
            foreach (Table table in FreeTables)
            {
                Console.WriteLine("Table " + table.IdTable + " libre ");
            }

            //vérifier s'ily a encore des tables, si oui placer les clients à la table
            if(FreeTables.Count == 0)
            {
                Console.WriteLine("Pas de table libre");
            }
            else
            {
                foreach(Table table in FreeTables)
                {
                    if(table.NumberPlace < group.CustomerNumber)
                    {
                        FreeTables.Remove(table);
                    }
                }
                FreeTables.OrderBy(o => o.NumberPlace);
                Table TableGroupe = FreeTables.First();
                group.Table = TableGroupe;
                TableGroupe.CustomerGroup = group;
                TableGroupe.Occupied = true;
                Console.WriteLine("je place mon groupe sur la table " + TableGroupe.IdTable);

            }

        }

        //pour trouver les tables libres (utilisé dans PlaceCustomerGroup)
        private static bool FindFreeTables(Table table)
        {
            return table.Occupied == false;
        }

        //get et set
        internal List<Table> FreeTables { get => freeTables; set => freeTables = value; }

    }
}
