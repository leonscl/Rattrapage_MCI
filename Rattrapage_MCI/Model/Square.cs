using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rattrapage_MCI.Model
{
    class Square
    {
        int idSquare;

        private List<Table> tables;

        private RankChief rankChief;

        private List<Waiter> waiters;

        public Square(int id)
        {
            IdSquare = id;

            RankChief = new RankChief();

            Table table1 = new Table(2);
            Table table2 = new Table(4);
            Table table3 = new Table(8);
            Table table4 = new Table(10);

            Tables = new List<Table>();
            Tables.Add(table1);
            Tables.Add(table2);
            Tables.Add(table3);
            Tables.Add(table4);

            Waiter waiter1 = new Waiter();
            Waiter waiter2 = new Waiter();

            Waiters = new List<Waiter>();
            Waiters.Add(waiter1);
            Waiters.Add(waiter2);
        }

        public int IdSquare { get => idSquare; set => idSquare = value; }
        internal RankChief RankChief { get => rankChief; set => rankChief = value; }
        internal List<Waiter> Waiters { get => waiters; set => waiters = value; }
        internal List<Table> Tables { get => tables; set => tables = value; }
    }
}
