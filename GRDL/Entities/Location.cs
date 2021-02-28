using System;
using System.Collections.Generic;

#nullable disable

namespace GRDL.Entities
{
    public partial class Location
    {
        public Location()
        {
            Inventories = new HashSet<Inventory>();
        }

        public int Id { get; set; }
        public string LocName { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
