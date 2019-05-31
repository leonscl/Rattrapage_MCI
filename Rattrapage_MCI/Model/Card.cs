using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rattrapage_MCI.Model
{
    class Card
    {

        private int cardQuantity;

        private List<string> entriees;
        private List<string> plats;
        private List<string> deserts;

        //constructeur
        public Card(int quantity)
        {
            cardQuantity = quantity;

            entriees = new List<string> { "salade", "oeuf mimosa", "foi gras" };
            plats = new List<string> { "tagliatelles carbonara", "steack", "poulet roti" };
            deserts = new List<string> { "creme brulée", "glace vanille", "tarte tatin" };

        }

        public int CardQuantity { get => cardQuantity; set => cardQuantity = value; }
        public List<string> Entriees { get => entriees; set => entriees = value; }
        public List<string> Plats { get => plats; set => plats = value; }
        public List<string> Deserts { get => deserts; set => deserts = value; }
    }
}
