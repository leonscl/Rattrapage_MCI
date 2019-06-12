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

        //constructeur
        public HeadWaiter()
        {
            headWaiterThread = new Thread(HeadwaiterWorkThread);
            headWaiterThread.Start();

        }

        //thread du headWaiter
        public void HeadwaiterWorkThread()
        {
            Console.WriteLine("Le thread Maître d'hôtel prêt");
            while (true)
            {
                //récupération de la liste des groupe dans la file d'attente
                List<CustomerGroup> groupCustomer = Room.Instance.WaitLine.Groups;
                //Récupération de la file d'attente des customers qui veulent payer
                List<CustomerGroup> customerWantPay = Room.Instance.WaitingPay.Groups;

                if (groupCustomer.Count > 0)
                {
                    CustomerGroup group = groupCustomer.First();
                    PlaceCustomerGroup(groupCustomer, group, Room.Instance);
                    Room.Instance.WaitLine.Groups.Remove(group);
                }
                if (customerWantPay.Count > 0)
                {
                    CustomerGroup group = customerWantPay.First();
                    PaidGroup(group);
                    Room.Instance.WaitingPay.Groups.Remove(group);
                }

                Thread.Sleep(2000);
            }

        }

        //fonction pour donner une table à un client
        public void PlaceCustomerGroup(List<CustomerGroup> groupCustomer, CustomerGroup group, Room room)
        {
            Console.Write("Maître d'hôtel : Bonjour ! Combien etes-vous ? ");
            Console.WriteLine("Clients : nous sommes " + group.CustomerNumber);

            Predicate<Table> predicate = FindFreeTables;
            List<Table> freeTables = new List<Table>();
            freeTables.AddRange(room.Square1.Tables.FindAll(predicate));
            freeTables.AddRange(room.Square2.Tables.FindAll(predicate));

            //vérifier s'ily a encore des tables, si oui placer les clients à la table
            if (freeTables.Count == 0)
            {
                Console.WriteLine("Maître d'hôtel : Plus de table libre");
                groupCustomer.Remove(group);
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
                        Console.WriteLine("La table " + table.IdTable + " est trop petite ");
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
                    Console.WriteLine("Maître d'hôtel : Je suis désollé mais il n'y a plus de table libre (pas assez de place)");
                    groupCustomer.Remove(group);
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

                    Console.WriteLine("Maître d'hôtel : je place mon groupe" + group.IdCustomer + "sur la table " + TableGroupe.IdTable + " avec " + TableGroupe.NumberPlace + " places.");
                }
            }
        }

        //pour trouver les tables libres (utilisé dans PlaceCustomerGroup)
        private bool FindFreeTables(Table table)
        {
            return table.Occupied == false;
        }

        //Faire payer les clients
        public void PaidGroup(CustomerGroup group)
        {
            Console.WriteLine("Maître d'hôtel : Vous devez payer " + group.Order.Price + " euros");
            Console.WriteLine("Le groupe " + group.IdCustomer + " paye");
            group.StateGroup = "paid";
            Console.WriteLine("Maître d'hôtel : Je vous souhaite une bonne journée en espérant que vous avez apréciez notre restaurant !");
            Room.Instance.CurrentOrders.Remove(group.Order);
            Room.Instance.WaitingPay.EndGroups.Add(group);
        }

    }
}
