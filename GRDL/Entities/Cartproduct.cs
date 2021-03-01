using System;
using System.Collections.Generic;

#nullable disable

namespace GRDL.Entities
{
    public partial class Cartproduct
    {
        public int Id { get; set; }
        public int? IdProd { get; set; }
        public int? IdCart { get; set; }
        public int ProductQuant { get; set; }

        public virtual Cart IdCartNavigation { get; set; }
        public virtual Record IdProdNavigation { get; set; }
    }
}
