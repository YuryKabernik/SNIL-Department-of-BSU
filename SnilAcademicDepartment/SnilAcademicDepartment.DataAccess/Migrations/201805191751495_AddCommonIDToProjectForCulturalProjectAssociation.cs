namespace SnilAcademicDepartment.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommonIDToProjectForCulturalProjectAssociation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Project", "CommonID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Project", "CommonID");
        }
    }
}
