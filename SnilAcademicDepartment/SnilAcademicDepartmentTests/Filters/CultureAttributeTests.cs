using NUnit.Framework;
using Moq;
using System.Web.Mvc;
using System.Threading;
using System.Web;
using System.Globalization;

namespace SnilAcademicDepartment.Filters.Tests
{
    [TestFixture()]
    public class CultureAttributeTests
    {
        private CultureAttribute _cultureAttribute;
        private Mock<ActionExecutedContext> _filterContext;
        private Mock<HttpContextBase> _httpContext;
        private Mock<HttpRequestBase> _httpRequest;

        [SetUp]
        public void SetUpMethod()
        {
            this._cultureAttribute = new CultureAttribute(); ;
            this._filterContext = new Mock<ActionExecutedContext>();
            this._httpContext = new Mock<HttpContextBase>();
            this._httpRequest = new Mock<HttpRequestBase>();
        }

        [Test()]
        public void CultureAttribute_OnActionExecutedTest_SetGoodCultureFromCookie()
        {
            var language = "ru";
            var cookieName = "language";
            var cookie = new HttpCookie(cookieName, language);

            var collection = new HttpCookieCollection();
            collection.Add(cookie);

            this._filterContext.Setup(cfg => cfg.HttpContext)
                .Returns(_httpContext.Object);

            this._filterContext.Setup(cfg => cfg.HttpContext.Request)
                .Returns(_httpRequest.Object);

            this._filterContext.Setup(cfg => cfg.HttpContext.Request.Cookies)
                .Returns(collection);

            this._cultureAttribute.OnActionExecuted(this._filterContext.Object);

            Assert.AreEqual(CultureInfo.GetCultureInfo(language).TwoLetterISOLanguageName,
                Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName);

            Assert.AreEqual(CultureInfo.GetCultureInfo(language).TwoLetterISOLanguageName,
                Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName);
        }

        [Test()]
        public void CultureAttribute_OnActionExecutedTest_SetBadCultureFromCookie()
        {
            var language = "klk";
            var cookieName = "language";
            var cookie = new HttpCookie(cookieName, language);

            var collection = new HttpCookieCollection();
            collection.Add(cookie);

            this._filterContext.Setup(cfg => cfg.HttpContext)
                .Returns(_httpContext.Object);

            this._filterContext.Setup(cfg => cfg.HttpContext.Request)
                .Returns(_httpRequest.Object);

            this._filterContext.Setup(cfg => cfg.HttpContext.Request.Cookies)
                .Returns(collection);

            this._cultureAttribute.OnActionExecuted(this._filterContext.Object);

            Assert.AreEqual(CultureInfo.GetCultureInfo(language).TwoLetterISOLanguageName,
                Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName);

            Assert.AreEqual(CultureInfo.GetCultureInfo(language).TwoLetterISOLanguageName,
                Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName);
        }

        //[Test()]
        //public void CultureAttribute_OnActionExecutedTest_SetCultureFromHeader()
        //{
        //    this._cultureAttribute.OnActionExecuted(this._filterContext.Object);

        //    Assert.AreEqual(,Thread.CurrentThread.CurrentCulture.Name);
        //    Assert.AreEqual(,Thread.CurrentThread.CurrentUICulture.Name);
        //}

        //[Test()]
        //public void CultureAttribute_OnActionExecutedTest_SetCultureFromRoute()
        //{
        //    this._cultureAttribute.OnActionExecuted(this._filterContext.Object);

        //    Assert.AreEqual(, Thread.CurrentThread.CurrentCulture.Name);
        //    Assert.AreEqual(, Thread.CurrentThread.CurrentUICulture.Name);
        //}
    }
}