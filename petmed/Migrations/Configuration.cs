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
            AutomaticMigrationsEnabled = false;
            ContextKey = "petmed.Dal.ProjectContext";
        }

        protected override void Seed(petmed.Dal.ProjectContext context)
        {
            List<User> users = new List<User>
            {
                new User(Name: "Admin", Cpf: "12345678", Phone: "63987675463", Address: "rua tals", BirthDate: DateTime.Now, Matriculation: "123321", Email: "admin@gmail.com", Password: "admin123"),
            };

            users.ForEach(user => context.Users.Add(user));

            context.SaveChanges();
        }
    }
}
