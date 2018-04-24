namespace SnilAcademicDepartment.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CodeFiirstFromDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Biographies",
                c => new
                    {
                        BiographyId = c.Int(nullable: false),
                        Biography = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BiographyId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false),
                        PersonName = c.String(nullable: false, maxLength: 10),
                        SecoundName = c.String(nullable: false, maxLength: 50),
                        FathersName = c.String(nullable: false, maxLength: 20),
                        ProfessionStatus = c.String(nullable: false, maxLength: 50),
                        Degree = c.String(nullable: false, maxLength: 50),
                        AcademicTitle = c.String(nullable: false, maxLength: 50),
                        Biography = c.Int(nullable: false),
                        PersonalInterests = c.String(maxLength: 50),
                        ImageId = c.Int(),
                        Localisation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Language", t => t.Localisation)
                .ForeignKey("dbo.Biographies", t => t.Biography)
                .Index(t => t.Biography)
                .Index(t => t.Localisation);
            
            CreateTable(
                "dbo.HallOfFame",
                c => new
                    {
                        GoodPersonId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GoodPersonId)
                .ForeignKey("dbo.People", t => t.PersonId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Language",
                c => new
                    {
                        Languageid = c.Int(nullable: false),
                        LanguageName = c.String(nullable: false, maxLength: 20),
                        LanguageCode = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Languageid);
            
            CreateTable(
                "dbo.EducationBlock",
                c => new
                    {
                        BlockId = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                        Description = c.String(unicode: false, storeType: "text"),
                        Image = c.Int(nullable: false),
                        Localisation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BlockId)
                .ForeignKey("dbo.Images", t => t.Image)
                .ForeignKey("dbo.Language", t => t.Localisation)
                .Index(t => t.Image)
                .Index(t => t.Localisation);
            
            CreateTable(
                "dbo.EducationTopics",
                c => new
                    {
                        TopicId = c.Int(nullable: false),
                        TopicName = c.String(maxLength: 50),
                        EducationBlockType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TopicId)
                .ForeignKey("dbo.EducationBlock", t => t.EducationBlockType)
                .Index(t => t.EducationBlockType);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageId = c.Int(nullable: false),
                        ImageName = c.String(nullable: false, maxLength: 50),
                        Image = c.Binary(nullable: false, storeType: "image"),
                    })
                .PrimaryKey(t => t.ImageId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false),
                        ProjectName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false),
                        DocumentId = c.Int(),
                        ShortDescription = c.String(maxLength: 400),
                        ProjectStatus = c.String(nullable: false, maxLength: 50),
                        ImageId = c.Int(),
                        Localisation = c.Int(nullable: false),
                        CreationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Documents", t => t.DocumentId)
                .ForeignKey("dbo.Images", t => t.ImageId)
                .ForeignKey("dbo.Language", t => t.Localisation)
                .Index(t => t.DocumentId)
                .Index(t => t.ImageId)
                .Index(t => t.Localisation);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        DocumentId = c.Int(nullable: false),
                        DocumentName = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        IsDeleted = c.Boolean(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        FileContent = c.Binary(nullable: false, maxLength: 4000, fixedLength: true),
                    })
                .PrimaryKey(t => t.DocumentId);
            
            CreateTable(
                "dbo.Seminars",
                c => new
                    {
                        SeminarId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        SpeakerId = c.Int(nullable: false),
                        EventDate = c.DateTime(nullable: false, storeType: "date"),
                        DocFile = c.Int(),
                        ResponsiblePersonId = c.Int(nullable: false),
                        Topic = c.Int(),
                        Localisation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SeminarId)
                .ForeignKey("dbo.Topics", t => t.Topic)
                .ForeignKey("dbo.Documents", t => t.DocFile)
                .ForeignKey("dbo.Language", t => t.Localisation)
                .Index(t => t.DocFile)
                .Index(t => t.Topic)
                .Index(t => t.Localisation);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        TopicId = c.Int(nullable: false),
                        TopicName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.TopicId);
            
            CreateTable(
                "dbo.Lectures",
                c => new
                    {
                        LectureId = c.Int(nullable: false),
                        LectureName = c.String(nullable: false, maxLength: 50),
                        SpesialisationId = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        Localisation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LectureId)
                .ForeignKey("dbo.Specialisations", t => t.SpesialisationId)
                .ForeignKey("dbo.Language", t => t.Localisation)
                .Index(t => t.SpesialisationId)
                .Index(t => t.Localisation);
            
            CreateTable(
                "dbo.PersonLecture",
                c => new
                    {
                        PersonId = c.Int(nullable: false),
                        LectureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PersonId, t.LectureId })
                .ForeignKey("dbo.Lectures", t => t.LectureId)
                .ForeignKey("dbo.People", t => t.LectureId)
                .Index(t => t.LectureId);
            
            CreateTable(
                "dbo.Specialisations",
                c => new
                    {
                        SpecialisationId = c.Int(nullable: false),
                        Specialisation = c.String(nullable: false, maxLength: 100),
                        Speciality = c.String(nullable: false, maxLength: 100),
                        Localiation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SpecialisationId)
                .ForeignKey("dbo.Language", t => t.Localiation)
                .Index(t => t.Localiation);
            
            CreateTable(
                "dbo.PreViews",
                c => new
                    {
                        PreViewId = c.Int(nullable: false),
                        PageType = c.Int(nullable: false),
                        ShortDescription = c.String(unicode: false, storeType: "text"),
                        Header = c.String(maxLength: 50),
                        Image = c.Binary(nullable: false, storeType: "image"),
                        Localisation = c.Int(),
                    })
                .PrimaryKey(t => t.PreViewId)
                .ForeignKey("dbo.PageType", t => t.PageType)
                .ForeignKey("dbo.Language", t => t.Localisation)
                .Index(t => t.PageType)
                .Index(t => t.Localisation);
            
            CreateTable(
                "dbo.PageType",
                c => new
                    {
                        PageTypeId = c.Int(nullable: false),
                        PageType = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.PageTypeId);
            
            CreateTable(
                "dbo.ProjectPerson",
                c => new
                    {
                        PersonId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PersonId, t.ProjectId })
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.PersonId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.SeminarPersons",
                c => new
                    {
                        Person = c.Int(nullable: false),
                        Seminar = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person, t.Seminar })
                .ForeignKey("dbo.People", t => t.Person, cascadeDelete: true)
                .ForeignKey("dbo.Seminars", t => t.Seminar, cascadeDelete: true)
                .Index(t => t.Person)
                .Index(t => t.Seminar);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "Biography", "dbo.Biographies");
            DropForeignKey("dbo.SeminarPersons", "Seminar", "dbo.Seminars");
            DropForeignKey("dbo.SeminarPersons", "Person", "dbo.People");
            DropForeignKey("dbo.ProjectPerson", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ProjectPerson", "PersonId", "dbo.People");
            DropForeignKey("dbo.PersonLecture", "LectureId", "dbo.People");
            DropForeignKey("dbo.Specialisations", "Localiation", "dbo.Language");
            DropForeignKey("dbo.Seminars", "Localisation", "dbo.Language");
            DropForeignKey("dbo.Projects", "Localisation", "dbo.Language");
            DropForeignKey("dbo.PreViews", "Localisation", "dbo.Language");
            DropForeignKey("dbo.PreViews", "PageType", "dbo.PageType");
            DropForeignKey("dbo.People", "Localisation", "dbo.Language");
            DropForeignKey("dbo.Lectures", "Localisation", "dbo.Language");
            DropForeignKey("dbo.Lectures", "SpesialisationId", "dbo.Specialisations");
            DropForeignKey("dbo.PersonLecture", "LectureId", "dbo.Lectures");
            DropForeignKey("dbo.EducationBlock", "Localisation", "dbo.Language");
            DropForeignKey("dbo.Projects", "ImageId", "dbo.Images");
            DropForeignKey("dbo.Seminars", "DocFile", "dbo.Documents");
            DropForeignKey("dbo.Seminars", "Topic", "dbo.Topics");
            DropForeignKey("dbo.Projects", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.EducationBlock", "Image", "dbo.Images");
            DropForeignKey("dbo.EducationTopics", "EducationBlockType", "dbo.EducationBlock");
            DropForeignKey("dbo.HallOfFame", "PersonId", "dbo.People");
            DropIndex("dbo.SeminarPersons", new[] { "Seminar" });
            DropIndex("dbo.SeminarPersons", new[] { "Person" });
            DropIndex("dbo.ProjectPerson", new[] { "ProjectId" });
            DropIndex("dbo.ProjectPerson", new[] { "PersonId" });
            DropIndex("dbo.PreViews", new[] { "Localisation" });
            DropIndex("dbo.PreViews", new[] { "PageType" });
            DropIndex("dbo.Specialisations", new[] { "Localiation" });
            DropIndex("dbo.PersonLecture", new[] { "LectureId" });
            DropIndex("dbo.Lectures", new[] { "Localisation" });
            DropIndex("dbo.Lectures", new[] { "SpesialisationId" });
            DropIndex("dbo.Seminars", new[] { "Localisation" });
            DropIndex("dbo.Seminars", new[] { "Topic" });
            DropIndex("dbo.Seminars", new[] { "DocFile" });
            DropIndex("dbo.Projects", new[] { "Localisation" });
            DropIndex("dbo.Projects", new[] { "ImageId" });
            DropIndex("dbo.Projects", new[] { "DocumentId" });
            DropIndex("dbo.EducationTopics", new[] { "EducationBlockType" });
            DropIndex("dbo.EducationBlock", new[] { "Localisation" });
            DropIndex("dbo.EducationBlock", new[] { "Image" });
            DropIndex("dbo.HallOfFame", new[] { "PersonId" });
            DropIndex("dbo.People", new[] { "Localisation" });
            DropIndex("dbo.People", new[] { "Biography" });
            DropTable("dbo.SeminarPersons");
            DropTable("dbo.ProjectPerson");
            DropTable("dbo.PageType");
            DropTable("dbo.PreViews");
            DropTable("dbo.Specialisations");
            DropTable("dbo.PersonLecture");
            DropTable("dbo.Lectures");
            DropTable("dbo.Topics");
            DropTable("dbo.Seminars");
            DropTable("dbo.Documents");
            DropTable("dbo.Projects");
            DropTable("dbo.Images");
            DropTable("dbo.EducationTopics");
            DropTable("dbo.EducationBlock");
            DropTable("dbo.Language");
            DropTable("dbo.HallOfFame");
            DropTable("dbo.People");
            DropTable("dbo.Biographies");
        }
    }
}
