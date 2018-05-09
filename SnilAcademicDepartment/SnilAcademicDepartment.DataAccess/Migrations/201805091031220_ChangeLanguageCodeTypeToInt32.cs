namespace SnilAcademicDepartment.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeLanguageCodeTypeToInt32 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Language", "LanguageCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Language", "LanguageCode", c => c.String(nullable: false, maxLength: 5));
        }
    }
}
