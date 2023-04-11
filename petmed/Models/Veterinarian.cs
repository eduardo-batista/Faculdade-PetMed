using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace petmed.Models
{
    public class Veterinarian : Person
    {
        public string Matriculation { get; set; }
        public string Crmv { get; set; }
        public virtual ICollection<Procedure> Procedures { get; set; }

        public Veterinarian()
        {
            this.Procedures = new HashSet<Procedure>();
        }
    }
}