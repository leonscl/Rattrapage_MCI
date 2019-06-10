using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rattrapage_MCI.Model
{
    class Table
    {
        //propriétés
        private int idTable;
        private static int idIncrementor = 0;

        private int numberPlace;
        private bool occupied;
        private bool needCleaning;

        private int bread;
        private int bottle;

        private CustomerGroup customerGroup = null;
        private Square theSquare;

        //constructeur
        public Table(int placenumber, Square square)
        {
            theSquare = square;
            IdTable = IdIncrementor;
            IdIncrementor++;

            NumberPlace = placenumber;
            Occupied = false;
            NeedCleaning = false;

            Bread = 0;
            Bottle = 0;

            Console.WriteLine("Table " + IdTable + " disponible.");
        }

        //getter et setter
        public int IdTable { get => idTable; set => idTable = value; }
        public static int IdIncrementor { get => idIncrementor; set => idIncrementor = value; }
        public int NumberPlace { get => numberPlace; set => numberPlace = value; }
        public bool Occupied { get => occupied; set => occupied = value; }
        public int Bread { get => bread; set => bread = value; }
        public int Bottle { get => bottle; set => bottle = value; }
        internal CustomerGroup CustomerGroup { get => customerGroup; set => customerGroup = value; }
        internal Square TheSquare { get => theSquare; set => theSquare = value; }
        public bool NeedCleaning { get => needCleaning; set => needCleaning = value; }
    }
}
