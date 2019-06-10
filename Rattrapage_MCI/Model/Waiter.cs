﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Rattrapage_MCI.Model.Actions;

namespace Rattrapage_MCI.Model
{
    class Waiter
    {

        //propriétés
        private Thread waiterThread;
        private int id;
        private static int idTrack = 0;
        private List<Actions> toDoWaiter = null;
        private actionDelegate theDelagate;

        //Constructeur
        public Waiter()
        {
            Id = IdTrack;

            ToDoWaiter = new List<Actions>();

            WaiterThread = new Thread(WaiterWorkThread);
            WaiterThread.Start();

            Console.WriteLine("Thread Waiter pret" + Id);

            IdTrack++;
        }

        //thread du RankChief
        public void WaiterWorkThread()
        {
            while (true)
            {

                if (ToDoWaiter.Count != 0)
                {
                    theDelagate = ToDoWaiter.First().MyFunctionDelegate;
                    theDelagate(ToDoWaiter.First().Group);
                }
                Thread.Sleep(1000);
            }
            

        }


        public void ServeClient(CustomerGroup group)
        {
            if (group.StateGroup == "waiting")
            {
                Dish dish = group.Order.WaitingDish.First();
                Move("attente", "comptoire");
                Room.Instance.CounterDishes.WaitingDishs.Remove(dish);
                Move("comptoire", "Table des clients");
                Console.WriteLine("Voici les " + dish.TypeDish);
                group.CurrentMeal = dish;
                group.Order.WaitingDish.Remove(dish);
                Move("Table client", "attente");
                ToDoWaiter.Remove(ToDoWaiter.First());
                group.StateGroup = "eating";
            }
            else
            {
                Actions toDo = ToDoWaiter.First();
                ToDoWaiter.Remove(toDo);
                ToDoWaiter.Add(toDo);
            }
           
        }

        public void RiddingDish(CustomerGroup group)
        {
            
            if (group.Table.NeedCleaning == true)
            {
                Move("attente", "Table Client");
                Console.WriteLine("Waiter : Je débarasse les plats");
                Dish theDish = group.CurrentMeal;
                group.CurrentMeal = null;
                Move("Table Client", "CounterPlate");
                Room.Instance.CounterPlate.Dishes.Add(theDish);
                Move("CounterPlate", "Attente");
                ToDoWaiter.Remove(ToDoWaiter.First());

                //Ajout de l'action à la toDoliste pour le RoomClerk
                actionDelegate myActionDelegate = new actionDelegate(Room.Instance.RoomClerk.ClearWaterBread);
                Actions toDo = new Actions(myActionDelegate, group);
                Room.Instance.RoomClerk.ToDoRoomClerk.Add(toDo);
            }
            if (group.StateGroup == "waitingRid")
            {
                Move("attente", "Table Client");
                Console.WriteLine("Waiter : Je débarasse les plats");
                Dish theDish = group.CurrentMeal;
                group.CurrentMeal = null;
                group.StateGroup = "waiting";
                Move("Table Client", "CounterPlate");
                Room.Instance.CounterPlate.Dishes.Add(theDish);
                Move("CounterPlate", "Attente");
                ToDoWaiter.Remove(ToDoWaiter.First());
            }
  
        }


        public void CleanTable(CustomerGroup group)
        {
            //Aller a la Table
            group.StateGroup = "waitingMeal";
        }


        public void Move(string depart, string arrivée)
        {
            Console.WriteLine("je me déplace de " + depart + " vers " + arrivée);
        }

        //getter et setter
        public int Id { get => id; set => id = value; }
        public static int IdTrack { get => idTrack; set => idTrack = value; }
        public Thread WaiterThread { get => waiterThread; set => waiterThread = value; }
        internal List<Actions> ToDoWaiter { get => toDoWaiter; set => toDoWaiter = value; }
    }
}
