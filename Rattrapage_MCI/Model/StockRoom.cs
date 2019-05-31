using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rattrapage_MCI.Model
{
    class StockRoom
    {
        private int bottleQuantity;
        private int breadQuantity;

        public StockRoom(int bread, int bottle)
        {
            BottleQuantity = bottle;
            BreadQuantity = bread;
        }

        public int BottleQuantity { get => bottleQuantity; set => bottleQuantity = value; }
        public int BreadQuantity { get => breadQuantity; set => breadQuantity = value; }

    }
}
