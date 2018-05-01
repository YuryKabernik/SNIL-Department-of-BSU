using NLog;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.BusinessLogic.Models;
using SnilAcademicDepartment.DataAccess.Interface;
using System;
using System.Collections.Generic;

namespace SnilAcademicDepartment.BusinessLogic.Services
{
    public sealed class PreViewService : IService
    {
        private readonly ILogger _logger;
        private readonly IRepository _repository;

        public PreViewService(ILogger logger, IRepository repository)
        {
            this._logger = logger;
            this._repository = repository;
        }

        public PreView GetPagePreview(string pageType)
        {
            throw new NotImplementedException();
        }
    }
}
