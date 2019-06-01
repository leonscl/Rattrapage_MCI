using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rattrapage_MCI.Model
{
    class Order
    {
        //Propriétés
        private int idOrder;
        private static int idIncrementor = 0;
        private CustomerGroup customerGroup;
        private List<string> plats;

        //constructeur
        public Order(CustomerGroup group, List<string> dishs)
        {
            IdOrder = IdIncrementor;
            IdIncrementor++;

            CustomerGroup = group;

            plats = dishs;

            Console.WriteLine("La commande " + IdOrder + " a été faite.");
        }

        //get et set
        public List<string> Plats { get => plats; set => plats = value; }
        public int IdOrder { get => idOrder; set => idOrder = value; }
        internal CustomerGroup CustomerGroup { get => customerGroup; set => customerGroup = value; }
        public static int IdIncrementor { get => idIncrementor; set => idIncrementor = value; }
    }
}
