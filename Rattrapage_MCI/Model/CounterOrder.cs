using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rattrapage_MCI.Model
{
    class CounterOrder
    {
        private List<Order> orders;

        public CounterOrder()
        {
            Orders = new List<Order>();

        }

        internal List<Order> Orders { get => orders; set => orders = value; }
    }
}
