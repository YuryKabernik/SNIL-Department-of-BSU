using NLog;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.DataAccess;
using System;
using System.Collections.Generic;

namespace SnilAcademicDepartment.BusinessLogic.Services
{
    public sealed class PreViewService : IService
    {
        private readonly ILogger _logger;
        private readonly SnilDBContext _repository;

        public PreViewService(ILogger logger, SnilDBContext repository)
        {
            this._logger = logger;
            this._repository = repository;
        }

        public Models.PreView GetPagePreview(string pageType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.PreView> GetPagePreviews(string pageType)
        {
            throw new NotImplementedException();
        }
    }
}
