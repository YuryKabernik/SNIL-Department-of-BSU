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
            this._cookieManager = new CookieManager(this._loggerMock.Object, this._repositoryMock.Object);
            this._httpCookie = new HttpCookie("Test-cookie");
        }

        [Test()]
        public void CookieManager_ChangeCultureTest_NullReferenceArgumentThrowsNullReferenceException()
        {
            Assert.Throws(
                typeof(ArgumentNullException),
                () => this._cookieManager.SetCookieCulture(null, this._httpCookie));
        }

        [Test()]
        public void CookieManager_ChangeCultureTest_BadArgumentThrows()
        {
            Assert.Throws(
                typeof(CultureNotFoundException),
                () => this._cookieManager.SetCookieCulture("asls", this._httpCookie));
        }

        [Test()]
        public void CookieManager_ChangeCultureTest_DeParameterSetsThreatCultureDe()
        {
            var cookieResult = this._cookieManager.SetCookieCulture("de", this._httpCookie);
            Assert.IsNotNull(cookieResult);
            Assert.AreEqual("de", cookieResult.Value);
        }

        [Test()]
        public void CookieManager_ChangeCultureTest_EnParameterSetsThreatCultureEn()
        {
            var cookieResult = this._cookieManager.SetCookieCulture("en", this._httpCookie);
            Assert.IsNotNull(cookieResult);
            Assert.AreEqual("en", cookieResult.Value);
        }

        [Test()]
        public void CookieManager_ChangeCultureTest_RuParameterSetsThreatCultureRu()
        {
            var cookieResult = this._cookieManager.SetCookieCulture("ru", null);
            Assert.IsNotNull(cookieResult);
            Assert.AreEqual("ru", cookieResult.Value);
        }
    }
}