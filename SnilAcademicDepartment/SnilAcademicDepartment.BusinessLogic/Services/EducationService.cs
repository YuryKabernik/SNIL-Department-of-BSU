using NLog;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.BusinessLogic.Models;
using SnilAcademicDepartment.DataAccess;
using System;
using System.Collections.Generic;

namespace SnilAcademicDepartment.BusinessLogic.Services
{
    public class EducationService : IEducation
    {
        private readonly ILogger _logger;
        private readonly SnilDBContext _repository;

        public EducationService(ILogger logger, SnilDBContext repository)
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
