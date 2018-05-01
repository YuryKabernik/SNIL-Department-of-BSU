using NLog;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.BusinessLogic.Models;
using SnilAcademicDepartment.DataAccess.Interface;
using System;
using System.Collections.Generic;

namespace SnilAcademicDepartment.BusinessLogic.Services
{
    public class PeopleService : IPeople
    {
        private readonly ILogger _logger;
        private readonly IRepository _repository;

        public PeopleService(ILogger logger, IRepository repository)
        {
            this._logger = logger;
            this._repository = repository;
        }

        public IEnumerable<Leader> GetHallOfFameLeaders()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PreView> GetPreViews()
        {
            throw new NotImplementedException();
        }
    }
}
