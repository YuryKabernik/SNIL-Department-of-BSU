using NUnit.Framework;
using Moq;
using System.Web.Mvc;
using System.Threading;
using System.Web;
using System.Globalization;
using System.Web.Routing;

namespace SnilAcademicDepartment.Filters.Tests
{
    [TestFixture()]
    public class CultureAttributeTests
    {
        private CultureAttribute _cultureAttribute;
        private Mock<ActionExecutedContext> _filterContext;
        private Mock<HttpContextBase> _httpContext;
        private Mock<HttpRequestBase> _httpRequest;
        private Mock<RouteData> _routeData;

        [SetUp]
        public void SetUpMethod()
        {
            this._cultureAttribute = new CultureAttribute(); ;
            this._filterContext = new Mock<ActionExecutedContext>();
            this._httpContext = new Mock<HttpContextBase>();
            this._httpRequest = new Mock<HttpRequestBase>();
            this._routeData = new Mock<RouteData>();
            
        }

        [Test()]
        public void CultureAttribute_OnActionExecutedTest_SetGoodRuCultureFromCookie()
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
        public void CultureAttribute_OnActionExecutedTest_BadCultureFromCookieSetENCultureByDefault()
        {
            var language = "eruip";
            var cookieName = "language";
            var cookie = new HttpCookie(cookieName, language);

            var collection = new HttpCookieCollection();
            collection.Add(cookie);

            this._filterContext.Setup(cfg => cfg.HttpContext)
                .Returns(this._httpContext.Object);

            this._filterContext.Setup(cfg => cfg.HttpContext.Request)
                .Returns(this._httpRequest.Object);

            this._filterContext.Setup(cfg => cfg.HttpContext.Request.Cookies)
                .Returns(collection);

            this._cultureAttribute.OnActionExecuted(this._filterContext.Object);

            Assert.AreEqual(CultureInfo.GetCultureInfo("en").TwoLetterISOLanguageName,
                Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName);

            Assert.AreEqual(CultureInfo.GetCultureInfo("en").TwoLetterISOLanguageName,
                Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName);
        }

        [Test()]
        public void CultureAttribute_OnActionExecutedTest_BadCultureFromRouteSetENCultureByDefault()
        {
            // Setup cookie
            var cookieLang = "eruip";
            var cookieName = "language2";
            var cookie = new HttpCookie(cookieName, cookieLang);

            var collection = new HttpCookieCollection();
            collection.Add(cookie);

            this._filterContext.Setup(cfg => cfg.HttpContext)
                .Returns(this._httpContext.Object);

            this._filterContext.Setup(cfg => cfg.HttpContext.Request)
                .Returns(this._httpRequest.Object);

            this._filterContext.Setup(cfg => cfg.HttpContext.Request.Cookies)
                .Returns(collection);

            // Setup route
            var language = "qwerav";
            var routeParameter = "language";

            this._filterContext.Setup(cfg => cfg.RouteData)
                .Returns(this._routeData.Object);

            this._routeData.Object.Values.Add(routeParameter, language);

            this._cultureAttribute.OnActionExecuted(this._filterContext.Object);

            Assert.AreEqual(CultureInfo.GetCultureInfo("en").TwoLetterISOLanguageName,
                Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName);

            Assert.AreEqual(CultureInfo.GetCultureInfo("en").TwoLetterISOLanguageName,
                Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName);
        }

        [Test()]
        public void CultureAttribute_OnActionExecutedTest_SetGoodCultureFromRoute()
        {
            // Setup cookie
            var cookieLang = "eruip";
            var cookieName = "language2";
            var cookie = new HttpCookie(cookieName, cookieLang);

            var collection = new HttpCookieCollection();
            collection.Add(cookie);

            this._filterContext.Setup(cfg => cfg.HttpContext)
                .Returns(this._httpContext.Object);

            this._filterContext.Setup(cfg => cfg.HttpContext.Request)
                .Returns(this._httpRequest.Object);

            this._filterContext.Setup(cfg => cfg.HttpContext.Request.Cookies)
                .Returns(collection);

            // Setup route
            var language = "de";
            var routeParameter = "language";

            this._filterContext.Setup(cfg => cfg.RouteData)
                .Returns(this._routeData.Object);

            this._routeData.Object.Values.Add(routeParameter, language);

            this._cultureAttribute.OnActionExecuted(this._filterContext.Object);

            Assert.AreEqual(CultureInfo.GetCultureInfo(language).TwoLetterISOLanguageName,
                Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName);

            Assert.AreEqual(CultureInfo.GetCultureInfo(language).TwoLetterISOLanguageName,
                Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName);
        }

        [Test()]
        public void CultureAttribute_OnActionExecutedTest_SetGoodCultureFromHeader()
        {
            // Setup cookie
            var cookieLang = "eruip";
            var cookieName = "language2";
            var cookie = new HttpCookie(cookieName, cookieLang);

            var collection = new HttpCookieCollection();
            collection.Add(cookie);

            this._filterContext.Setup(cfg => cfg.HttpContext)
                .Returns(this._httpContext.Object);

            this._filterContext.Setup(cfg => cfg.HttpContext.Request)
                .Returns(this._httpRequest.Object);

            this._filterContext.Setup(cfg => cfg.HttpContext.Request.Cookies)
                .Returns(collection);

            // Setup route
            this._filterContext.Setup(cfg => cfg.RouteData)
                .Returns(this._routeData.Object);

            // Setup header
            this._filterContext.Setup(cfg => cfg.HttpContext.Request.UserLanguages)
                .Returns(new string[] { "de", "ru" });

            this._cultureAttribute.OnActionExecuted(this._filterContext.Object);

            Assert.AreEqual(CultureInfo.GetCultureInfo("de").TwoLetterISOLanguageName,
                Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName);

            Assert.AreEqual(CultureInfo.GetCultureInfo("de").TwoLetterISOLanguageName,
                Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName);
        }

        [Test()]
        public void CultureAttribute_OnActionExecutedTest_BadCultureFromHeaderSetENCultureByDefault()
        {
            // Setup cookie
            var cookieLang = "eruip";
            var cookieName = "language2";
            var cookie = new HttpCookie(cookieName, cookieLang);

            var collection = new HttpCookieCollection();
            collection.Add(cookie);

            this._filterContext.Setup(cfg => cfg.HttpContext)
                .Returns(this._httpContext.Object);

            this._filterContext.Setup(cfg => cfg.HttpContext.Request)
                .Returns(this._httpRequest.Object);

            this._filterContext.Setup(cfg => cfg.HttpContext.Request.Cookies)
                .Returns(collection);

            // Setup route
            this._filterContext.Setup(cfg => cfg.RouteData)
                .Returns(this._routeData.Object);

            // Setup header
            this._filterContext.Setup(cfg => cfg.HttpContext.Request.UserLanguages)
                .Returns(new string[] { "ertgd", "ru" });

            this._cultureAttribute.OnActionExecuted(this._filterContext.Object);

            Assert.AreEqual(CultureInfo.GetCultureInfo("en").TwoLetterISOLanguageName,
                Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName);

            Assert.AreEqual(CultureInfo.GetCultureInfo("en").TwoLetterISOLanguageName,
                Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName);
        }
    }
}