using System;
using System.Collections.Generic;

namespace companies.Data.Models
{
    public partial class Positionemployee
    {
        public int Id { get; set; }
        public int Employeeid { get; set; }
        public int Positionid { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual Position Position { get; set; } = null!;
    }
}
