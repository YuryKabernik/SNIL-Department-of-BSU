using System.Globalization;
using SnilAcademicDepartment.DataAccess.Models;

namespace SnilAcademicDepartment.DataAccess.DBTypesInitialisation
{
    public static class LanguageDBInit
    {
        private static Language[] _languages = new Language[] {
             new Language{
                LanguageName = CultureInfo.GetCultureInfo("ru-RU").Name,
                LanguageCode = CultureInfo.GetCultureInfo("ru-RU").LCID
            },
            new Language{
                LanguageName = CultureInfo.GetCultureInfo("en-US").Name,
                LanguageCode = CultureInfo.GetCultureInfo("en-US").LCID
            },
            new Language{
                LanguageName = CultureInfo.GetCultureInfo("de-DE").Name,
                LanguageCode = CultureInfo.GetCultureInfo("de-DE").LCID
            }
        };

        public static void DBInit(SnilDBContext db, out Language[] lang)
        {
            db.Languages.AddRange(_languages);
            db.SaveChanges();

            lang = (Language[])_languages.Clone();
        }
    }
}
