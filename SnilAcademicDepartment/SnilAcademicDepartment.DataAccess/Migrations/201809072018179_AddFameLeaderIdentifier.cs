namespace SnilAcademicDepartment.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFameLeaderIdentifier : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "PersonUniqueIdentifire", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Person", "PersonUniqueIdentifire");
        }
    }
}
