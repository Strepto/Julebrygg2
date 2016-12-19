namespace Julebrygg2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class egenskaperpårating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ratings", "Nokkelord", c => c.String());
            AddColumn("dbo.Ratings", "SmakerJul", c => c.Boolean(nullable: false));
            DropColumn("dbo.Ratings", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ratings", "MyProperty", c => c.Int(nullable: false));
            DropColumn("dbo.Ratings", "SmakerJul");
            DropColumn("dbo.Ratings", "Nokkelord");
        }
    }
}
