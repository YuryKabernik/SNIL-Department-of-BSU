namespace SnilAcademicDepartment.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProfessionTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcademicTitle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UniqueCode = c.Int(nullable: false),
                        AcademicTitleNaming = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Degree",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UniqueCode = c.Int(nullable: false),
                        DegreeNaming = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProfessionStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UniqueCode = c.Int(nullable: false),
                        StatusNaming = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Person", "AcademicTitle_Id", c => c.Int());
            AddColumn("dbo.Person", "Degree_Id", c => c.Int());
            AddColumn("dbo.Person", "ProfessionStatus_Id", c => c.Int());
            CreateIndex("dbo.Person", "AcademicTitle_Id");
            CreateIndex("dbo.Person", "Degree_Id");
            CreateIndex("dbo.Person", "ProfessionStatus_Id");
            AddForeignKey("dbo.Person", "AcademicTitle_Id", "dbo.AcademicTitle", "Id");
            AddForeignKey("dbo.Person", "Degree_Id", "dbo.Degree", "Id");
            AddForeignKey("dbo.Person", "ProfessionStatus_Id", "dbo.ProfessionStatus", "Id");
            DropColumn("dbo.Person", "ProfessionStatus");
            DropColumn("dbo.Person", "Degree");
            DropColumn("dbo.Person", "AcademicTitle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Person", "AcademicTitle", c => c.String());
            AddColumn("dbo.Person", "Degree", c => c.String());
            AddColumn("dbo.Person", "ProfessionStatus", c => c.String());
            DropForeignKey("dbo.Person", "ProfessionStatus_Id", "dbo.ProfessionStatus");
            DropForeignKey("dbo.Person", "Degree_Id", "dbo.Degree");
            DropForeignKey("dbo.Person", "AcademicTitle_Id", "dbo.AcademicTitle");
            DropIndex("dbo.Person", new[] { "ProfessionStatus_Id" });
            DropIndex("dbo.Person", new[] { "Degree_Id" });
            DropIndex("dbo.Person", new[] { "AcademicTitle_Id" });
            DropColumn("dbo.Person", "ProfessionStatus_Id");
            DropColumn("dbo.Person", "Degree_Id");
            DropColumn("dbo.Person", "AcademicTitle_Id");
            DropTable("dbo.ProfessionStatus");
            DropTable("dbo.Degree");
            DropTable("dbo.AcademicTitle");
        }
    }
}
