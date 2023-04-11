namespace petmed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Age = c.Int(nullable: false),
                        Race = c.String(),
                        Species = c.String(),
                        OwnerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Owners", t => t.OwnerID, cascadeDelete: true)
                .Index(t => t.OwnerID);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CreatedAt = c.DateTime(nullable: false),
                        Name = c.String(),
                        Cpf = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Procedures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        AdministeredMedication = c.String(),
                        Date = c.DateTime(nullable: false),
                        VeterinarianID = c.Int(nullable: false),
                        AnimalID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Animals", t => t.AnimalID, cascadeDelete: true)
                .ForeignKey("dbo.Veterinarians", t => t.VeterinarianID, cascadeDelete: true)
                .Index(t => t.VeterinarianID)
                .Index(t => t.AnimalID);
            
            CreateTable(
                "dbo.Veterinarians",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Matriculation = c.String(),
                        Crmv = c.String(),
                        Name = c.String(),
                        Cpf = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Matriculation = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                        Cpf = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Procedures", "VeterinarianID", "dbo.Veterinarians");
            DropForeignKey("dbo.Procedures", "AnimalID", "dbo.Animals");
            DropForeignKey("dbo.Animals", "OwnerID", "dbo.Owners");
            DropIndex("dbo.Procedures", new[] { "AnimalID" });
            DropIndex("dbo.Procedures", new[] { "VeterinarianID" });
            DropIndex("dbo.Animals", new[] { "OwnerID" });
            DropTable("dbo.Users");
            DropTable("dbo.Veterinarians");
            DropTable("dbo.Procedures");
            DropTable("dbo.Owners");
            DropTable("dbo.Animals");
        }
    }
}
