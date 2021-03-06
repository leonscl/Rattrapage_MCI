﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Rattrapage_MCI.Model.Actions;

namespace Rattrapage_MCI.Model
{
    class RoomClerk
    {

        //Propriétés
        private Thread roomClerkThread;
        private StockRoom stockRoom;
        private List<Actions> toDoRoomClerk = null;
        private actionDelegate theDelagate;

        //constructeur
        public RoomClerk()
        {
            ToDoRoomClerk = new List<Actions>();
            RoomClerkThread = new Thread(RoomClerkWorkThread);
            RoomClerkThread.Start();

        }


        //thread du commis de salle
        public void RoomClerkWorkThread()
        {
            Console.WriteLine("Commis de salle prets");
            while (true)
            {
                if (ToDoRoomClerk.Count != 0)
                {
                    theDelagate = ToDoRoomClerk.First().MyFunctionDelegate;
                    theDelagate(ToDoRoomClerk.First().Group);
                    ToDoRoomClerk.Remove(ToDoRoomClerk.First());
                }
                Thread.Sleep(5000);
            }
        }

        //fonction pour apporter l'eau et le pain sur la table
        public void BringWaterBread(CustomerGroup group)
        {
            Move("attente", "stock pain et eau");
            //retirer pain et eau du stock
            Room.Instance.StockRoom.BottleQuantity--;
            Room.Instance.StockRoom.BreadQuantity--;

            Move("stock pain et eau", "Table client");

            //ajouter sur la table
            group.Table.Bottle++;
            group.Table.Bread++;

            Console.WriteLine("Commis de salle : pain et eau mis");
            Move("Table client", "attente");

        }

        //fonction pour retirer le pain et l'eau
        public void ClearWaterBread(CustomerGroup group)
        {
            Move("attente", "table client");
            //retirer de la table
            group.Table.Bottle--;
            group.Table.Bread--;

            Move("Table client", "stock pain et eau");
            //remmettre pain et eau dans le stock
            Room.Instance.StockRoom.BottleQuantity++;
            Room.Instance.StockRoom.BreadQuantity++;

            Console.WriteLine("Commis de salle : pain et eau enlevé");
            Move("stock pain et eau", "Attente");

            //Ajout de l'action à la toDoliste pour le rankChief
            actionDelegate myActionDelegate = new actionDelegate(group.Table.TheSquare.RankChief.SetTable);
            Actions toDo = new Actions(myActionDelegate, group);
            group.Table.TheSquare.RankChief.ToDoRankChief.Add(toDo);

        }

        public void Move(string depart, string arrivée)
        {
            Console.WriteLine("Le commis de salle se déplace de " + depart + " vers " + arrivée);
        }

        //getter et setter
        internal StockRoom StockRoom { get => stockRoom; set => stockRoom = value; }
        public Thread RoomClerkThread { get => roomClerkThread; set => roomClerkThread = value; }
        internal List<Actions> ToDoRoomClerk { get => toDoRoomClerk; set => toDoRoomClerk = value; }
    }
}
