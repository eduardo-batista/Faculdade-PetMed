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

        public Veterinarian(string name, string cpf, string phone, string address, DateTime birthDate, string matriculation, string crmv)
        {
            this.Name = name;
            this.Cpf = cpf;
            this.Phone = phone;
            this.Address = address;
            this.BirthDate = birthDate;
            this.Matriculation = matriculation;
            this.Crmv = crmv;
        }
    }
}