namespace Source_Control_Final_Assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SourceControlFinalAssignmentInitial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Phone_Number", c => c.String());
            AddColumn("dbo.AspNetUsers", "Age", c => c.Byte(nullable: false));
            AddColumn("dbo.AspNetUsers", "Experience", c => c.Byte(nullable: false));
            AddColumn("dbo.AspNetUsers", "UserProfilePicturePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserProfilePicturePath");
            DropColumn("dbo.AspNetUsers", "Experience");
            DropColumn("dbo.AspNetUsers", "Age");
            DropColumn("dbo.AspNetUsers", "Phone_Number");
        }
    }
}
