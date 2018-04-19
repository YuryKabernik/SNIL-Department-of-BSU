using NLog;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.BusinessLogic.Models;
using SnilAcademicDepartment.DataAccess.Interface;

namespace SnilAcademicDepartment.BusinessLogic.Services
{
    class HomePage : IIndex
    {
        private readonly ILogger _logger;
        private readonly IRepository _repository;

        public HomePage(ILogger logger, IRepository repository)
        {
            this._logger = logger;
            this._repository = repository;
        }

        public PreView GetIndexPreRolls()
        {
            throw new System.NotImplementedException();
        }

        public PreView GetIndexPreViews()
        {
            throw new System.NotImplementedException();
        }
    }
}
