namespace SnilAcademicDepartment.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageToStudentsDataModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Image_ImageId", c => c.Int());
            CreateIndex("dbo.Students", "Image_ImageId");
            AddForeignKey("dbo.Students", "Image_ImageId", "dbo.Image", "ImageId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Image_ImageId", "dbo.Image");
            DropIndex("dbo.Students", new[] { "Image_ImageId" });
            DropColumn("dbo.Students", "Image_ImageId");
        }
    }
}
