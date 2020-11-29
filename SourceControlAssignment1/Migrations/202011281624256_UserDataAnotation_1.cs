namespace SourceControlAssignment1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserDataAnotation_1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserRegistrations", "URL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserRegistrations", "URL");
        }
    }
}
