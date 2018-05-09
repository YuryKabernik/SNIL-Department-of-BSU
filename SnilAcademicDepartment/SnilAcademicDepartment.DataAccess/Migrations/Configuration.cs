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

        private byte[] _img = File.ReadAllBytes(@"D:\GitHub_projects\SNIL\SNIL-Department-of-BSU\SnilAcademicDepartment\SnilAcademicDepartment.DataAccess\img\BSU3.jpg");

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SnilAcademicDepartment.DataAccess.SnilDBContext context)
        {
            using (var db = new SnilDBContext())
            {
                // Add page types.
                PageTypeDBInit.DBInit(db, out this._pageTypes);

                // Add languages.
                LanguageDBInit.DBInit(db, out this._languages);

                // Init History page preview data.
                PreviewDBInit.DBInit(db, "History", this._pageTypes[4], this._languages[1], this._img);
                PreviewDBInit.DBInit(db, "История", this._pageTypes[4], this._languages[0], this._img);
                PreviewDBInit.DBInit(db, "ИсторияDE", this._pageTypes[4], this._languages[2], this._img);

                // Init People page preview data.
                PreviewDBInit.DBInit(db, "People", this._pageTypes[3], this._languages[1], this._img);
                PreviewDBInit.DBInit(db, "Персонал", this._pageTypes[3], this._languages[0], this._img);
                PreviewDBInit.DBInit(db, "ПерсоналDE", this._pageTypes[3], this._languages[2], this._img);

                // Init Home page preview data.
                PreviewDBInit.DBInit(db, "Home", this._pageTypes[2], this._languages[1], this._img);
                PreviewDBInit.DBInit(db, "Дом", this._pageTypes[2], this._languages[0], this._img);
                PreviewDBInit.DBInit(db, "ДомDE", this._pageTypes[2], this._languages[2], this._img);

                // Init Projects page preview data.
                PreviewDBInit.DBInit(db, "Projects", this._pageTypes[1], this._languages[1], this._img);
                PreviewDBInit.DBInit(db, "Проекты", this._pageTypes[1], this._languages[0], this._img);
                PreviewDBInit.DBInit(db, "ПроектыDE", this._pageTypes[1], this._languages[2], this._img);

                // Init Education page preview data.
                PreviewDBInit.DBInit(db, "Education", this._pageTypes[0], this._languages[1], this._img);
                PreviewDBInit.DBInit(db, "Обучение", this._pageTypes[0], this._languages[0], this._img);
                PreviewDBInit.DBInit(db, "ОбучениеDE", this._pageTypes[0], this._languages[2], this._img);
            }
        }
    }
}
