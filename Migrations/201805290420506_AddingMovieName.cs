namespace POC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingMovieName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Name");
        }
    }
}
