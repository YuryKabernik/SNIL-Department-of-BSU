namespace SnilAcademicDepartment.DataAccess.DBTypesInitialisation
{
    public static class PageTypeDBInit
    {
        private static PageType[] _pageTypes = new PageType[] {
            new PageType{ PageTypeName = "Education" },
            new PageType{ PageTypeName = "Projects" },
            new PageType{ PageTypeName = "Home" },
            new PageType{ PageTypeName = "People" },
            new PageType{ PageTypeName = "History" },
            new PageType{ PageTypeName = "Carousel" }
        };

        public static void DBInit(SnilDBContext db, out PageType[] pages)
        {
            db.PageTypes.AddRange(_pageTypes);
            db.SaveChanges();

            pages = (PageType[])_pageTypes.Clone();
        }
    }
}
