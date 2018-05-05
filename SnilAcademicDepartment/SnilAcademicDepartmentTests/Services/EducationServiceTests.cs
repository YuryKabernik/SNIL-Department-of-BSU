using NUnit.Framework;
using Moq;
using SnilAcademicDepartment.Common.LoggerAdapter;
using SnilAcademicDepartment.DataAccess;

namespace SnilAcademicDepartment.BusinessLogic.Services.Tests
{
    [TestFixture()]
    public class EducationServiceTests
    {
        private Mock<SnilDBContext> _repositoryMock;
        private Mock<NLogAdapter<CookieManagerTests>> _loggerMock;
        private EducationService _educationService;

        [SetUp]
        public void SetUpMethod()
        {
            this._repositoryMock = new Mock<SnilDBContext>();
            this._loggerMock = new Mock<NLogAdapter<CookieManagerTests>>();
            this._educationService = new EducationService(this._loggerMock.Object, this._repositoryMock.Object);
        }

        [Test()]
        public void EducationService_GetKeyAreasTest_GetSevenPagesIsNotNullCollectionResult()
        {
            var result = this._educationService.GetKeyAreas(7);
            Assert.NotNull(result);
        }

        [Test()]
        public void EducationService_GetKeyAreasTest_GetFivePagesIsNotNullCollectionResult()
        {
            var result = this._educationService.GetKeyAreas(5);
            Assert.NotNull(result);
        }
    }
}