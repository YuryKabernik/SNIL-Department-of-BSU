namespace SnilAcademicDepartment.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageTypeExtenctionColumnToImageTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Image", "ImageTypeExtenction", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Image", "ImageTypeExtenction");
        }
    }
}
