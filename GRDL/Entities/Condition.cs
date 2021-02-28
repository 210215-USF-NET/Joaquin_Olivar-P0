using System;
using System.Collections.Generic;

#nullable disable

namespace GRDL.Entities
{
    public partial class Condition
    {
        public Condition()
        {
            Records = new HashSet<Record>();
        }

        public int Id { get; set; }
        public string ConditionName { get; set; }

        public virtual ICollection<Record> Records { get; set; }
    }
}
