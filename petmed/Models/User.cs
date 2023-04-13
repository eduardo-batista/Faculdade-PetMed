using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace petmed.Models
{
    public class User : Person
    {
        [DisplayName("Matricula")]
        public string Matriculation { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [DisplayName("Senha")]
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