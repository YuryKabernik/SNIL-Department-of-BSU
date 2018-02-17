using SnilAcademicDepartment.DataAccess.Entities;
using System.Data.Entity;

namespace SnilAcademicDepartment.DataAccess.EF
{
    public sealed class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        public ApplicationDbContext()
            : base("SNILDepartment")
        {
            // Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>("IdentityDb"));
        }

        // DbSets of a models, that   article model.
        public IDbSet<ArticlePreview> ArticlePreviews { get; set; }
        public IDbSet<Article> Articles { get; set; }
        public IDbSet<Author> Authors { get; set; }

        // DbSets of an additional models.
        public IDbSet<CarouselItem> CarouselItems { get; set; }
        public IDbSet<EducationBlock> EducationBlocks { get; set; }

        // DbSets of a document type models.
        public IDbSet<Document> Documents { get; set; }
        public IDbSet<Image> Images { get; set; }
    }
}