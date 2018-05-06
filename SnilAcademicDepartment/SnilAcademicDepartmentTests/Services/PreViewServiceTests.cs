using NLog;
using Moq;
using NUnit.Framework;
using SnilAcademicDepartment.DataAccess;
using System;
using System.Data.Entity;
using System.Linq;

namespace SnilAcademicDepartment.BusinessLogic.Services.Tests
{
    [TestFixture()]
    public class PreViewServiceTests
    {
        private Mock<ILogger> _mockLogger;
        private Mock<SnilDBContext> _mockRepository;
        private Mock<DbSet<PreView>> _mockDbSet;
        private PreViewService _service;

        [SetUp]
        public void MyTestMethod()
        {
            this._mockLogger = new Mock<ILogger>();
            this._mockRepository = new Mock<SnilDBContext>();
            this._mockDbSet = new Mock<DbSet<PreView>>();
            this._service = new PreViewService(this._mockLogger.Object, this._mockRepository.Object);
        }

        [Test()]
        public void PreViewService_GetPagePreviewTest_NullArgumentReturnsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                () => this._service.GetPagePreview(null));
        }

        [Test()]
        public void PreViewService_GetPagePreviewTest_EmptyArgumentReturnsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                () => this._service.GetPagePreview(String.Empty));
        }

        [Test()]
        public void PreViewService_GetPagePreviewTest_WhiteSpaceArgumentReturnsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                () => this._service.GetPagePreview(" "));
        }

        [Test()]
        public void PreViewService_GetPagePreviewTest_AnyTypeReturnsPreViewModel()
        {
            this._mockRepository.Setup(cfg => cfg.PreViews)
                .Returns(this._mockDbSet.Object);

            this._mockDbSet.Setup(cfg => cfg.FirstOrDefault())
                .Returns(It.IsAny<PreView>());

            var result = this._service.GetPagePreview(It.IsAny<string>());

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<PreView>(result);
        }

        [Test()]
        public void PreViewService_GetPagePreviewTest_BadTypeThrowsInvalidOperationException()
        {
            this._mockRepository.Setup(cfg => cfg.PreViews)
                .Returns(this._mockDbSet.Object);

            this._mockDbSet.Setup(cfg => cfg.FirstOrDefault())
                .Returns((PreView)null);

            Assert.Throws<InvalidOperationException>(
                () => this._service.GetPagePreview(It.IsAny<string>())
                );
        }
        
        [Test()]
        public void GetPagePreviewsTest()
        {
            Assert.Fail();
        }
    }
}