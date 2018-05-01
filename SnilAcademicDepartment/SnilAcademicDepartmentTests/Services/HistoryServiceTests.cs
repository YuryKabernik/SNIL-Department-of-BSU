﻿using NUnit.Framework;
using SnilAcademicDepartment.Common.LoggerAdapter;
using Moq;
using SnilAcademicDepartment.DataAccess.Interface;
using System;
using SnilAcademicDepartment.Common.CustomExceptions;
using System.Collections.Generic;
using SnilAcademicDepartment.BusinessLogic.Models;

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
        public void HistoryPreView_GetPreViewsTest_NullArgumentThrowsArgumentNullException()
        {
            Assert.Throws(
                typeof(ArgumentNullException),
                () => this._historyService.PreViews(null));
        }

        [Test()]
        public void HistoryPreView_GetPreViewsTest_BadPreviewTypeThrowsPreviewTypeNotFoundException()
        {
            Assert.Throws(
                typeof(PreviewTypeNotFoundException),
                () => this._historyService.PreViews(null));
        }

        [Test()]
        public void HistoryPreView_GetPreViewsTest_GoodPreviewTypeReturnsCollectionOfHistoryPreviews()
        {
            var resultCollection = (List<PreView>)this._historyService.PreViews("History");
            Assert.NotNull(resultCollection);
            Assert.NotZero(resultCollection.Count);
        }
    }
}