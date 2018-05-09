using NUnit.Framework;
using Moq;
using SnilAcademicDepartment.Common.LoggerAdapter;
using SnilAcademicDepartment.DataAccess;
using AutoMapper;
using System;

namespace SnilAcademicDepartment.BusinessLogic.Services.Tests
{
    [TestFixture()]
    public class EducationServiceTests
    {
        private Mock<SnilDBContext> _repositoryMock;
        private Mock<IMapper> _mapperMock;
        private Mock<NLogAdapter<CookieManagerTests>> _loggerMock;
        private EducationService _educationService;

        [SetUp]
        public void SetUpMethod()
        {
            this._repositoryMock = new Mock<SnilDBContext>();
            this._mapperMock = new Mock<IMapper>();
            this._loggerMock = new Mock<NLogAdapter<CookieManagerTests>>();
            this._educationService = new EducationService(this._loggerMock.Object, this._repositoryMock.Object, this._mapperMock.Object);
        }

        [Test()]
        public void EducationService_GetKeyAreasTest_GetMinusSevenPagesThrowsIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(
                ()=> this._educationService.GetKeyAreas(-7, It.IsAny<int>())
                );
        }

        [Test()]
        public void EducationService_GetKeyAreasTest_GetMinusFiveLCIDCodeThrowsIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(
                () => this._educationService.GetKeyAreas(5, -5)
                );
        }

    }
}