namespace SnilAcademicDepartment.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudentTypesAndUpdateStudentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeUniqueId = c.Int(nullable: false),
                        TypeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Students", "UniqueIdentifier", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "Language_LanguageId", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "StudentType_Id", c => c.Int());
            CreateIndex("dbo.Students", "Language_LanguageId");
            CreateIndex("dbo.Students", "StudentType_Id");
            AddForeignKey("dbo.Students", "Language_LanguageId", "dbo.Language", "LanguageId");
            AddForeignKey("dbo.Students", "StudentType_Id", "dbo.StudentTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "StudentType_Id", "dbo.StudentTypes");
            DropForeignKey("dbo.Students", "Language_LanguageId", "dbo.Language");
            DropIndex("dbo.Students", new[] { "StudentType_Id" });
            DropIndex("dbo.Students", new[] { "Language_LanguageId" });
            DropColumn("dbo.Students", "StudentType_Id");
            DropColumn("dbo.Students", "Language_LanguageId");
            DropColumn("dbo.Students", "UniqueIdentifier");
            DropTable("dbo.StudentTypes");
        }
    }
}
