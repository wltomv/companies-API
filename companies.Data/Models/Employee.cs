using System;
using System.Collections.Generic;

namespace companies.Data.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Positionemployees = new HashSet<Positionemployee>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public int Companyid { get; set; }

        public virtual Company Company { get; set; } = null!;
        public virtual ICollection<Positionemployee> Positionemployees { get; set; }
    }
}
