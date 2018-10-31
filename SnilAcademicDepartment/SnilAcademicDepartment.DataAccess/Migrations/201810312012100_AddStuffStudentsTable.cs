namespace SnilAcademicDepartment.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStuffStudentsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stuff_Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        date_entrance = c.DateTime(),
                        date_departure = c.DateTime(),
                        Student_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .Index(t => t.Student_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stuff_Students", "Student_Id", "dbo.Students");
            DropIndex("dbo.Stuff_Students", new[] { "Student_Id" });
            DropTable("dbo.Stuff_Students");
        }
    }
}
