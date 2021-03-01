using System;
using System.Collections.Generic;

#nullable disable

namespace GRDL.Entities
{
    public partial class Order
    {
        public Order()
        {
            Orderproducts = new HashSet<Orderproduct>();
        }

        public int Id { get; set; }
        public int Location { get; set; }
        public int IdCart { get; set; }
        public DateTime ODate { get; set; }

        public virtual Cart IdCartNavigation { get; set; }
        public virtual Location LocationNavigation { get; set; }
        public virtual ICollection<Orderproduct> Orderproducts { get; set; }
    }
}
