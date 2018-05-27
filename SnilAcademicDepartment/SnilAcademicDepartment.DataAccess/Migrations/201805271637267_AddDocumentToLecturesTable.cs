namespace SnilAcademicDepartment.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDocumentToLecturesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lecture", "DocumentId", c => c.Int());
            CreateIndex("dbo.Lecture", "DocumentId");
            AddForeignKey("dbo.Lecture", "DocumentId", "dbo.Document", "DocumentId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lecture", "DocumentId", "dbo.Document");
            DropIndex("dbo.Lecture", new[] { "DocumentId" });
            DropColumn("dbo.Lecture", "DocumentId");
        }
    }
}
