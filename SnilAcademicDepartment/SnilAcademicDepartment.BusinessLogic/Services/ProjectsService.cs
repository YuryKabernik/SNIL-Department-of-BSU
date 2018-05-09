using NLog;
using SnilAcademicDepartment.BusinessLogic.Enums;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.DataAccess;
using System;
using System.Collections.Generic;

namespace SnilAcademicDepartment.BusinessLogic.Services
{
    public class ProjectsService : IProjects
    {
        private readonly ILogger _logger;
        private readonly SnilDBContext _repository;

        public ProjectsService(ILogger logger, SnilDBContext repository)
        {
            this._logger = logger;
            this._repository = repository;
        }

        public DTOModels.PreView GetPreView()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DTOModels.Project> GetProjects(ProjectType projectType)
        {
            throw new NotImplementedException();
        }
    }
}
