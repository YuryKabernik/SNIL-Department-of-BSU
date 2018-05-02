namespace SnilAcademicDepartment.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditAfterExtractingConfigs : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProjectPerson", newName: "ProjectPersons");
            DropForeignKey("dbo.PersonLecture", "LectureId", "dbo.Lectures");
            DropForeignKey("dbo.PersonLecture", "LectureId", "dbo.People");
            DropForeignKey("dbo.HallOfFame", "PersonId", "dbo.People");
            DropForeignKey("dbo.People", "Biography", "dbo.Biographies");
            DropForeignKey("dbo.ProjectPerson", "PersonId", "dbo.People");
            DropForeignKey("dbo.SeminarPersons", "Person", "dbo.People");
            DropForeignKey("dbo.EducationBlock", "Localisation", "dbo.Language");
            DropForeignKey("dbo.Lectures", "Localisation", "dbo.Language");
            DropForeignKey("dbo.People", "Localisation", "dbo.Language");
            DropForeignKey("dbo.PreViews", "Localisation", "dbo.Language");
            DropForeignKey("dbo.Projects", "Localisation", "dbo.Language");
            DropForeignKey("dbo.Seminars", "Localisation", "dbo.Language");
            DropForeignKey("dbo.Specialisations", "Localiation", "dbo.Language");
            DropForeignKey("dbo.EducationTopics", "EducationBlockType", "dbo.EducationBlock");
            DropForeignKey("dbo.EducationBlock", "Image", "dbo.Images");
            DropForeignKey("dbo.Projects", "ImageId", "dbo.Images");
            DropForeignKey("dbo.ProjectPerson", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.Seminars", "DocFile", "dbo.Documents");
            DropForeignKey("dbo.Seminars", "Topic", "dbo.Topics");
            DropForeignKey("dbo.Lectures", "SpesialisationId", "dbo.Specialisations");
            DropForeignKey("dbo.PreViews", "PageType", "dbo.PageType");
            DropIndex("dbo.PersonLecture", new[] { "LectureId" });
            RenameColumn(table: "dbo.ProjectPersons", name: "PersonId", newName: "Person_PersonId");
            RenameColumn(table: "dbo.ProjectPersons", name: "ProjectId", newName: "Project_ProjectId");
            RenameColumn(table: "dbo.SeminarPersons", name: "Person", newName: "Person_PersonId");
            RenameColumn(table: "dbo.SeminarPersons", name: "Seminar", newName: "Seminar_SeminarId");
            RenameColumn(table: "dbo.Seminars", name: "DocFile", newName: "DoctId");
            RenameIndex(table: "dbo.Seminars", name: "IX_DocFile", newName: "IX_DoctId");
            RenameIndex(table: "dbo.SeminarPersons", name: "IX_Seminar", newName: "IX_Seminar_SeminarId");
            RenameIndex(table: "dbo.SeminarPersons", name: "IX_Person", newName: "IX_Person_PersonId");
            RenameIndex(table: "dbo.ProjectPersons", name: "IX_ProjectId", newName: "IX_Project_ProjectId");
            RenameIndex(table: "dbo.ProjectPersons", name: "IX_PersonId", newName: "IX_Person_PersonId");
            DropPrimaryKey("dbo.Biographies");
            DropPrimaryKey("dbo.People");
            DropPrimaryKey("dbo.HallOfFame");
            DropPrimaryKey("dbo.Language");
            DropPrimaryKey("dbo.EducationBlock");
            DropPrimaryKey("dbo.EducationTopics");
            DropPrimaryKey("dbo.Images");
            DropPrimaryKey("dbo.Projects");
            DropPrimaryKey("dbo.Documents");
            DropPrimaryKey("dbo.Topics");
            DropPrimaryKey("dbo.Lectures");
            DropPrimaryKey("dbo.Specialisations");
            DropPrimaryKey("dbo.PreViews");
            DropPrimaryKey("dbo.PageType");
            DropPrimaryKey("dbo.ProjectPersons");
            DropPrimaryKey("dbo.SeminarPersons");
            CreateTable(
                "dbo.LecturePersons",
                c => new
                    {
                        Lecture_LectureId = c.Int(nullable: false),
                        Person_PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Lecture_LectureId, t.Person_PersonId })
                .ForeignKey("dbo.Lectures", t => t.Lecture_LectureId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.Person_PersonId, cascadeDelete: true)
                .Index(t => t.Lecture_LectureId)
                .Index(t => t.Person_PersonId);
            
            AddColumn("dbo.People", "Image_ImageId", c => c.Int());
            AddColumn("dbo.EducationTopics", "EducationTopicId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Specialisations", "SpecialisationName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.PageType", "PageTypeName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Biographies", "BiographyId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.People", "PersonId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.People", "PersonName", c => c.String());
            AlterColumn("dbo.People", "SecoundName", c => c.String());
            AlterColumn("dbo.People", "FathersName", c => c.String());
            AlterColumn("dbo.People", "ProfessionStatus", c => c.String());
            AlterColumn("dbo.People", "Degree", c => c.String());
            AlterColumn("dbo.People", "AcademicTitle", c => c.String());
            AlterColumn("dbo.People", "PersonalInterests", c => c.String());
            AlterColumn("dbo.HallOfFame", "GoodPersonId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Language", "LanguageId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Language", "LanguageName", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Language", "LanguageCode", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.EducationBlock", "BlockId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.EducationTopics", "TopicName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Images", "ImageId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Projects", "ProjectId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Projects", "ShortDescription", c => c.String(nullable: false, maxLength: 400));
            AlterColumn("dbo.Documents", "DocumentId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Documents", "DocumentName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Documents", "FileContent", c => c.Binary(nullable: false, maxLength: 8000));
            AlterColumn("dbo.Topics", "TopicId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Lectures", "LectureId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Specialisations", "SpecialisationId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.PreViews", "PreViewId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.PreViews", "ShortDescription", c => c.String(nullable: false, unicode: false, storeType: "text"));
            AlterColumn("dbo.PreViews", "Header", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.PageType", "PageTypeId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Biographies", "BiographyId");
            AddPrimaryKey("dbo.People", "PersonId");
            AddPrimaryKey("dbo.HallOfFame", "GoodPersonId");
            AddPrimaryKey("dbo.Language", "LanguageId");
            AddPrimaryKey("dbo.EducationBlock", "BlockId");
            AddPrimaryKey("dbo.EducationTopics", "EducationTopicId");
            AddPrimaryKey("dbo.Images", "ImageId");
            AddPrimaryKey("dbo.Projects", "ProjectId");
            AddPrimaryKey("dbo.Documents", "DocumentId");
            AddPrimaryKey("dbo.Topics", "TopicId");
            AddPrimaryKey("dbo.Lectures", "LectureId");
            AddPrimaryKey("dbo.Specialisations", "SpecialisationId");
            AddPrimaryKey("dbo.PreViews", "PreViewId");
            AddPrimaryKey("dbo.PageType", "PageTypeId");
            AddPrimaryKey("dbo.ProjectPersons", new[] { "Project_ProjectId", "Person_PersonId" });
            AddPrimaryKey("dbo.SeminarPersons", new[] { "Seminar_SeminarId", "Person_PersonId" });
            CreateIndex("dbo.People", "Image_ImageId");
            AddForeignKey("dbo.People", "Image_ImageId", "dbo.Images", "ImageId");
            AddForeignKey("dbo.HallOfFame", "PersonId", "dbo.People", "PersonId", cascadeDelete: true);
            AddForeignKey("dbo.People", "Biography", "dbo.Biographies", "BiographyId");
            AddForeignKey("dbo.SeminarPersons", "Person_PersonId", "dbo.People", "PersonId", cascadeDelete: true);
            AddForeignKey("dbo.ProjectPersons", "Person_PersonId", "dbo.People", "PersonId", cascadeDelete: true);
            AddForeignKey("dbo.EducationBlock", "Localisation", "dbo.Language", "LanguageId");
            AddForeignKey("dbo.Lectures", "Localisation", "dbo.Language", "LanguageId");
            AddForeignKey("dbo.People", "Localisation", "dbo.Language", "LanguageId");
            AddForeignKey("dbo.PreViews", "Localisation", "dbo.Language", "LanguageId");
            AddForeignKey("dbo.Projects", "Localisation", "dbo.Language", "LanguageId");
            AddForeignKey("dbo.Seminars", "Localisation", "dbo.Language", "LanguageId");
            AddForeignKey("dbo.Specialisations", "Localiation", "dbo.Language", "LanguageId");
            AddForeignKey("dbo.EducationTopics", "EducationBlockType", "dbo.EducationBlock", "BlockId");
            AddForeignKey("dbo.Projects", "ImageId", "dbo.Images", "ImageId");
            AddForeignKey("dbo.EducationBlock", "Image", "dbo.Images", "ImageId");
            AddForeignKey("dbo.ProjectPersons", "Project_ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: true);
            AddForeignKey("dbo.Projects", "DocumentId", "dbo.Documents", "DocumentId");
            AddForeignKey("dbo.Seminars", "DoctId", "dbo.Documents", "DocumentId");
            AddForeignKey("dbo.Seminars", "Topic", "dbo.Topics", "TopicId");
            AddForeignKey("dbo.Lectures", "SpesialisationId", "dbo.Specialisations", "SpecialisationId");
            AddForeignKey("dbo.PreViews", "PageType", "dbo.PageType", "PageTypeId");
            DropColumn("dbo.People", "ImageId");
            DropColumn("dbo.EducationTopics", "TopicId");
            DropColumn("dbo.Specialisations", "Specialisation");
            DropColumn("dbo.PageType", "PageType");
            DropTable("dbo.PersonLecture");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PersonLecture",
                c => new
                    {
                        PersonId = c.Int(nullable: false),
                        LectureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PersonId, t.LectureId });
            
            AddColumn("dbo.PageType", "PageType", c => c.String(maxLength: 50));
            AddColumn("dbo.Specialisations", "Specialisation", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.EducationTopics", "TopicId", c => c.Int(nullable: false));
            AddColumn("dbo.People", "ImageId", c => c.Int());
            DropForeignKey("dbo.PreViews", "PageType", "dbo.PageType");
            DropForeignKey("dbo.Lectures", "SpesialisationId", "dbo.Specialisations");
            DropForeignKey("dbo.Seminars", "Topic", "dbo.Topics");
            DropForeignKey("dbo.Seminars", "DoctId", "dbo.Documents");
            DropForeignKey("dbo.Projects", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.ProjectPersons", "Project_ProjectId", "dbo.Projects");
            DropForeignKey("dbo.EducationBlock", "Image", "dbo.Images");
            DropForeignKey("dbo.Projects", "ImageId", "dbo.Images");
            DropForeignKey("dbo.EducationTopics", "EducationBlockType", "dbo.EducationBlock");
            DropForeignKey("dbo.Specialisations", "Localiation", "dbo.Language");
            DropForeignKey("dbo.Seminars", "Localisation", "dbo.Language");
            DropForeignKey("dbo.Projects", "Localisation", "dbo.Language");
            DropForeignKey("dbo.PreViews", "Localisation", "dbo.Language");
            DropForeignKey("dbo.People", "Localisation", "dbo.Language");
            DropForeignKey("dbo.Lectures", "Localisation", "dbo.Language");
            DropForeignKey("dbo.EducationBlock", "Localisation", "dbo.Language");
            DropForeignKey("dbo.ProjectPersons", "Person_PersonId", "dbo.People");
            DropForeignKey("dbo.SeminarPersons", "Person_PersonId", "dbo.People");
            DropForeignKey("dbo.People", "Biography", "dbo.Biographies");
            DropForeignKey("dbo.HallOfFame", "PersonId", "dbo.People");
            DropForeignKey("dbo.People", "Image_ImageId", "dbo.Images");
            DropForeignKey("dbo.LecturePersons", "Person_PersonId", "dbo.People");
            DropForeignKey("dbo.LecturePersons", "Lecture_LectureId", "dbo.Lectures");
            DropIndex("dbo.LecturePersons", new[] { "Person_PersonId" });
            DropIndex("dbo.LecturePersons", new[] { "Lecture_LectureId" });
            DropIndex("dbo.People", new[] { "Image_ImageId" });
            DropPrimaryKey("dbo.SeminarPersons");
            DropPrimaryKey("dbo.ProjectPersons");
            DropPrimaryKey("dbo.PageType");
            DropPrimaryKey("dbo.PreViews");
            DropPrimaryKey("dbo.Specialisations");
            DropPrimaryKey("dbo.Lectures");
            DropPrimaryKey("dbo.Topics");
            DropPrimaryKey("dbo.Documents");
            DropPrimaryKey("dbo.Projects");
            DropPrimaryKey("dbo.Images");
            DropPrimaryKey("dbo.EducationTopics");
            DropPrimaryKey("dbo.EducationBlock");
            DropPrimaryKey("dbo.Language");
            DropPrimaryKey("dbo.HallOfFame");
            DropPrimaryKey("dbo.People");
            DropPrimaryKey("dbo.Biographies");
            AlterColumn("dbo.PageType", "PageTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.PreViews", "Header", c => c.String(maxLength: 50));
            AlterColumn("dbo.PreViews", "ShortDescription", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.PreViews", "PreViewId", c => c.Int(nullable: false));
            AlterColumn("dbo.Specialisations", "SpecialisationId", c => c.Int(nullable: false));
            AlterColumn("dbo.Lectures", "LectureId", c => c.Int(nullable: false));
            AlterColumn("dbo.Topics", "TopicId", c => c.Int(nullable: false));
            AlterColumn("dbo.Documents", "FileContent", c => c.Binary(nullable: false, maxLength: 4000, fixedLength: true));
            AlterColumn("dbo.Documents", "DocumentName", c => c.String(nullable: false, maxLength: 10, fixedLength: true));
            AlterColumn("dbo.Documents", "DocumentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Projects", "ShortDescription", c => c.String(maxLength: 400));
            AlterColumn("dbo.Projects", "ProjectId", c => c.Int(nullable: false));
            AlterColumn("dbo.Images", "ImageId", c => c.Int(nullable: false));
            AlterColumn("dbo.EducationTopics", "TopicName", c => c.String(maxLength: 50));
            AlterColumn("dbo.EducationBlock", "BlockId", c => c.Int(nullable: false));
            AlterColumn("dbo.Language", "LanguageCode", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Language", "LanguageName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Language", "LanguageId", c => c.Int(nullable: false));
            AlterColumn("dbo.HallOfFame", "GoodPersonId", c => c.Int(nullable: false));
            AlterColumn("dbo.People", "PersonalInterests", c => c.String(maxLength: 50));
            AlterColumn("dbo.People", "AcademicTitle", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.People", "Degree", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.People", "ProfessionStatus", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.People", "FathersName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.People", "SecoundName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.People", "PersonName", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.People", "PersonId", c => c.Int(nullable: false));
            AlterColumn("dbo.Biographies", "BiographyId", c => c.Int(nullable: false));
            DropColumn("dbo.PageType", "PageTypeName");
            DropColumn("dbo.Specialisations", "SpecialisationName");
            DropColumn("dbo.EducationTopics", "EducationTopicId");
            DropColumn("dbo.People", "Image_ImageId");
            DropTable("dbo.LecturePersons");
            AddPrimaryKey("dbo.SeminarPersons", new[] { "Person", "Seminar" });
            AddPrimaryKey("dbo.ProjectPersons", new[] { "PersonId", "ProjectId" });
            AddPrimaryKey("dbo.PageType", "PageTypeId");
            AddPrimaryKey("dbo.PreViews", "PreViewId");
            AddPrimaryKey("dbo.Specialisations", "SpecialisationId");
            AddPrimaryKey("dbo.Lectures", "LectureId");
            AddPrimaryKey("dbo.Topics", "TopicId");
            AddPrimaryKey("dbo.Documents", "DocumentId");
            AddPrimaryKey("dbo.Projects", "ProjectId");
            AddPrimaryKey("dbo.Images", "ImageId");
            AddPrimaryKey("dbo.EducationTopics", "TopicId");
            AddPrimaryKey("dbo.EducationBlock", "BlockId");
            AddPrimaryKey("dbo.Language", "Languageid");
            AddPrimaryKey("dbo.HallOfFame", "GoodPersonId");
            AddPrimaryKey("dbo.People", "PersonId");
            AddPrimaryKey("dbo.Biographies", "BiographyId");
            RenameIndex(table: "dbo.ProjectPersons", name: "IX_Person_PersonId", newName: "IX_PersonId");
            RenameIndex(table: "dbo.ProjectPersons", name: "IX_Project_ProjectId", newName: "IX_ProjectId");
            RenameIndex(table: "dbo.SeminarPersons", name: "IX_Person_PersonId", newName: "IX_Person");
            RenameIndex(table: "dbo.SeminarPersons", name: "IX_Seminar_SeminarId", newName: "IX_Seminar");
            RenameIndex(table: "dbo.Seminars", name: "IX_DoctId", newName: "IX_DocFile");
            RenameColumn(table: "dbo.Seminars", name: "DoctId", newName: "DocFile");
            RenameColumn(table: "dbo.SeminarPersons", name: "Seminar_SeminarId", newName: "Seminar");
            RenameColumn(table: "dbo.SeminarPersons", name: "Person_PersonId", newName: "Person");
            RenameColumn(table: "dbo.ProjectPersons", name: "Project_ProjectId", newName: "ProjectId");
            RenameColumn(table: "dbo.ProjectPersons", name: "Person_PersonId", newName: "PersonId");
            CreateIndex("dbo.PersonLecture", "LectureId");
            AddForeignKey("dbo.PreViews", "PageType", "dbo.PageType", "PageTypeId");
            AddForeignKey("dbo.Lectures", "SpesialisationId", "dbo.Specialisations", "SpecialisationId");
            AddForeignKey("dbo.Seminars", "Topic", "dbo.Topics", "TopicId");
            AddForeignKey("dbo.Seminars", "DocFile", "dbo.Documents", "DocumentId");
            AddForeignKey("dbo.Projects", "DocumentId", "dbo.Documents", "DocumentId");
            AddForeignKey("dbo.ProjectPerson", "ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: true);
            AddForeignKey("dbo.Projects", "ImageId", "dbo.Images", "ImageId");
            AddForeignKey("dbo.EducationBlock", "Image", "dbo.Images", "ImageId");
            AddForeignKey("dbo.EducationTopics", "EducationBlockType", "dbo.EducationBlock", "BlockId");
            AddForeignKey("dbo.Specialisations", "Localiation", "dbo.Language", "Languageid");
            AddForeignKey("dbo.Seminars", "Localisation", "dbo.Language", "Languageid");
            AddForeignKey("dbo.Projects", "Localisation", "dbo.Language", "Languageid");
            AddForeignKey("dbo.PreViews", "Localisation", "dbo.Language", "Languageid");
            AddForeignKey("dbo.People", "Localisation", "dbo.Language", "Languageid");
            AddForeignKey("dbo.Lectures", "Localisation", "dbo.Language", "Languageid");
            AddForeignKey("dbo.EducationBlock", "Localisation", "dbo.Language", "Languageid");
            AddForeignKey("dbo.SeminarPersons", "Person", "dbo.People", "PersonId", cascadeDelete: true);
            AddForeignKey("dbo.ProjectPerson", "PersonId", "dbo.People", "PersonId", cascadeDelete: true);
            AddForeignKey("dbo.People", "Biography", "dbo.Biographies", "BiographyId");
            AddForeignKey("dbo.HallOfFame", "PersonId", "dbo.People", "PersonId");
            AddForeignKey("dbo.PersonLecture", "LectureId", "dbo.People", "PersonId");
            AddForeignKey("dbo.PersonLecture", "LectureId", "dbo.Lectures", "LectureId");
            RenameTable(name: "dbo.ProjectPersons", newName: "ProjectPerson");
        }
    }
}
