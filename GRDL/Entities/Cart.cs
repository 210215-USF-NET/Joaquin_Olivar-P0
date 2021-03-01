﻿using System;
using System.Collections.Generic;

#nullable disable

namespace GRDL.Entities
{
    public partial class Cart
    {
        public Cart()
        {
            Cartproducts = new HashSet<Cartproduct>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int IdCust { get; set; }

        public virtual Customer IdCustNavigation { get; set; }
        public virtual ICollection<Cartproduct> Cartproducts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
