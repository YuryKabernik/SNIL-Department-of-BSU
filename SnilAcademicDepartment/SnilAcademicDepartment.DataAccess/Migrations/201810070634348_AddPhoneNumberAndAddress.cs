namespace SnilAcademicDepartment.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhoneNumberAndAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "EmailAddress", c => c.String());
            AddColumn("dbo.Person", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Person", "PhoneNumber");
            DropColumn("dbo.Person", "EmailAddress");
        }
    }
}
