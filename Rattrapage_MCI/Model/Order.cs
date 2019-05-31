using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rattrapage_MCI.Model
{
    class Order
    {
        private int idOrder;
        private static int idIncrementor = 0;
        private CustomerGroup customerGroup;
        private List<string> plats;

        public Order(CustomerGroup group, List<string> dishs)
        {
            IdOrder = IdIncrementor;
            IdIncrementor++;

            CustomerGroup = group;

            plats = dishs;

        }

        public List<string> Plats { get => plats; set => plats = value; }
        public int IdOrder { get => idOrder; set => idOrder = value; }
        internal CustomerGroup CustomerGroup { get => customerGroup; set => customerGroup = value; }
        public static int IdIncrementor { get => idIncrementor; set => idIncrementor = value; }
    }
}
