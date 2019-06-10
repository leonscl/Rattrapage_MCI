using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rattrapage_MCI.Model
{
    class WaitingPay
    {
        //propriétés
        private List<CustomerGroup> groups;
        private List<CustomerGroup> endGroups;


        public WaitingPay()
        {
            Groups = new List<CustomerGroup>();
            EndGroups = new List<CustomerGroup>();
        }

        internal List<CustomerGroup> Groups { get => groups; set => groups = value; }
        internal List<CustomerGroup> EndGroups { get => endGroups; set => endGroups = value; }
    }
}
