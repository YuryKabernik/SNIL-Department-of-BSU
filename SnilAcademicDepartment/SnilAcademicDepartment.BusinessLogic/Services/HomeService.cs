using System.Collections.Generic;
using NLog;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.DataAccess;

namespace SnilAcademicDepartment.BusinessLogic.Services
{
    public class HomeService : IIndex
    {
        private readonly ILogger _logger;
        private readonly SnilDBContext _repository;

        public HomeService(ILogger logger, SnilDBContext repository)
        {
            this._logger = logger;
            this._repository = repository;
        }

        public IEnumerable<DTOModels.PreView> GetIndexPreRolls()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<DTOModels.PreView> GetIndexPreViews()
        {
            throw new System.NotImplementedException();
        }
    }
}
