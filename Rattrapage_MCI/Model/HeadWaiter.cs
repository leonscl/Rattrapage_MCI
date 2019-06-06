using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Rattrapage_MCI.Model.Actions;

namespace Rattrapage_MCI.Model
{
    class HeadWaiter
    {

        //Propriétés
        private Thread headWaiterThread;

        private static List<CustomerGroup> groupCustomer;

        private List<string> toDo = null;

        //constructeur
        public HeadWaiter()
        {

            headWaiterThread = new Thread(HeadwaiterWorkThread);
            headWaiterThread.Start();

        }

        //thread du headWaiter
        public void HeadwaiterWorkThread()
        {
            Console.WriteLine("Thread HeadWaiter pret");
            while (true)
            {
                //récupération de la liste des groupe dans la file d'attente
                GroupCustomer = WaitingLine.Groups;

                if (GroupCustomer == null)
                {
                    Thread.Sleep(1000);
                }
                else if(GroupCustomer.Count > 0)
                {
                    CustomerGroup group = GroupCustomer.First();
                    PlaceCustomerGroup(group, Room.Instance);
                    WaitingLine.Groups.Remove(group);
                    Thread.Sleep(5000);
                }
                else
                {
                    Thread.Sleep(1000);
                }

            }

        }

        //fonction pour donner une table à un client
        public void PlaceCustomerGroup(CustomerGroup group, Room room)
        {
            Console.Write("HeadWaiter : Combien etes-vous? ");
            Console.WriteLine("Customers: nous sommes " + group.CustomerNumber);

            Predicate<Table> predicate = FindFreeTables;
            List<Table> freeTables = new List<Table>();
            freeTables.AddRange(room.Square1.Tables.FindAll(predicate));
            freeTables.AddRange(room.Square2.Tables.FindAll(predicate));

            //vérifier s'ily a encore des tables, si oui placer les clients à la table
            if (freeTables.Count == 0)
            {
                Console.WriteLine("Pas de table libre");
                GroupCustomer.Remove(group);
            }
            else
            {
                List<Table> removeTable = new List<Table>();
                //trouver tables libres et tables trop petites
                foreach (Table table in freeTables)
                {
                    //afficher les tables libres
                    Console.WriteLine("Table " + table.IdTable + " libre " + " avec " + table.NumberPlace + " places.");
                    //trouver les tables trop petites
                    if (table.NumberPlace < group.CustomerNumber)
                    {
                        Console.WriteLine("Table " + table.IdTable + " est trop petite ");
                        removeTable.Add(table);
                    }
                }
                // supprimer les tables trop petites
                foreach (Table table in removeTable)
                {
                    freeTables.Remove(table);
                }

                if (freeTables.Count == 0)
                {
                    Console.WriteLine("Plus de table libre (pas assez de place)");
                    GroupCustomer.Remove(group);
                }
                else
                {
                    // on prend la première table de la liste de tables trié par le nombre de places
                    Table TableGroupe = freeTables.OrderBy(o => o.NumberPlace).First();

                    //On met la table comme occupée
                    TableGroupe.Occupied = true;

                    //on assigne la table au groupe
                    group.Table = TableGroupe;
                    //le groupe attend le chef de rang
                    group.StateGroup = "waiting";

                    //Ajout de l'action à la toDoliste pour le rankChief
                    actionDelegate myActionDelegate = new actionDelegate(TableGroupe.TheSquare.RankChief.PlaceGroup);
                    Actions toDo = new Actions(myActionDelegate, group);
                    TableGroupe.TheSquare.RankChief.ToDoRankChief.Add(toDo);

                    Console.WriteLine("je place mon groupe sur la table " + TableGroupe.IdTable + " avec " + TableGroupe.NumberPlace + " places.");
                }
            }
        }

        //pour trouver les tables libres (utilisé dans PlaceCustomerGroup)
        private bool FindFreeTables(Table table)
        {
            return table.Occupied == false;
        }

        //Faire payer les clients
        public void paidGroup()
        {
            //a faire
        }

        //get et set
        public List<string> ToDo { get => toDo; set => toDo = value; }
        internal static List<CustomerGroup> GroupCustomer { get => groupCustomer; set => groupCustomer = value; }
    }
}
