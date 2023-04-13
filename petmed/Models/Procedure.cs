using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace petmed.Models
{
    public class Procedure
    {
        public int ID { get; set; }
        [DisplayName("Nome")]
        public string Name { get; set; }
        [DisplayName("Descrição")]
        public string Description { get; set; }
        [DisplayName("Medicação Administrada")]
        public string AdministeredMedication { get; set; }
        [DisplayName("Data")]
        public DateTime Date { get; set; }
        [DisplayName("Veterinário")]
        public int VeterinarianID { get; set; }
        [DisplayName("Animal")]
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