using System.Collections.Generic;
using NLog;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.BusinessLogic.Models;
using SnilAcademicDepartment.DataAccess.Interface;

namespace SnilAcademicDepartment.BusinessLogic.Services
{
    public class HomeService : IIndex
    {
        private readonly ILogger _logger;
        private readonly IRepository _repository;

        public HomeService(ILogger logger, IRepository repository)
        {
            this._logger = logger;
            this._repository = repository;
        }

        public IEnumerable<PreView> GetIndexPreRolls()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<PreView> GetIndexPreViews()
        {
            throw new System.NotImplementedException();
        }
    }
}
