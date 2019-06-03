using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rattrapage_MCI.Model
{
    class Waiter
    {

        //propriétés
        private Thread waiterThread;
        private int id;
        private static int idTrack = 0;

        //Constructeur
        public Waiter()
        {
            Id = IdTrack;

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

            }

        }

        //getter et setter
        public int Id { get => id; set => id = value; }
        public static int IdTrack { get => idTrack; set => idTrack = value; }
        public Thread WaiterThread { get => waiterThread; set => waiterThread = value; }
    }
}
