namespace POC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uptoSpeed1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Genre", "GenreName", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Genre", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genre", "Name", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Genre", "GenreName");
        }
    }
}
