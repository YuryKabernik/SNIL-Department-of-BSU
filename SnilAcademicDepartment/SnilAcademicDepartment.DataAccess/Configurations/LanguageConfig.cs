using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
    public static class LanguageConfig
    {
        public static void RegisterLanguage (this DbModelBuilder modelBuilder)
        {

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

        }
    }
}
