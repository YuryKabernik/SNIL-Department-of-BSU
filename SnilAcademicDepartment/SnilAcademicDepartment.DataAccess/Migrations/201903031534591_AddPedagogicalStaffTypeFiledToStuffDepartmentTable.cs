namespace SnilAcademicDepartment.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPedagogicalStaffTypeFiledToStuffDepartmentTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stuff_Department", "StaffType", c => c.Int(nullable: false));
            AlterColumn("dbo.Lecture", "LectureName", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Lecture", "Description", c => c.String());
            AlterColumn("dbo.Project", "ProjectName", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.Project", "Description", c => c.String(nullable: false, maxLength: 600));
            AlterColumn("dbo.Project", "Status", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Seminar", "Title", c => c.String(nullable: false, maxLength: 900));
            AlterColumn("dbo.Seminar", "SpeakerId", c => c.Int());
            AlterColumn("dbo.Seminar", "ResponsiblePersonId", c => c.Int());
            AlterColumn("dbo.Students", "SecoundName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Students", "StudentsGroup", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "StudentsGroup", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Students", "SecoundName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Seminar", "ResponsiblePersonId", c => c.Int(nullable: false));
            AlterColumn("dbo.Seminar", "SpeakerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Seminar", "Title", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Project", "Status", c => c.String());
            AlterColumn("dbo.Project", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Project", "ProjectName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Lecture", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Lecture", "LectureName", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Stuff_Department", "StaffType");
        }
    }
}
