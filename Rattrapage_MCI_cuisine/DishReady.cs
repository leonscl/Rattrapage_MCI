using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rattrapage_MCI_cuisine
{
    class DishReady
    {
        private string nom;
        private TypeRecette type;
        public DishReady(string nom, TypeRecette type) { }

        public TypeRecette Type { get => type; set => type = value; }
        public string Nom { get => nom; set => nom = value; }
    }
}
