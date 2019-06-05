using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rattrapage_MCI_cuisine
{
    class Plat
    {
        public void Manger()
        {
            Console.WriteLine("Le plat est en train d'être mangé...");
            Thread.Sleep(10000);
            Console.WriteLine("Plat terminé");
        }


        public void Preparer(int tempsPreparation)
        {
            Console.WriteLine("Plat en préparation...");
            Thread.Sleep(5000);
            Console.WriteLine("Plat prêt");
        }
    }
}
