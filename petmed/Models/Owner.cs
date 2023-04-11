using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace petmed.Models
{
    public class Owner : Person
    {
        public DateTime CreatedAt { get; set; }
        public virtual ICollection<Animal> Animals { get; set; }
        public Owner() {
            this.Animals = new HashSet<Animal>();
        }
        public Owner(string name, string cpf, string phone, string address, DateTime birthDate)
        {
            Name = name;
            Cpf = cpf;
            Phone = phone;
            Address = address;
            BirthDate = birthDate;
            CreatedAt = DateTime.Now;
        }
    }
}