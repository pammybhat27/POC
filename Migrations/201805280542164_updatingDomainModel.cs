namespace POC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingDomainModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "SignUpFee", c => c.Short(nullable: false));
            AddColumn("dbo.MembershipTypes", "DurationInMonths", c => c.Byte(nullable: false));
            AddColumn("dbo.MembershipTypes", "DiscountRate", c => c.Byte(nullable: false));
            DropColumn("dbo.MembershipTypes", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String());
            DropColumn("dbo.MembershipTypes", "DiscountRate");
            DropColumn("dbo.MembershipTypes", "DurationInMonths");
            DropColumn("dbo.MembershipTypes", "SignUpFee");
        }
    }
}
