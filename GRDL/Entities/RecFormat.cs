using System;
using System.Collections.Generic;

#nullable disable

namespace GRDL.Entities
{
    public partial class RecFormat
    {
        public RecFormat()
        {
            Records = new HashSet<Record>();
        }

        public int Id { get; set; }
        public string FormName { get; set; }

        public virtual ICollection<Record> Records { get; set; }
    }
}
