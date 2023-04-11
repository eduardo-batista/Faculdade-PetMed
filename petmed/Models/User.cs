using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace petmed.Models
{
    public class User : Person
    {
        public string Matriculation { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User() { }

        public User(string Name, string Cpf, string Phone, string Address, DateTime BirthDate, string Matriculation, string Email, string Password)
        {
            this.Name = Name;
            this.Cpf = Cpf;
            this.Phone = Phone;
            this.Address = Address;
            this.BirthDate = BirthDate;
            this.Matriculation = Matriculation;
            this.Email = Email;
            this.Password = Password;
        }
    }
}