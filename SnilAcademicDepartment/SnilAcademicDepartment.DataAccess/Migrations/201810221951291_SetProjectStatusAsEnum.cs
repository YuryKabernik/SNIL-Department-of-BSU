namespace SnilAcademicDepartment.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetProjectStatusAsEnum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Project", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.Project", "ProjectStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Project", "ProjectStatus", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Project", "Status");
        }
    }
}
