using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rattrapage_MCI_cuisine
{
    class CommisCuisine
    {
        /// Prepare une étape
        public void PrepareStep()
        {
            Console.WriteLine("Commis commence l'étape ");

            Console.WriteLine("Etape en cours");
            Thread.Sleep(1000);
            Console.WriteLine("Etape finie");
        }
    }
}
