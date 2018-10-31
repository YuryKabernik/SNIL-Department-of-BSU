namespace SnilAcademicDepartment.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStuffDepartmentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stuff_Department",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        date_assign = c.DateTime(),
                        date_release = c.DateTime(),
                        PersonId_PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person", t => t.PersonId_PersonId, cascadeDelete: true)
                .Index(t => t.PersonId_PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stuff_Department", "PersonId_PersonId", "dbo.Person");
            DropIndex("dbo.Stuff_Department", new[] { "PersonId_PersonId" });
            DropTable("dbo.Stuff_Department");
        }
    }
}
