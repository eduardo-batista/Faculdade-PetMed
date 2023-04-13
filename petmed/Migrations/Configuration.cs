namespace petmed.Migrations
{
    using petmed.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<petmed.Dal.ProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "petmed.Dal.ProjectContext";
        }

        protected override void Seed(petmed.Dal.ProjectContext context)
        {
            List<User> users = new List<User>
            {
                new User(Name: "Admin", Cpf: "123.456.789-12", Phone: "63987675463", Address: "rua tals", BirthDate: DateTime.Now, Matriculation: "123321", Email: "admin@gmail.com", Password: "admin123"),
            };

            users.ForEach(user => context.Users.AddOrUpdate(user));
            context.SaveChanges();

            List<Owner> owners = new List<Owner>
            {
                new Owner(name: "Dono", cpf: "321.321.321-12", phone: "63987675463", address: "rua tals", birthDate: DateTime.Now)
            };

            owners.ForEach(owner => context.Owners.AddOrUpdate(owner));
            context.SaveChanges();

            List<Animal> animals = new List<Animal>
            {
                new Animal(name: "Hulk", description: "Cachorro fofo", age: 2, race: "Pinscher", species: "Cão", ownerId: context.Owners.Where(r => r.Cpf == "321.321.321-12").First().ID)
            };

            animals.ForEach(animal => context.Animals.AddOrUpdate(animal));
            context.SaveChanges();

            List<Veterinarian> veterinarians = new List<Veterinarian>
            {
                new Veterinarian(name: "Veterinario", cpf: "213.213.213-12", phone: "63987675463", address: "rua tals", birthDate: DateTime.Now, matriculation: "123321", crmv: "121212")
            };

            veterinarians.ForEach(veterinarian => context.Veterinarians.AddOrUpdate(veterinarian));
            context.SaveChanges();

            List<Procedure> procedures = new List<Procedure>
            {
                new Procedure(name: "castração", description: "tirar testiculos", administeredMedication: "Dipirona", date: DateTime.Now, animalId: context.Animals.Where(r => (r.Owner.Cpf == "321.321.321-12" && r.Name == "Hulk")).First().ID, veterinarianId: context.Veterinarians.Where(r => r.Cpf == "213.213.213-12").First().ID)
            };

            procedures.ForEach(procedure => context.Procedures.AddOrUpdate(procedure));
            context.SaveChanges();

        }
    }
}
