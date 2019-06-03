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
        private Table table;
        private List<string> entriees;
        private List<string> plats;
        private List<string> deserts;

        //constructeur
        public Order(CustomerGroup group)
        {
            IdOrder = IdIncrementor;
            IdIncrementor++;

            CustomerGroup = group;
            Table = group.Table;

            Entriees = group.Entriees;
            Plats = group.Plats;
            Deserts = group.Deserts;

            Console.WriteLine("La commande " + IdOrder + " a été faite.");
        }

        //get et set
        public List<string> Plats { get => plats; set => plats = value; }
        public int IdOrder { get => idOrder; set => idOrder = value; }
        internal CustomerGroup CustomerGroup { get => customerGroup; set => customerGroup = value; }
        public static int IdIncrementor { get => idIncrementor; set => idIncrementor = value; }
        internal Table Table { get => table; set => table = value; }
        public List<string> Entriees { get => entriees; set => entriees = value; }
        public List<string> Deserts { get => deserts; set => deserts = value; }
    }
}
