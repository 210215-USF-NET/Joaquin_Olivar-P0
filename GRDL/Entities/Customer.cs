using System;
using System.Collections.Generic;

#nullable disable

namespace GRDL.Entities
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string EMail { get; set; }
        public string Address { get; set; }
        public int Zip { get; set; }
    }
}
