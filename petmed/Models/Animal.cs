using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace petmed.Models
{
    public class Animal
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public string Race { get; set; }
        public string Species { get; set; }
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