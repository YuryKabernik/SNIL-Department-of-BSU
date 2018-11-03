namespace SnilAcademicDepartment.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStuffPersonalTableToDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stuff_personal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssignmentDate = c.DateTime(),
                        ReleaseDate = c.DateTime(),
                        PersonId_PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person", t => t.PersonId_PersonId)
                .Index(t => t.PersonId_PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stuff_personal", "PersonId_PersonId", "dbo.Person");
            DropIndex("dbo.Stuff_personal", new[] { "PersonId_PersonId" });
            DropTable("dbo.Stuff_personal");
        }
    }
}
