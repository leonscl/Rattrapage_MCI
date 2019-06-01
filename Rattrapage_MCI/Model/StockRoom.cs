using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rattrapage_MCI.Model
{
    class StockRoom
    {
        //propriétés
        private int bottleQuantity;
        private int breadQuantity;

        //constructeur
        public StockRoom(int bread, int bottle)
        {
            BottleQuantity = bottle;
            BreadQuantity = bread;

            Console.WriteLine("Stock pret avec " + BottleQuantity + " bouteilles et  " + BreadQuantity +" pains" );
        }

        //getter et setter
        public int BottleQuantity { get => bottleQuantity; set => bottleQuantity = value; }
        public int BreadQuantity { get => breadQuantity; set => breadQuantity = value; }

    }
}
