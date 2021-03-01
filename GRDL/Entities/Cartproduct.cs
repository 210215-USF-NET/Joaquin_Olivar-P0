using System;
using System.Collections.Generic;

#nullable disable

namespace GRDL.Entities
{
    public partial class Cartproduct
    {
        public Cartproduct()
        {
            Carts = new HashSet<Cart>();
        }

        public int Id { get; set; }
        public int? IdProd { get; set; }
        public int ProductQuant { get; set; }

        public virtual Record IdProdNavigation { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
