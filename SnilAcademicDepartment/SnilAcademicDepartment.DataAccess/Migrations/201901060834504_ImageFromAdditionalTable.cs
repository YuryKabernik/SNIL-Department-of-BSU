namespace SnilAcademicDepartment.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageFromAdditionalTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PreView", "ImageId", c => c.Int(nullable: false));
            CreateIndex("dbo.PreView", "PreViewId");
            AddForeignKey("dbo.PreView", "PreViewId", "dbo.Image", "ImageId");
            DropColumn("dbo.PreView", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PreView", "Image", c => c.Binary(nullable: false, storeType: "image"));
            DropForeignKey("dbo.PreView", "PreViewId", "dbo.Image");
            DropIndex("dbo.PreView", new[] { "PreViewId" });
            DropColumn("dbo.PreView", "ImageId");
        }
    }
}
