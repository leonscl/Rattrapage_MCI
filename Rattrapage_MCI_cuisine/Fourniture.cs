using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rattrapage_MCI_cuisine
{
    public abstract class Fourniture
    {
        private int total;
        private int stock;
        private int enSalle;
        private int attenteLavage;
        private int enLavage;

        public int EnLavage { get => enLavage; set => enLavage = value; }
        public int Total { get => total; set => total = value; }
        public int Stock { get => stock; set => stock = value; }
        public int EnSalle { get => enSalle; set => enSalle = value; }
        public int AttenteLavage { get => attenteLavage; set => attenteLavage = value; }

        public void Lave(int nombreFourniture)
        {

        }

        public void Debarasse(int nombreFourniture)
        {

        }

        public void Stocke(int nombreFourniture)
        {

        }
    }
}
