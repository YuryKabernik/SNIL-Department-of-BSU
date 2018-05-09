using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
    public class LanguageConfig : EntityTypeConfiguration<Language>
    {
        public LanguageConfig()
        {
            this.Property(p => p.LanguageId)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.Property(p => p.LanguageName)
                .HasMaxLength(25)
                .IsRequired();

            this.Property(p => p.LanguageCode)
                .IsRequired();

            this.HasMany(e => e.EducationBlocks)
                .WithRequired(e => e.Language)
                .HasForeignKey(e => e.Localisation)
                .WillCascadeOnDelete(false);

            this.HasMany(e => e.Lectures)
                .WithRequired(e => e.Language)
                .HasForeignKey(e => e.Localisation)
                .WillCascadeOnDelete(false);

            this.HasMany(e => e.People)
                .WithRequired(e => e.Language)
                .HasForeignKey(e => e.Localisation)
                .WillCascadeOnDelete(false);

            this.HasMany(e => e.PreViews)
                .WithOptional(e => e.Language)
                .HasForeignKey(e => e.Localisation);

            this.HasMany(e => e.Projects)
                .WithRequired(e => e.Language)
                .HasForeignKey(e => e.Localisation)
                .WillCascadeOnDelete(false);

            this.HasMany(e => e.Seminars)
                .WithRequired(e => e.Language)
                .HasForeignKey(e => e.Localisation)
                .WillCascadeOnDelete(false);

            this.HasMany(e => e.Specialisations)
                .WithRequired(e => e.Language)
                .HasForeignKey(e => e.Localiation)
                .WillCascadeOnDelete(false);
        }
    }
}
