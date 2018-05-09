namespace SnilAcademicDepartment.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExpandMaxLengthInTopic : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EducationTopic", "TopicName", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EducationTopic", "TopicName", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
