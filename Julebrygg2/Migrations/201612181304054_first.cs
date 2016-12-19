namespace Julebrygg2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Brukers", "ModifiedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Brukers", "CreateDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Drikkes", "ModifiedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Drikkes", "CreateDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Ratings", "ModifiedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Ratings", "CreateDate", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ratings", "CreateDate");
            DropColumn("dbo.Ratings", "ModifiedDate");
            DropColumn("dbo.Drikkes", "CreateDate");
            DropColumn("dbo.Drikkes", "ModifiedDate");
            DropColumn("dbo.Brukers", "CreateDate");
            DropColumn("dbo.Brukers", "ModifiedDate");
        }
    }
}
