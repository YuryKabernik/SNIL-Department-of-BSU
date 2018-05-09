using System.Data.Entity.Migrations;
using System.Globalization;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using SnilAcademicDepartment.DataAccess.DBTypesInitialisation;

namespace SnilAcademicDepartment.DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SnilDBContext>
    {
        
        private PageType[] _pageTypes;

        private Language[] _languages;

        private Image _image;

        private byte[] _imgByte = File.ReadAllBytes(@"D:\GitHub_projects\SNIL\SNIL-Department-of-BSU\SnilAcademicDepartment\SnilAcademicDepartment.DataAccess\img\BSU3.jpg");

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SnilAcademicDepartment.DataAccess.SnilDBContext context)
        {
            using (var db = new SnilDBContext())
            {
                // Add image.
                ImageDBInit.DBInit(db, this._imgByte, out this._image);

                // Add EducationTopics.
                // TODO: зАКОНЧИТЬ ИНИЦИАЛИЗАЦИЮ Топиков и Блоков.
                EducationTopicDBInit.DBInit(db, "Gene Expression of Secondary Messengers and Replicates");
                EducationTopicDBInit.DBInit(db, "Genomic and Molecular Genetic Directions in the Area of Infectology");
                EducationTopicDBInit.DBInit(db, "Software GeneExpressionAnalyser for analysis of DNA microarrays");
                EducationTopicDBInit.DBInit(db, "Analysis of DNA microarrays");
                EducationTopicDBInit.DBInit(db, "Digital processing biology images");
                EducationTopicDBInit.DBInit(db, "Software CellDataMiner for Analysis of Luminescence Images of Cancer Cells");

                // Add page types.
                PageTypeDBInit.DBInit(db, out this._pageTypes);

                // Add languages.
                LanguageDBInit.DBInit(db, out this._languages);

                // Init History page preview data.
                PreviewDBInit.DBInit(db, "History", this._pageTypes[4], this._languages[1], this._imgByte);
                PreviewDBInit.DBInit(db, "История", this._pageTypes[4], this._languages[0], this._imgByte);
                PreviewDBInit.DBInit(db, "ИсторияDE", this._pageTypes[4], this._languages[2], this._imgByte);

                // Init People page preview data.
                PreviewDBInit.DBInit(db, "People", this._pageTypes[3], this._languages[1], this._imgByte);
                PreviewDBInit.DBInit(db, "Персонал", this._pageTypes[3], this._languages[0], this._imgByte);
                PreviewDBInit.DBInit(db, "ПерсоналDE", this._pageTypes[3], this._languages[2], this._imgByte);

                // Init Home page preview data.
                PreviewDBInit.DBInit(db, "Home", this._pageTypes[2], this._languages[1], this._imgByte);
                PreviewDBInit.DBInit(db, "Дом", this._pageTypes[2], this._languages[0], this._imgByte);
                PreviewDBInit.DBInit(db, "ДомDE", this._pageTypes[2], this._languages[2], this._imgByte);

                // Init Projects page preview data.
                PreviewDBInit.DBInit(db, "Projects", this._pageTypes[1], this._languages[1], this._imgByte);
                PreviewDBInit.DBInit(db, "Проекты", this._pageTypes[1], this._languages[0], this._imgByte);
                PreviewDBInit.DBInit(db, "ПроектыDE", this._pageTypes[1], this._languages[2], this._imgByte);

                // Init Education page preview data.
                PreviewDBInit.DBInit(db, "Education", this._pageTypes[0], this._languages[1], this._imgByte);
                PreviewDBInit.DBInit(db, "Обучение", this._pageTypes[0], this._languages[0], this._imgByte);
                PreviewDBInit.DBInit(db, "ОбучениеDE", this._pageTypes[0], this._languages[2], this._imgByte);
            }
        }
    }
}
