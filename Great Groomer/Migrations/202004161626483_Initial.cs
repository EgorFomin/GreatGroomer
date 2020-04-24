namespace Great_Groomer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroomBookings",
                c => new
                    {
                        GroomBookingID = c.Int(nullable: false, identity: true),
                        GroomBookingDate = c.DateTime(nullable: false),
                        GroomBookingPrice = c.Int(nullable: false),
                        PetID = c.Int(nullable: false),
                        GroomerID = c.Int(nullable: false),
                        OwnerID = c.Int(nullable: false),
                        GroomServiceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroomBookingID)
                .ForeignKey("dbo.Groomers", t => t.GroomerID)
                .ForeignKey("dbo.GroomServices", t => t.GroomServiceID)
                .ForeignKey("dbo.Owners", t => t.OwnerID)
                .ForeignKey("dbo.Pets", t => t.PetID)
                .Index(t => t.PetID)
                .Index(t => t.GroomerID)
                .Index(t => t.OwnerID)
                .Index(t => t.GroomServiceID);
            
            CreateTable(
                "dbo.Groomers",
                c => new
                    {
                        GroomerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        GroomerDOB = c.DateTime(nullable: false),
                        GroomerRate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroomerID);
            
            CreateTable(
                "dbo.GroomServices",
                c => new
                    {
                        GroomServiceID = c.Int(nullable: false, identity: true),
                        ServiceName = c.String(),
                        ServiceCost = c.Int(nullable: false),
                        ServiceDuration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroomServiceID);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        OwnerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        WorkPhone = c.String(),
                        HomePhone = c.String(),
                    })
                .PrimaryKey(t => t.OwnerID);
            
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        PetId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Weight = c.Double(nullable: false),
                        Color = c.String(),
                        Notes = c.String(),
                        OwnerID = c.Int(nullable: false),
                        SpeciesID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PetId)
                .ForeignKey("dbo.Owners", t => t.OwnerID)
                .ForeignKey("dbo.Species", t => t.SpeciesID)
                .Index(t => t.OwnerID)
                .Index(t => t.SpeciesID);
            
            CreateTable(
                "dbo.Species",
                c => new
                    {
                        SpeciesId = c.Int(nullable: false, identity: true),
                        SpeciesName = c.String(),
                    })
                .PrimaryKey(t => t.SpeciesId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pets", "SpeciesID", "dbo.Species");
            DropForeignKey("dbo.Pets", "OwnerID", "dbo.Owners");
            DropForeignKey("dbo.GroomBookings", "PetID", "dbo.Pets");
            DropForeignKey("dbo.GroomBookings", "OwnerID", "dbo.Owners");
            DropForeignKey("dbo.GroomBookings", "GroomServiceID", "dbo.GroomServices");
            DropForeignKey("dbo.GroomBookings", "GroomerID", "dbo.Groomers");
            DropIndex("dbo.Pets", new[] { "SpeciesID" });
            DropIndex("dbo.Pets", new[] { "OwnerID" });
            DropIndex("dbo.GroomBookings", new[] { "GroomServiceID" });
            DropIndex("dbo.GroomBookings", new[] { "OwnerID" });
            DropIndex("dbo.GroomBookings", new[] { "GroomerID" });
            DropIndex("dbo.GroomBookings", new[] { "PetID" });
            DropTable("dbo.Species");
            DropTable("dbo.Pets");
            DropTable("dbo.Owners");
            DropTable("dbo.GroomServices");
            DropTable("dbo.Groomers");
            DropTable("dbo.GroomBookings");
        }
    }
}
