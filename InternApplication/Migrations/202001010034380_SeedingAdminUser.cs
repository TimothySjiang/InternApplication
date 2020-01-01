namespace InternApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingAdminUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bb377a54-70f6-4c76-84d8-78374d3dc215', N'admin@arctrade.com', 0, N'ACG9rz0JxB90PLDTlnH/k5PTHNrRM3Pue6+PJqUKV9eF6gvCkXLeynYAxo9wUTSPqg==', N'6931e1e6-7683-44fc-9752-4ea3ddb53dc0', NULL, 0, 0, NULL, 1, 0, N'admin@arctrade.com')
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'65402633-1a03-4cab-a120-95f79e98aded', N'CanManagePositions')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bb377a54-70f6-4c76-84d8-78374d3dc215', N'65402633-1a03-4cab-a120-95f79e98aded')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
