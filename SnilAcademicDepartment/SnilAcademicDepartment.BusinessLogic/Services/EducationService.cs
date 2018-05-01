using NLog;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.BusinessLogic.Models;
using SnilAcademicDepartment.DataAccess.Interface;
using System;
using System.Collections.Generic;

namespace SnilAcademicDepartment.BusinessLogic.Services
{
    public class EducationService : IEducation
    {
        private readonly ILogger _logger;
        private readonly IRepository _repository;

        public EducationService(ILogger logger, IRepository repository)
        {
            this._logger = logger;
            this._repository = repository;
        }

        public IEnumerable<KeyAreaBlock> GetKeyAreas(uint pages)
        {
            throw new NotImplementedException();
        }
    }
}
