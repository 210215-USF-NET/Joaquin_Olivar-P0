using System;
using System.Collections.Generic;

#nullable disable

namespace GRDL.Entities
{
    public partial class Cart
    {
        public Cart()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int? IdCust { get; set; }
        public int? IdCartProd { get; set; }

        public virtual Cartproduct IdCartProdNavigation { get; set; }
        public virtual Customer IdCustNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
