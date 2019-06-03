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

        //Propriétés
        private Thread roomClerkThread;
        private StockRoom stockRoom;

        //constructeur
        public RoomClerk()
        {

            RoomClerkThread = new Thread(RoomClerkWorkThread);
            RoomClerkThread.Start();

        }


        //thread du commis de salle
        public void RoomClerkWorkThread()
        {
            Console.WriteLine("Commis de salle prets");
            while (true)
            {
                //chek sa liste et fait
            }
        }

        //fonction pour apporter l'eau et le pain sur la table
        public void BringWaterBread(CustomerGroup group)
        {
            //retirer pain et eau du stock
            StockRoom.BottleQuantity--;
            StockRoom.BreadQuantity--;

            //ajouter sur la table
            group.Table.Bottle++;
            group.Table.Bread++;

        }

        //fonction pour retirer le pain et l'eau
        public void ClearWaterBread(CustomerGroup group)
        {
            //retirer de la table
            group.Table.Bottle--;
            group.Table.Bread--;

            //remmettre pain et eau dans le stock
            StockRoom.BottleQuantity++;
            StockRoom.BreadQuantity++;
        }

        //getter et setter
        internal StockRoom StockRoom { get => stockRoom; set => stockRoom = value; }
        public Thread RoomClerkThread { get => roomClerkThread; set => roomClerkThread = value; }
    }
}
