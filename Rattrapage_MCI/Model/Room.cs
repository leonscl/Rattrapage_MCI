using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rattrapage_MCI.Model
{
    class Room
    {
        private Square square1;
        private Square square2;

        private RoomClerk roomClerk;

        private HeadWaiter headWaiter;

        public Room()
        {
            Square Square1 = new Square(1);
            Square Square2 = new Square(2);

            HeadWaiter = new HeadWaiter();

            RoomClerk = new RoomClerk();

        }


        internal RoomClerk RoomClerk { get => roomClerk; set => roomClerk = value; }
        internal Square Square1 { get => square1; set => square1 = value; }
        internal Square Square2 { get => square2; set => square2 = value; }
        internal HeadWaiter HeadWaiter { get => headWaiter; set => headWaiter = value; }
    }
}
