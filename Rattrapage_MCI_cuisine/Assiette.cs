using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rattrapage_MCI_cuisine
{
    class Assiette
    {
        private TypeAssiette type;

        public TypeAssiette Type { get => type; set => type = value; }
        public int Stock;
        public int Total;

        public Assiette(int total, TypeAssiette type)
        {
            Total = total;
            Stock = total;
            Type = type;
        }
    }
}
