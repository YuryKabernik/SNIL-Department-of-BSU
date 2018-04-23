using System.Data.Entity;

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

            // TODO: Remove into Configurations folder.
            modelBuilder.Entity<Biography>()
                .HasMany(e => e.People)
                .WithRequired(e => e.Biography1)
                .HasForeignKey(e => e.Biography)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Document>()
                .Property(e => e.DocumentName)
                .IsFixedLength();

            modelBuilder.Entity<Document>()
                .Property(e => e.FileContent)
                .IsFixedLength();

            modelBuilder.Entity<Document>()
                .HasMany(e => e.Seminars)
                .WithOptional(e => e.Document)
                .HasForeignKey(e => e.DocFile);

            modelBuilder.Entity<EducationBlock>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<EducationBlock>()
                .HasMany(e => e.EducationTopics)
                .WithRequired(e => e.EducationBlock)
                .HasForeignKey(e => e.EducationBlockType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Image>()
                .HasMany(e => e.EducationBlocks)
                .WithRequired(e => e.Image1)
                .HasForeignKey(e => e.Image)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Language>()
                .HasMany(e => e.EducationBlocks)
                .WithRequired(e => e.Language)
                .HasForeignKey(e => e.Localisation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Language>()
                .HasMany(e => e.Lectures)
                .WithRequired(e => e.Language)
                .HasForeignKey(e => e.Localisation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Language>()
                .HasMany(e => e.People)
                .WithRequired(e => e.Language)
                .HasForeignKey(e => e.Localisation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Language>()
                .HasMany(e => e.PreViews)
                .WithOptional(e => e.Language)
                .HasForeignKey(e => e.Localisation);

            modelBuilder.Entity<Language>()
                .HasMany(e => e.Projects)
                .WithRequired(e => e.Language)
                .HasForeignKey(e => e.Localisation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Language>()
                .HasMany(e => e.Seminars)
                .WithRequired(e => e.Language)
                .HasForeignKey(e => e.Localisation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Language>()
                .HasMany(e => e.Specialisations)
                .WithRequired(e => e.Language)
                .HasForeignKey(e => e.Localiation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lecture>()
                .HasMany(e => e.PersonLectures)
                .WithRequired(e => e.Lecture)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PageType>()
                .HasMany(e => e.PreViews)
                .WithRequired(e => e.PageType1)
                .HasForeignKey(e => e.PageType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.HallOfFames)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.PersonLectures)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.LectureId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Projects)
                .WithMany(e => e.People)
                .Map(m => m.ToTable("ProjectPerson").MapLeftKey("PersonId").MapRightKey("ProjectId"));

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Seminars)
                .WithMany(e => e.People)
                .Map(m => m.ToTable("SeminarPersons").MapLeftKey("Person").MapRightKey("Seminar"));

            modelBuilder.Entity<PreView>()
                .Property(e => e.ShortDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Specialisation>()
                .HasMany(e => e.Lectures)
                .WithRequired(e => e.Specialisation)
                .HasForeignKey(e => e.SpesialisationId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Topic>()
                .HasMany(e => e.Seminars)
                .WithOptional(e => e.Topic1)
                .HasForeignKey(e => e.Topic);
        }
    }
}
