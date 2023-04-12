using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace petmed.Models
{
    public class Procedure
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AdministeredMedication { get; set; }
        public DateTime Date { get; set; }
        public int VeterinarianID { get; set; }
        public int AnimalID { get; set; }
        public virtual Veterinarian Veterinarian { get; set; }
        public virtual Animal Animal { get; set; }
        public Procedure() { }

        public Procedure(string name, string description, string administeredMedication, DateTime date, int animalId, int veterinarianId)
        {
            this.Name = name;
            this.Description = description;
            this.AdministeredMedication = administeredMedication;
            this.Date = date;
            this.AnimalID = animalId;
            this.VeterinarianID = veterinarianId;
        }
    }
}