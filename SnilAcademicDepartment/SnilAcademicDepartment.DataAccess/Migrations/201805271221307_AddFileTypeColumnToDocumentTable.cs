namespace SnilAcademicDepartment.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFileTypeColumnToDocumentTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Document", "FileType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Document", "FileType");
        }
    }
}
