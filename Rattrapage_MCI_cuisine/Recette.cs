using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rattrapage_MCI_cuisine
{
    class Recette
    {
        /// <summary>
        /// ID of the recipe
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the recipe
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Preparation time of the recipe
        /// </summary>
        public float PrepTime { get; set; }

        /// <summary>
        /// Type of the recipe
        /// </summary>  
        public RecipeType Type { get; set; }

        /// <summary>
        /// List of the recipe's steps
        /// </summary>
        public List<Etape> Steps { get; set; }

        public Recette()
        {
        }
    }
}
