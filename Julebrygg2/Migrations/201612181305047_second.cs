namespace Julebrygg2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Brukers", "ModifiedDate", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.Brukers", "CreateDate", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.Drikkes", "ModifiedDate", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.Drikkes", "CreateDate", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.Ratings", "ModifiedDate", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.Ratings", "CreateDate", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ratings", "CreateDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Ratings", "ModifiedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Drikkes", "CreateDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Drikkes", "ModifiedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Brukers", "CreateDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Brukers", "ModifiedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
