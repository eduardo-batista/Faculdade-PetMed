using petmed.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace petmed.Dal
{
    public class ProjectContext : DbContext
    {
        internal object users;

        public ProjectContext() : base("ProjectContext") { }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Veterinarian> Veterinarians { get; set; }
        public DbSet<Procedure> Procedures { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}