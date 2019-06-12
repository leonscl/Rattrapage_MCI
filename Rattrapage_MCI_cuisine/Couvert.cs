using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rattrapage_MCI_cuisine
{
    class Couvert
    {
        public int quantity_couvert;
        public Couvert(int quantity, TypeCouvert type) {
            this.quantity_couvert = quantity;
        }

        public int Quantity_couvert { get => quantity_couvert; set => quantity_couvert = value; }
    }
}
