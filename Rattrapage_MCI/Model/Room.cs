using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rattrapage_MCI.Model
{
    class Room
    {
        //Propriétés
        private Square square1;
        private Square square2;

        private RoomClerk roomClerk;

        private HeadWaiter headWaiter;

        private WaitingLine waitLine;

        private static Room instance;
        private static readonly object padlock = new object();


        //constructeur
        public Room()
        {
            Square1 = new Square(1);
            Square2 = new Square(2);

            RoomClerk = new RoomClerk();

            Console.WriteLine("Salle ouverte");

            HeadWaiter = new HeadWaiter();

            waitLine = new WaitingLine();

            Console.WriteLine("Tout est pret");
        }

        public static Room Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new Room();
                        }
                    }
                }
                return instance;
            }
        }

        //get et set
        internal RoomClerk RoomClerk { get => roomClerk; set => roomClerk = value; }
        internal Square Square1 { get => square1; set => square1 = value; }
        internal Square Square2 { get => square2; set => square2 = value; }
        internal HeadWaiter HeadWaiter { get => headWaiter; set => headWaiter = value; }
        internal WaitingLine WaitLine { get => waitLine; set => waitLine = value; }
    }
}
