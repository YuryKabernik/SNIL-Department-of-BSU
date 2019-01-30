namespace SnilAcademicDepartment.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForgeryKeyToPreViewTableToImageTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PreView", "Image_ImageId", c => c.Int());
            CreateIndex("dbo.PreView", "Image_ImageId");
            AddForeignKey("dbo.PreView", "Image_ImageId", "dbo.Image", "ImageId");
            DropColumn("dbo.PreView", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PreView", "Image", c => c.Binary(nullable: false, storeType: "image"));
            DropForeignKey("dbo.PreView", "Image_ImageId", "dbo.Image");
            DropIndex("dbo.PreView", new[] { "Image_ImageId" });
            DropColumn("dbo.PreView", "Image_ImageId");
        }
    }
}
