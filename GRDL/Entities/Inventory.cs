using System;
using System.Collections.Generic;

#nullable disable

namespace GRDL.Entities
{
    public partial class Inventory
    {
        public int IdInv { get; set; }
        public int? IdRec { get; set; }
        public int? IdLoc { get; set; }

        public virtual Location IdLocNavigation { get; set; }
        public virtual Record IdRecNavigation { get; set; }
    }
}
