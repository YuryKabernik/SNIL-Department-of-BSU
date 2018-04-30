using SnilAcademicDepartment.BusinessLogic.Services;
using NUnit.Framework;
using SnilAcademicDepartment.Common.LoggerAdapter;
using Moq;
using SnilAcademicDepartment.DataAccess.Interface;

namespace SnilAcademicDepartment.BusinessLogic.Services.Tests
{
    [TestFixture()]
    public class HistoryServiceTests
    {
        private Mock<IRepository> _repositoryMock;
        private Mock<NLogAdapter<CookieManagerTests>> _loggerMock;
        private HistoryService _historyService;

        [SetUp]
        public void SetUpMethod()
        {
            this._repositoryMock = new Mock<IRepository>();
            this._loggerMock = new Mock<NLogAdapter<CookieManagerTests>>();
            this._historyService = new HistoryService(this._loggerMock.Object, this._repositoryMock.Object);
        }

        [Test()]
        public void HistoryPreView_GetPreViewsTest_NullArgumentThrowsNullArgumentException()
        {
            Assert.Fail();
        }

        [Test()]
        public void HistoryPreView_GetPreViewsTest_BadPreviewTypeThrowspreviewTypeNotFoundException()
        {
            Assert.Fail();
        }
        [Test()]
        public void HistoryPreView_GetPreViewsTest_GoodPreviewTypeReturnsCollectionOfPreviews()
        {
            Assert.Fail();
        }
    }
}