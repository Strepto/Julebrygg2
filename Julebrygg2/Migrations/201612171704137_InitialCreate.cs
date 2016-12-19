namespace Julebrygg2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brukers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Navn = c.String(),
                        Kodeord = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Drikkes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Navn = c.String(),
                        Bryggeri = c.String(),
                        Abv = c.Double(nullable: false),
                        Bilde = c.String(),
                        Stil = c.String(),
                        Pris = c.Double(nullable: false),
                        Land = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DrikkeID = c.Int(nullable: false),
                        BrukerID = c.Int(nullable: false),
                        Bilde = c.String(),
                        Karakter = c.Int(nullable: false),
                        MyProperty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Brukers", t => t.BrukerID, cascadeDelete: true)
                .ForeignKey("dbo.Drikkes", t => t.DrikkeID, cascadeDelete: true)
                .Index(t => t.DrikkeID)
                .Index(t => t.BrukerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "DrikkeID", "dbo.Drikkes");
            DropForeignKey("dbo.Ratings", "BrukerID", "dbo.Brukers");
            DropIndex("dbo.Ratings", new[] { "BrukerID" });
            DropIndex("dbo.Ratings", new[] { "DrikkeID" });
            DropTable("dbo.Ratings");
            DropTable("dbo.Drikkes");
            DropTable("dbo.Brukers");
        }
    }
}
