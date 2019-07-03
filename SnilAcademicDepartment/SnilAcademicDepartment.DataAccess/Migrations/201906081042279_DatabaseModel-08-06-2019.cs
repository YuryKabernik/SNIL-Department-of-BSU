namespace SnilAcademicDepartment.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseModel08062019 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stuff_Students", "Id", "dbo.Students");
            DropIndex("dbo.Stuff_Students", new[] { "Id" });
            DropPrimaryKey("dbo.Stuff_Students");
            CreateTable(
                "dbo.Diplomas",
                c => new
                    {
                        DiplomaId = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Descriptions = c.String(),
                        LanguageId = c.Int(nullable: false),
                        ProtectionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DiplomaId)
                .ForeignKey("dbo.Language", t => t.LanguageId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.DiplomaPerson",
                c => new
                    {
                        Diploma_DiplomaId = c.Int(nullable: false),
                        Person_PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Diploma_DiplomaId, t.Person_PersonId })
                .ForeignKey("dbo.Diplomas", t => t.Diploma_DiplomaId, cascadeDelete: true)
                .ForeignKey("dbo.Person", t => t.Person_PersonId, cascadeDelete: true)
                .Index(t => t.Diploma_DiplomaId)
                .Index(t => t.Person_PersonId);
            
            AddColumn("dbo.Stuff_Students", "Student_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Stuff_Students", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Stuff_Students", "Id");
            CreateIndex("dbo.Stuff_Students", "Student_Id");
            AddForeignKey("dbo.Stuff_Students", "Student_Id", "dbo.Students", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stuff_Students", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.DiplomaPerson", "Person_PersonId", "dbo.Person");
            DropForeignKey("dbo.DiplomaPerson", "Diploma_DiplomaId", "dbo.Diplomas");
            DropForeignKey("dbo.Diplomas", "LanguageId", "dbo.Language");
            DropIndex("dbo.DiplomaPerson", new[] { "Person_PersonId" });
            DropIndex("dbo.DiplomaPerson", new[] { "Diploma_DiplomaId" });
            DropIndex("dbo.Stuff_Students", new[] { "Student_Id" });
            DropIndex("dbo.Diplomas", new[] { "LanguageId" });
            DropPrimaryKey("dbo.Stuff_Students");
            AlterColumn("dbo.Stuff_Students", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.Stuff_Students", "Student_Id");
            DropTable("dbo.DiplomaPerson");
            DropTable("dbo.Diplomas");
            AddPrimaryKey("dbo.Stuff_Students", "Id");
            CreateIndex("dbo.Stuff_Students", "Id");
            AddForeignKey("dbo.Stuff_Students", "Id", "dbo.Students", "Id");
        }
    }
}
