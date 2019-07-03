namespace SnilAcademicDepartment.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Skakun_28062019 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Diplomas", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Diplomas", "Name", c => c.Int(nullable: false));
        }
    }
}
