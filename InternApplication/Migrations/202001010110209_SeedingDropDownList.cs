namespace InternApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingDropDownList : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[Departments] ([Id], [Name]) VALUES (1, N'Engineer')
                INSERT INTO [dbo].[Departments] ([Id], [Name]) VALUES (2, N'Maeketing')
                INSERT INTO [dbo].[Departments] ([Id], [Name]) VALUES (3, N'Human Resource')
                
                INSERT INTO [dbo].[Genders] ([Id], [Name]) VALUES (1, N'Male')
                INSERT INTO [dbo].[Genders] ([Id], [Name]) VALUES (2, N'Female')
                INSERT INTO [dbo].[Genders] ([Id], [Name]) VALUES (3, N'Decline to self-identify')

                INSERT INTO [dbo].[Races] ([Id], [Name]) VALUES (1, N'Hispanic or Latino')
                INSERT INTO [dbo].[Races] ([Id], [Name]) VALUES (2, N'White')
                INSERT INTO [dbo].[Races] ([Id], [Name]) VALUES (3, N'Black or African American(Not Hispanic or Latino)')
                INSERT INTO [dbo].[Races] ([Id], [Name]) VALUES (4, N'Asian(Not Hispanic or Latino)')
                
                INSERT INTO [dbo].[VeteranStatus] ([Id], [Name]) VALUES (1, N'I am a veteran')
                INSERT INTO [dbo].[VeteranStatus] ([Id], [Name]) VALUES (2, N'I am not a veteran')
                INSERT INTO [dbo].[VeteranStatus] ([Id], [Name]) VALUES (3, N'Decline to self-identify')

            ");

        }
        
        public override void Down()
        {
        }
    }
}
