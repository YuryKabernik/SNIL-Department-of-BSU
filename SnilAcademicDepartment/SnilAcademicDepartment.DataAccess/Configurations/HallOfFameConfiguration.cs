using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
    class HallOfFameConfiguration : EntityTypeConfiguration<HallOfFame>
    {
        public HallOfFameConfiguration()
        {
            this.HasKey(p => p.GoodPersonId);

            this.Property(p => p.GoodPersonId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
