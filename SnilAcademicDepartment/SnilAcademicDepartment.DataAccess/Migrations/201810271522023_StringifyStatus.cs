namespace SnilAcademicDepartment.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StringifyStatus : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Project", "Status", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Project", "Status", c => c.Int(nullable: false));
        }
    }
}
