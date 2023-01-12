using System;
using System.Collections.Generic;

namespace companies.Data.Models
{
    public partial class Position
    {
        public Position()
        {
            Positionemployees = new HashSet<Positionemployee>();
        }

        public int Id { get; set; }
        public string Positionname { get; set; } = null!;

        public virtual ICollection<Positionemployee> Positionemployees { get; set; }
    }
}
