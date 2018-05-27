namespace SnilAcademicDepartment.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditFileTypeColumnInDocumentTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Document", "FileTypeExtenction", c => c.String());
            DropColumn("dbo.Document", "FileType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Document", "FileType", c => c.String());
            DropColumn("dbo.Document", "FileTypeExtenction");
        }
    }
}
