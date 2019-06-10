using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Rattrapage_MCI_cuisine
{
    [DataContract]
    class Order
    {
        //Propriétés
        [DataMember]
        private int idOrder;
        [DataMember]
        private List<string> entriees;
        [DataMember]
        private List<string> plats;
        [DataMember]
        private List<string> deserts;

        public int IdOrder { get => idOrder; set => idOrder = value; }
        public List<string> Entriees { get => entriees; set => entriees = value; }
        public List<string> Plats { get => plats; set => plats = value; }
        public List<string> Deserts { get => deserts; set => deserts = value; }

        /// <summary>
        /// Id of the command
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// List of dishes ordered
        /// </summary>
        public List<Dish> Dishes { get; set; }

        /// <summary>
        /// The order is readay or not
        /// </summary>
        public bool Ready { get; set; }

        public Order()
        {
            this.Dishes = new List<Dish>();
            this.Ready = false;
        }

    }
}
