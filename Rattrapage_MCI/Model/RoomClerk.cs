using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rattrapage_MCI.Model
{
    class RoomClerk
    {

        private Thread roomClerkThread;

        private StockRoom stockRoom;


        public RoomClerk()
        {
            stockRoom = new StockRoom(40, 40);

            roomClerkThread = new Thread(RoomClerkWorkThread);
            roomClerkThread.Start();

        }

        public static void RoomClerkWorkThread()
        {
            while (true)
            {
                //chek sa liste et fait
            }
        }

        public void BringWaterBread()
        {
            //retirer pain et eau du stock
            stockRoom.BottleQuantity--;
            stockRoom.BreadQuantity--;

        }

        public void ClearWaterBread()
        {

        }

    }
}
