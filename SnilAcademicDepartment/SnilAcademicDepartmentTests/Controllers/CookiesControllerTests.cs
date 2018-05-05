using NUnit.Framework;
using Moq;
using NLog;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using System.Web;
using System;

namespace SnilAcademicDepartment.Controllers.Tests
{
    [TestFixture()]
    public class CookiesControllerTests
    {
        private CookiesController _cookieController;
        private Mock<ILogger> _mockLogger;
        private Mock<ICookieManager> _mockManager;
        private Mock<HttpRequestBase> _httpRequest;
        private Mock<Uri> _httpContext;

        [SetUp()]
        public void MyTestMethod()
        {
            this._mockLogger = new Mock<ILogger>();
            this._mockManager = new Mock<ICookieManager>();
            this._cookieController = new CookiesController(this._mockLogger.Object, this._mockManager.Object);
        }

        [Test()]
        public void ChangeCultureTest()
        {
            var result = this._cookieController.ChangeCulture("en");

            Assert.Fail();
        }
    }
}