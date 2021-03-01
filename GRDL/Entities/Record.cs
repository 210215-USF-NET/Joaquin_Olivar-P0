using System;
using System.Collections.Generic;

#nullable disable

namespace GRDL.Entities
{
    public partial class Record
    {
        public Record()
        {
            Cartproducts = new HashSet<Cartproduct>();
            Inventories = new HashSet<Inventory>();
            Orderproducts = new HashSet<Orderproduct>();
        }

        public int Id { get; set; }
        public string RecordName { get; set; }
        public string ArtistName { get; set; }
        public int? Genre { get; set; }
        public int? Condition { get; set; }
        public int? RecFormat { get; set; }
        public double Price { get; set; }

        public virtual Condition ConditionNavigation { get; set; }
        public virtual Genre GenreNavigation { get; set; }
        public virtual RecFormat RecFormatNavigation { get; set; }
        public virtual ICollection<Cartproduct> Cartproducts { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<Orderproduct> Orderproducts { get; set; }
    }
}
