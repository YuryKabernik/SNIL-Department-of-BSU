namespace SnilAcademicDepartment.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CodeFirstFromDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Biographies",
                c => new
                    {
                        BiographyId = c.Int(nullable: false, identity: true),
                        Biography = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BiographyId);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        PersonName = c.String(),
                        SecoundName = c.String(),
                        FathersName = c.String(),
                        ProfessionStatus = c.String(),
                        Degree = c.String(),
                        AcademicTitle = c.String(),
                        Biography = c.Int(nullable: false),
                        PersonalInterests = c.String(),
                        Localisation = c.Int(nullable: false),
                        Image_ImageId = c.Int(),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Language", t => t.Localisation)
                .ForeignKey("dbo.Image", t => t.Image_ImageId)
                .ForeignKey("dbo.Biographies", t => t.Biography)
                .Index(t => t.Biography)
                .Index(t => t.Localisation)
                .Index(t => t.Image_ImageId);
            
            CreateTable(
                "dbo.HallOfFame",
                c => new
                    {
                        GoodPersonId = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GoodPersonId)
                .ForeignKey("dbo.Person", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Image",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ImageName = c.String(nullable: false, maxLength: 50),
                        Image = c.Binary(nullable: false, storeType: "image"),
                    })
                .PrimaryKey(t => t.ImageId);
            
            CreateTable(
                "dbo.EducationBlock",
                c => new
                    {
                        BlockId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(unicode: false, storeType: "text"),
                        Image = c.Int(nullable: false),
                        Localisation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BlockId)
                .ForeignKey("dbo.Language", t => t.Localisation)
                .ForeignKey("dbo.Image", t => t.Image)
                .Index(t => t.Image)
                .Index(t => t.Localisation);
            
            CreateTable(
                "dbo.EducationTopic",
                c => new
                    {
                        EducationTopicId = c.Int(nullable: false, identity: true),
                        TopicName = c.String(nullable: false, maxLength: 50),
                        EducationBlockType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EducationTopicId)
                .ForeignKey("dbo.EducationBlock", t => t.EducationBlockType)
                .Index(t => t.EducationBlockType);
            
            CreateTable(
                "dbo.Language",
                c => new
                    {
                        LanguageId = c.Int(nullable: false, identity: true),
                        LanguageName = c.String(nullable: false, maxLength: 25),
                        LanguageCode = c.String(nullable: false, maxLength: 5),
                    })
                .PrimaryKey(t => t.LanguageId);
            
            CreateTable(
                "dbo.Lecture",
                c => new
                    {
                        LectureId = c.Int(nullable: false, identity: true),
                        LectureName = c.String(nullable: false, maxLength: 50),
                        SpesialisationId = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        Localisation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LectureId)
                .ForeignKey("dbo.Specialisation", t => t.SpesialisationId)
                .ForeignKey("dbo.Language", t => t.Localisation)
                .Index(t => t.SpesialisationId)
                .Index(t => t.Localisation);
            
            CreateTable(
                "dbo.Specialisation",
                c => new
                    {
                        SpecialisationId = c.Int(nullable: false, identity: true),
                        SpecialisationName = c.String(nullable: false, maxLength: 100),
                        Speciality = c.String(nullable: false, maxLength: 100),
                        Localiation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SpecialisationId)
                .ForeignKey("dbo.Language", t => t.Localiation)
                .Index(t => t.Localiation);
            
            CreateTable(
                "dbo.PreView",
                c => new
                    {
                        PreViewId = c.Int(nullable: false, identity: true),
                        PageType = c.Int(nullable: false),
                        ShortDescription = c.String(nullable: false, unicode: false, storeType: "text"),
                        Header = c.String(nullable: false, maxLength: 50),
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
                        PageTypeId = c.Int(nullable: false, identity: true),
                        PageTypeName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.PageTypeId);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false),
                        DocumentId = c.Int(),
                        ShortDescription = c.String(nullable: false, maxLength: 400),
                        ProjectStatus = c.String(nullable: false, maxLength: 50),
                        ImageId = c.Int(),
                        Localisation = c.Int(nullable: false),
                        CreationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Document", t => t.DocumentId)
                .ForeignKey("dbo.Image", t => t.ImageId)
                .ForeignKey("dbo.Language", t => t.Localisation)
                .Index(t => t.DocumentId)
                .Index(t => t.ImageId)
                .Index(t => t.Localisation);
            
            CreateTable(
                "dbo.Document",
                c => new
                    {
                        DocumentId = c.Int(nullable: false, identity: true),
                        DocumentName = c.String(nullable: false, maxLength: 50),
                        IsDeleted = c.Boolean(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        FileContent = c.Binary(nullable: false, maxLength: 8000),
                    })
                .PrimaryKey(t => t.DocumentId);
            
            CreateTable(
                "dbo.Seminar",
                c => new
                    {
                        SeminarId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        SpeakerId = c.Int(nullable: false),
                        EventDate = c.DateTime(nullable: false, storeType: "date"),
                        DoctId = c.Int(),
                        ResponsiblePersonId = c.Int(nullable: false),
                        Topic = c.Int(),
                        Localisation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SeminarId)
                .ForeignKey("dbo.Topic", t => t.Topic)
                .ForeignKey("dbo.Document", t => t.DoctId)
                .ForeignKey("dbo.Language", t => t.Localisation)
                .Index(t => t.DoctId)
                .Index(t => t.Topic)
                .Index(t => t.Localisation);
            
            CreateTable(
                "dbo.Topic",
                c => new
                    {
                        TopicId = c.Int(nullable: false, identity: true),
                        TopicName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.TopicId);
            
            CreateTable(
                "dbo.LecturePerson",
                c => new
                    {
                        Lecture_LectureId = c.Int(nullable: false),
                        Person_PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Lecture_LectureId, t.Person_PersonId })
                .ForeignKey("dbo.Lecture", t => t.Lecture_LectureId, cascadeDelete: true)
                .ForeignKey("dbo.Person", t => t.Person_PersonId, cascadeDelete: true)
                .Index(t => t.Lecture_LectureId)
                .Index(t => t.Person_PersonId);
            
            CreateTable(
                "dbo.SeminarPerson",
                c => new
                    {
                        Seminar_SeminarId = c.Int(nullable: false),
                        Person_PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Seminar_SeminarId, t.Person_PersonId })
                .ForeignKey("dbo.Seminar", t => t.Seminar_SeminarId, cascadeDelete: true)
                .ForeignKey("dbo.Person", t => t.Person_PersonId, cascadeDelete: true)
                .Index(t => t.Seminar_SeminarId)
                .Index(t => t.Person_PersonId);
            
            CreateTable(
                "dbo.ProjectPerson",
                c => new
                    {
                        Project_ProjectId = c.Int(nullable: false),
                        Person_PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Project_ProjectId, t.Person_PersonId })
                .ForeignKey("dbo.Project", t => t.Project_ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Person", t => t.Person_PersonId, cascadeDelete: true)
                .Index(t => t.Project_ProjectId)
                .Index(t => t.Person_PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Person", "Biography", "dbo.Biographies");
            DropForeignKey("dbo.Person", "Image_ImageId", "dbo.Image");
            DropForeignKey("dbo.EducationBlock", "Image", "dbo.Image");
            DropForeignKey("dbo.Specialisation", "Localiation", "dbo.Language");
            DropForeignKey("dbo.Seminar", "Localisation", "dbo.Language");
            DropForeignKey("dbo.Project", "Localisation", "dbo.Language");
            DropForeignKey("dbo.ProjectPerson", "Person_PersonId", "dbo.Person");
            DropForeignKey("dbo.ProjectPerson", "Project_ProjectId", "dbo.Project");
            DropForeignKey("dbo.Project", "ImageId", "dbo.Image");
            DropForeignKey("dbo.Seminar", "DoctId", "dbo.Document");
            DropForeignKey("dbo.Seminar", "Topic", "dbo.Topic");
            DropForeignKey("dbo.SeminarPerson", "Person_PersonId", "dbo.Person");
            DropForeignKey("dbo.SeminarPerson", "Seminar_SeminarId", "dbo.Seminar");
            DropForeignKey("dbo.Project", "DocumentId", "dbo.Document");
            DropForeignKey("dbo.PreView", "Localisation", "dbo.Language");
            DropForeignKey("dbo.PreView", "PageType", "dbo.PageType");
            DropForeignKey("dbo.Person", "Localisation", "dbo.Language");
            DropForeignKey("dbo.Lecture", "Localisation", "dbo.Language");
            DropForeignKey("dbo.Lecture", "SpesialisationId", "dbo.Specialisation");
            DropForeignKey("dbo.LecturePerson", "Person_PersonId", "dbo.Person");
            DropForeignKey("dbo.LecturePerson", "Lecture_LectureId", "dbo.Lecture");
            DropForeignKey("dbo.EducationBlock", "Localisation", "dbo.Language");
            DropForeignKey("dbo.EducationTopic", "EducationBlockType", "dbo.EducationBlock");
            DropForeignKey("dbo.HallOfFame", "PersonId", "dbo.Person");
            DropIndex("dbo.ProjectPerson", new[] { "Person_PersonId" });
            DropIndex("dbo.ProjectPerson", new[] { "Project_ProjectId" });
            DropIndex("dbo.SeminarPerson", new[] { "Person_PersonId" });
            DropIndex("dbo.SeminarPerson", new[] { "Seminar_SeminarId" });
            DropIndex("dbo.LecturePerson", new[] { "Person_PersonId" });
            DropIndex("dbo.LecturePerson", new[] { "Lecture_LectureId" });
            DropIndex("dbo.Seminar", new[] { "Localisation" });
            DropIndex("dbo.Seminar", new[] { "Topic" });
            DropIndex("dbo.Seminar", new[] { "DoctId" });
            DropIndex("dbo.Project", new[] { "Localisation" });
            DropIndex("dbo.Project", new[] { "ImageId" });
            DropIndex("dbo.Project", new[] { "DocumentId" });
            DropIndex("dbo.PreView", new[] { "Localisation" });
            DropIndex("dbo.PreView", new[] { "PageType" });
            DropIndex("dbo.Specialisation", new[] { "Localiation" });
            DropIndex("dbo.Lecture", new[] { "Localisation" });
            DropIndex("dbo.Lecture", new[] { "SpesialisationId" });
            DropIndex("dbo.EducationTopic", new[] { "EducationBlockType" });
            DropIndex("dbo.EducationBlock", new[] { "Localisation" });
            DropIndex("dbo.EducationBlock", new[] { "Image" });
            DropIndex("dbo.HallOfFame", new[] { "PersonId" });
            DropIndex("dbo.Person", new[] { "Image_ImageId" });
            DropIndex("dbo.Person", new[] { "Localisation" });
            DropIndex("dbo.Person", new[] { "Biography" });
            DropTable("dbo.ProjectPerson");
            DropTable("dbo.SeminarPerson");
            DropTable("dbo.LecturePerson");
            DropTable("dbo.Topic");
            DropTable("dbo.Seminar");
            DropTable("dbo.Document");
            DropTable("dbo.Project");
            DropTable("dbo.PageType");
            DropTable("dbo.PreView");
            DropTable("dbo.Specialisation");
            DropTable("dbo.Lecture");
            DropTable("dbo.Language");
            DropTable("dbo.EducationTopic");
            DropTable("dbo.EducationBlock");
            DropTable("dbo.Image");
            DropTable("dbo.HallOfFame");
            DropTable("dbo.Person");
            DropTable("dbo.Biographies");
        }
    }
}
