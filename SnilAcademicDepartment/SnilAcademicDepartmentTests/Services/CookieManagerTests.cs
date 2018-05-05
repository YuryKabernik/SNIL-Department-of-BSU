using Moq;
using NUnit.Framework;
using SnilAcademicDepartment.Common.LoggerAdapter;
using SnilAcademicDepartment.DataAccess.Interface;
using System;
using System.Globalization;
using System.Web;

namespace SnilAcademicDepartment.BusinessLogic.Services.Tests
{
    [TestFixture()]
    [TestOf(typeof(CookieManager))]
    public class CookieManagerTests
    {
        private Mock<IRepository> _repositoryMock;
        private Mock<NLogAdapter<CookieManagerTests>> _loggerMock;
        private CookieManager _cookieManager;
        private HttpCookie _httpCookie;

        [SetUp]
        public void SetUpMethod()
        {
            this._repositoryMock = new Mock<IRepository>();
            this._loggerMock = new Mock<NLogAdapter<CookieManagerTests>>();
            this._cookieManager = new CookieManager(this._loggerMock.Object);
            this._httpCookie = new HttpCookie("Test-cookie");
        }

        [Test()]
        public void CookieManager_ChangeCultureTest_NullReferenceArgumentThrowsArgumentException()
        {
            Assert.Throws(
                typeof(ArgumentException),
                () => this._cookieManager.SetCookieCulture(null, this._httpCookie));
        }

        [Test()]
        public void CookieManager_ChangeCultureTest_EmptyStringArgumentThrowsArgumentException()
        {
            Assert.Throws(
                typeof(ArgumentException),
                () => this._cookieManager.SetCookieCulture(string.Empty, this._httpCookie));
        }

        [Test()]
        public void CookieManager_ChangeCultureTest_BadArgumentThrowsCultureNotFoundException()
        {
            Assert.Throws(
                typeof(CultureNotFoundException),
                () => this._cookieManager.SetCookieCulture("цц", this._httpCookie));
        }

        [Test()]
        public void CookieManager_ChangeCultureTest_DeParameterSetsThreatCultureDe()
        {
            var setCulture = "de-DE";

            var cookieResult = this._cookieManager.SetCookieCulture(setCulture, this._httpCookie);

            Assert.IsNotNull(cookieResult);
            Assert.AreEqual(setCulture, cookieResult.Value);
        }

        [Test()]
        public void CookieManager_ChangeCultureTest_EnParameterSetsThreatCultureEn()
        {
            var setCulture = "en-US";

            var cookieResult = this._cookieManager.SetCookieCulture(setCulture, this._httpCookie);

            Assert.IsNotNull(cookieResult);
            Assert.AreEqual(setCulture, cookieResult.Value);
        }

        [Test()]
        public void CookieManager_ChangeCultureTest_RuParameterSetsThreatCultureRu()
        {
            var setCulture = "ru-RU";

            var cookieResult = this._cookieManager.SetCookieCulture(setCulture, null);

            Assert.IsNotNull(cookieResult);
            Assert.AreEqual(setCulture, cookieResult.Value);
        }
    }
}