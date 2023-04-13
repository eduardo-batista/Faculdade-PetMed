using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace petmed.Models
{
    public abstract class Person
    {
        public int ID { get; set; }
        [Required]
        [DisplayName("Nome")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        public string Name { get; set; }
        [Required]
        [DisplayName("CPF")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "CPF Inválido.")]
        public string Cpf { get; set; }
        [DisplayName("Telefone")]
        public string Phone { get; set; }
        [Required]
        [DisplayName("Endereço")]
        public string Address { get; set; }
        [DisplayName("Data de Nascimento")]
        public DateTime BirthDate { get; set; }
    }
}