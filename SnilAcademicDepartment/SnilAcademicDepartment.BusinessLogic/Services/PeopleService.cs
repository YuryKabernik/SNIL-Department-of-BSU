using NLog;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.BusinessLogic.DTOModels;
using SnilAcademicDepartment.DataAccess;
using System;
using System.Collections.Generic;

namespace SnilAcademicDepartment.BusinessLogic.Services
{
    public class PeopleService : IPeople
    {
        private readonly ILogger _logger;
        private readonly SnilDBContext _repository;

        public PeopleService(ILogger logger, SnilDBContext repository)
        {
            this._logger = logger;
            this._repository = repository;
        }

        public IEnumerable<Leader> GetHallOfFameLeaders()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DTOModels.PreViewModel> GetPreViews()
        {
            throw new NotImplementedException();
        }
    }
}
