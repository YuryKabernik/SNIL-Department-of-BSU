using NLog;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.DataAccess;
using System;
using System.Collections.Generic;

namespace SnilAcademicDepartment.BusinessLogic.Services
{
    public class HistoryService : IHistory
    {
        private readonly ILogger _logger;
        private readonly SnilDBContext _repository;

        public HistoryService(ILogger logger, SnilDBContext repository)
        {
            this._logger = logger;
            this._repository = repository;
        }

        public IEnumerable<DTOModels.PreViewModel> PreViews(string previewType)
        {
            throw new NotImplementedException();
        }
    }
}
