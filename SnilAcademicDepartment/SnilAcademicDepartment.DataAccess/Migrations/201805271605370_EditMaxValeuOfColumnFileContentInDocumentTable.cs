namespace SnilAcademicDepartment.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditMaxValeuOfColumnFileContentInDocumentTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Document", "FileContent", c => c.Binary(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Document", "FileContent", c => c.Binary(nullable: false, maxLength: 8000));
        }
    }
}
