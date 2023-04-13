using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace petmed.Models
{
    public class Animal
    {
        public int ID { get; set; }

        [Required]
        [DisplayName("Nome")]
        public string Name { get; set; }
        [DisplayName("Descrição")]
        public string Description { get; set; }
        [Required]
        [DisplayName("Idade")]
        public int Age { get; set; }
        [Required]
        [DisplayName("Raça")]
        public string Race { get; set; }
        [Required]
        [DisplayName("Espécie")]
        public string Species { get; set; }
        [Required]
        [DisplayName("Dono")]
        public int OwnerID { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual ICollection<Procedure> Procedures { get; set; }

        public Animal()
        {
            this.Procedures = new HashSet<Procedure>();
        }

        public Animal(string name, string description, int age, string race, string species, int ownerId)
        {
            this.Name = name;
            this.Description = description;
            this.Age = age;
            this.Race = race;
            this.Species = species;
            this.OwnerID = ownerId;
        }
    }
}