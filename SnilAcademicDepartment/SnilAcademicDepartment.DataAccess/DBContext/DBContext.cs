using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SnilAcademicDepartment.DataAccess.Configurations;
using SnilAcademicDepartment.DataAccess.Migrations;
using SnilAcademicDepartment.DataAccess.Models;

namespace SnilAcademicDepartment.DataAccess
{

    public partial class SnilDBContext : DbContext
    {
        public SnilDBContext()
            : base("SNILDepartment2")
        {
            // Uncomment this to use migration
            // Database.SetInitializer(new MigrateDatabaseToLatestVersion<SnilDBContext, Configuration>("SNILDepartment2"));
        }

        public virtual DbSet<Biography> Biographies { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<EducationBlock> EducationBlocks { get; set; }
        public virtual DbSet<EducationTopic> EducationTopics { get; set; }
        public virtual DbSet<HallOfFame> HallOfFames { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Lecture> Lectures { get; set; }
        public virtual DbSet<PageType> PageTypes { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PreView> PreViews { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Seminar> Seminars { get; set; }
        public virtual DbSet<Specialisation> Specialisations { get; set; }
        // public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<StuffDepartment> StuffDepartment { get; set; }
        public virtual DbSet<StuffStudents> StuffStudents { get; set; }
        public virtual DbSet<StudentTypes> StudentTypes { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new BiographyConfig());
            modelBuilder.Configurations.Add(new DocumentConfig());
            modelBuilder.Configurations.Add(new EducationBlockConfig());
            modelBuilder.Configurations.Add(new EducationTopicConfiguration());
            modelBuilder.Configurations.Add(new HallOfFameConfiguration());
            modelBuilder.Configurations.Add(new ImageConfig());
            modelBuilder.Configurations.Add(new LanguageConfig());
            modelBuilder.Configurations.Add(new LectureConfig());
            modelBuilder.Configurations.Add(new PageTypeConfig());
            modelBuilder.Configurations.Add(new PersonConfig());
            modelBuilder.Configurations.Add(new PreViewConfig());
            modelBuilder.Configurations.Add(new SpecializationConfig());
            modelBuilder.Configurations.Add(new ProjectConfig());
            modelBuilder.Configurations.Add(new TopicConfig());
            modelBuilder.Configurations.Add(new StudentsConfig());
            modelBuilder.Configurations.Add(new StuffDepartmentConfig());
            modelBuilder.Configurations.Add(new StuffStudentsConfig());
            modelBuilder.Configurations.Add(new StudentTypesConfig());
		}
    }
}
