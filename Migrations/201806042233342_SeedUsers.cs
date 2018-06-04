namespace POC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'46b5c0bc-a763-43cb-9fb4-664e1a84c12e', N'guest@vidly.com', 0, N'ANrnW3mjvIvxKTnPOCzLR40CN9OHApdYfTSg7l0TnKHDZQPIMTEPvDYMBb/hhxEvuQ==', N'5415fb77-2b41-487b-8861-6106cd39c130', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6769105c-5b5b-4e11-bb50-958582e1a823', N'admin@vidly.com', 0, N'AIYA8Bk/vmyM/cjw59oR60FvZYqVJlfnnegjI4Er2ne2z+jsu1gpaW3OL0ODf53QXw==', N'456d0500-8c95-45ba-9133-3bcf5bca96ec', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3238f114-68f9-44fb-8d18-e2660bc9abe1', N'CanManageMovies')       
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6769105c-5b5b-4e11-bb50-958582e1a823', N'3238f114-68f9-44fb-8d18-e2660bc9abe1')

");
        }
        
        public override void Down()
        {
        }
    }
}
