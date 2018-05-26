namespace SnilAcademicDepartment.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommonIdToBlockType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EducationBlock", "CommonBlockTypeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EducationBlock", "CommonBlockTypeId");
        }
    }
}
