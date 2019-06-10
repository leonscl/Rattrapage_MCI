using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rattrapage_MCI_cuisine
{
    class Ingredient
    {
        /// <summary>
        /// Ingredient id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ingredient's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Quantity available in stock
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Type of conservation 
        /// </summary>
        public ConservationIgr TypeConserv { get; set; }
    }
}
}
