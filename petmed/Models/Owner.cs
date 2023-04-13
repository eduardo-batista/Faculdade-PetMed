using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace petmed.Models
{
    public class Owner : Person
    {
        [Required]
        public DateTime CreatedAt { get; set; }
        public virtual ICollection<Animal> Animals { get; set; }
        public Owner() {
            this.Animals = new HashSet<Animal>();
        }
        public Owner(string name, string cpf, string phone, string address, DateTime birthDate)
        {
            this.Name = name;
            this.Cpf = cpf;
            this.Phone = phone;
            this.Address = address;
            this.BirthDate = birthDate;
            this.CreatedAt = DateTime.Now;
        }
    }
}