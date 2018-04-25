using System.Data.Entity;
using SnilAcademicDepartment.DataAccess.Configurations;

namespace SnilAcademicDepartment.DataAccess
{

    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=SNILDepartment")
        {
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
        public virtual DbSet<PersonLecture> PersonLectures { get; set; }
        public virtual DbSet<PreView> PreViews { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Seminar> Seminars { get; set; }
        public virtual DbSet<Specialisation> Specialisations { get; set; }
        // public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.RegisterBiography();
            modelBuilder.RegisterDocument();
            modelBuilder.RegisterEducation();
            modelBuilder.RegisterImage();
            modelBuilder.RegisterLanguage();
            modelBuilder.RegisterLecture();
            modelBuilder.RegisterPageType();
            modelBuilder.RegisterPerson();
            modelBuilder.RegisterPreView();
            modelBuilder.RegisterSpecialization();
            modelBuilder.RegisterTopic();
        }
    }
}
