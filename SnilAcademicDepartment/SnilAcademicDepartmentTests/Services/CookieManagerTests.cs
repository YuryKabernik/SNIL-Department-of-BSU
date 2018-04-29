using Moq;
using NUnit.Framework;
using SnilAcademicDepartment.Common.LoggerAdapter;
using SnilAcademicDepartment.DataAccess.Interface;
using System;
using System.Globalization;

namespace SnilAcademicDepartment.BusinessLogic.Services.Tests
{
    [TestFixture()]
    public class CookieManagerTests
    {
        private Mock<IRepository> _repositoryMock;
        private Mock<NLogAdapter<CookieManagerTests>> _loggerMock;
        private CookieManager _cookieManager;

        [SetUp]
        public void SetUpMethod()
        {
            this._repositoryMock = new Mock<IRepository>();
            this._loggerMock = new Mock<NLogAdapter<CookieManagerTests>>();
            this._cookieManager = new CookieManager(this._loggerMock.Object, this._repositoryMock.Object);
        }

        [Test()]
        public void CookieManager_ChangeCultureTest_NullReferenceArgumentThrowsNullReferenceException()
        {
            Assert.Throws(
                typeof(NullReferenceException),
                () => this._cookieManager.ChangeCulture(null));
        }

        [Test()]
        public void CookieManager_ChangeCultureTest_BadArgumentThrows()
        {
            Assert.Throws(
                typeof(CultureNotFoundException),
                () => this._cookieManager.ChangeCulture("asls"));
        }

        [Test()]
        public void CookieManager_ChangeCultureTest_DeParameterSetsThreatCultureDe()
        {
            var cookieResult = this._cookieManager.ChangeCulture("de");
            Assert.IsNotNull(cookieResult);
            Assert.Contains("de", cookieResult.Values);
        }

        [Test()]
        public void CookieManager_ChangeCultureTest_EnParameterSetsThreatCultureEn()
        {
            var cookieResult = this._cookieManager.ChangeCulture("en");
            Assert.IsNotNull(cookieResult);
            Assert.Contains("en", cookieResult.Values);
        }

        [Test()]
        public void CookieManager_ChangeCultureTest_RuParameterSetsThreatCultureRu()
        {
            var cookieResult = this._cookieManager.ChangeCulture("ru");
            Assert.IsNotNull(cookieResult);
            Assert.Contains("ru", cookieResult.Values);
        }
    }
}