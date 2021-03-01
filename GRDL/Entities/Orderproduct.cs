using System;
using System.Collections.Generic;

#nullable disable

namespace GRDL.Entities
{
    public partial class Orderproduct
    {
        public int Id { get; set; }
        public int Idproducts { get; set; }
        public int Idorder { get; set; }

        public virtual Order IdorderNavigation { get; set; }
        public virtual Record IdproductsNavigation { get; set; }
    }
}
