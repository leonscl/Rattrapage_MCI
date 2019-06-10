using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static Rattrapage_MCI.Model.Actions;
using System.IO;
using System.Runtime.Serialization.Json;
using Rattrapage_MCI.Model;

namespace Rattrapage_MCI.Model
{
    class RankChief
    {
        //propriétés
        private Thread rankChiefThread;
        private int id;
        private static int idTrack = 0;
        private List<Actions> toDoRankChief = null;
        private actionDelegate theDelagate;

        //Constructeur
        public RankChief()
        {
            Id = IdTrack;

            ToDoRankChief = new List<Actions>();

            RankChiefThread = new Thread(RankChiefWorkThread);
            RankChiefThread.Start();

            IdTrack++;
        }

        //thread du RankChief
        public void RankChiefWorkThread()
        {
            Console.WriteLine("Thread RankChief pret" + Id);

            while (true)
            {
                if (ToDoRankChief.Count != 0)
                {
                    Console.WriteLine("rankchief : je suis là");
                    theDelagate = ToDoRankChief.First().MyFunctionDelegate;
                    theDelagate(ToDoRankChief.First().Group);
                    ToDoRankChief.Remove(ToDoRankChief.First());
                }
                Thread.Sleep(1000);
            }
        }



        public void PlaceGroup(CustomerGroup group)
        {
            Move("attente", "groupe de Clients");

            Console.WriteLine(" Chef de rang: suivez moi");

            Move("Groupe client", "Table");
            Table table = group.Table;
            table.CustomerGroup = group;

            //update ViewModelPersonnel

            Console.WriteLine("Table " + group.Table.IdTable + ": les clients sont installés");

            group.StateGroup = "waiting";

            GiveMenu(group);

        }

        public void GiveMenu(CustomerGroup group)
        {
            Move("Table", "Cartes");

            Room.Instance.Card.CardQuantity--;

            Move("Cartes", "table");

            Console.WriteLine("Voic la carte des menus");

            group.StateGroup = "ordering";

            Move("Table", "Attente");

        }       

        public void TakeOrder(CustomerGroup group)
        {

            Move("Attente", "Table");

            Order order = new Order(group);

            group.StateGroup = "waiting";
            Console.WriteLine("J'ai pris les commandes de la table " + group.Table.IdTable);

            //Reprendre les menus des clients et les reposer
            ReturnMenu(group);

            //Ajout de l'action à la toDoliste pour le RoomClerk
            actionDelegate myActionDelegate = new actionDelegate(Room.Instance.RoomClerk.BringWaterBread);
            Actions toDo = new Actions(myActionDelegate, group);
            Room.Instance.RoomClerk.ToDoRoomClerk.Add(toDo);

            Move("Cartes", "Comptoire de commandes");
            //On transmet la commande au Comptoir de commande
            Room.Instance.CurrentOrders.Add(order);
            Room.Instance.CounterOrder.Orders.Add(order);
            group.Order = order;

            Move("Comptoire de commandes", "Attente");
        }

        //Reprendre les menus des clients et les reposer dans la pile des cartes (utilisé dans la méthode Take Order)
        public void ReturnMenu(CustomerGroup group)
        {
            Console.WriteLine("Je reprend la carte des menus");
            Move("Table", "Cartes");
            Room.Instance.Card.CardQuantity++;
            Console.WriteLine("nombre de cartes " + Room.Instance.Card.CardQuantity);

        }


        //Préparer table après que les clients partent
        public void SetTable(CustomerGroup group)
        {
            Move("attente", "table ");
            group.Table.NeedCleaning = false;
            group.Table.Occupied = false;
            group.CanbeDeleted = true;
            Console.WriteLine("`\n La table " + group.Table.IdTable + " est prête.");
            Move("Table", "attente");
        }


        public void Move(string depart, string arrivée)
        {
            Console.WriteLine("je me déplace de " + depart + " vers " + arrivée);
        }


        //getter et setter
        public Thread RankChiefThread { get => rankChiefThread; set => rankChiefThread = value; }
        public int Id { get => id; set => id = value; }
        public static int IdTrack { get => idTrack; set => idTrack = value; }
        internal List<Actions> ToDoRankChief { get => toDoRankChief; set => toDoRankChief = value; }
    }
}
