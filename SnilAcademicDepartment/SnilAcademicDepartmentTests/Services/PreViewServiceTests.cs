using NLog;
using Moq;
using NUnit.Framework;
using SnilAcademicDepartment.DataAccess;
using System;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using System.Collections.Generic;
using SnilAcademicDepartment.DataAccess.Models;

namespace SnilAcademicDepartment.BusinessLogic.Services.Tests
{
    [TestFixture()]
    public class PreViewServiceTests
    {
        private Mock<ILogger> _mockLogger;
        private Mock<IMapper> _mockMapper;
        private Mock<SnilDBContext> _mockRepository;
        private Mock<DbSet<PreView>> _mockDbSet;
        private PreViewService _service;

        IQueryable<PreView> data = new List<PreView>
            {
                new PreView { PageTypeName = new PageType{PageTypeName = "BBB" } },
                new PreView { PageTypeName = new PageType{PageTypeName =  "ZZZ" } },
                new PreView { PageTypeName = new PageType{PageTypeName =  "ZZZ" } },
                new PreView { PageTypeName = new PageType{PageTypeName =  "AAA" } },
            }.AsQueryable();


        [SetUp]
        public void MyTestMethod()
        {
            // Setup mock objects.
            this._mockLogger = new Mock<ILogger>();
            this._mockMapper = new Mock<IMapper>();
            this._mockRepository = new Mock<SnilDBContext>();
            this._mockDbSet = new Mock<DbSet<PreView>>();
            this._service = new PreViewService(this._mockLogger.Object, this._mockRepository.Object, this._mockMapper.Object);

            // Setup mock queries.
            this._mockDbSet.Object.AddRange(data);
            this._mockDbSet.As<IQueryable<PreView>>().Setup(m => m.Provider).Returns(data.Provider);
            this._mockDbSet.As<IQueryable<PreView>>().Setup(m => m.Expression).Returns(data.Expression);
            this._mockDbSet.As<IQueryable<PreView>>().Setup(m => m.ElementType).Returns(data.ElementType);
            this._mockDbSet.As<IQueryable<PreView>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

        }

        [Test()]
        public void PreViewService_GetPagePreviewTest_NullArgumentReturnsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                () => this._service.GetPagePreview(null, It.IsAny<int>()));
        }

        [Test()]
        public void PreViewService_GetPagePreviewTest_EmptyArgumentReturnsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                () => this._service.GetPagePreview(String.Empty, It.IsAny<int>()));
        }

        [Test()]
        public void PreViewService_GetPagePreviewTest_WhiteSpaceArgumentReturnsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                () => this._service.GetPagePreview(" ", It.IsAny<int>()));
        }

        [Test()]
        public void PreViewService_GetPagePreviewTest_AnyTypeReturnsPreViewModel()
        {
            this._mockRepository.Setup(cfg => cfg.PreViews)
                .Returns(this._mockDbSet.Object);

            var result = this._service.GetPagePreview("BBB", It.IsAny<int>());

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<DTOModels.PreViewModel>(result);
        }

        [Test()]
        public void PreViewService_GetPagePreviewTest_BadTypeThrowsInvalidOperationException()
        {
            this._mockRepository.Setup(cfg => cfg.PreViews)
                .Returns(this._mockDbSet.Object);

            this._mockDbSet.Object.Add(It.IsAny<PreView>());

            Assert.Throws<InvalidOperationException>(
                () => this._service.GetPagePreview(It.IsAny<string>(), It.IsAny<int>())
                );
        }
        
        [Test()]
        public void GetPagePreviewsTest()
        {
            Assert.Fail();
        }
    }
}