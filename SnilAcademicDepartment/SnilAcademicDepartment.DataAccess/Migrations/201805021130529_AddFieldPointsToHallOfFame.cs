namespace SnilAcademicDepartment.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldPointsToHallOfFame : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HallOfFame", "Points", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HallOfFame", "Points");
        }
    }
}
