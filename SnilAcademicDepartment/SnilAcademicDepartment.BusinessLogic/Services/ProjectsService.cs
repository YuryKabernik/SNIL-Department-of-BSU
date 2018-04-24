using NLog;
using SnilAcademicDepartment.BusinessLogic.Enums;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.BusinessLogic.Models;
using SnilAcademicDepartment.DataAccess.Interface;
using System;
using System.Collections.Generic;

namespace SnilAcademicDepartment.BusinessLogic.Services
{
    public class ProjectsService : IProjects
    {
        private readonly ILogger _logger;
        private readonly IRepository _repository;

        public ProjectsService(ILogger logger, IRepository repository)
        {
            this._logger = logger;
            this._repository = repository;
        }

        public PreView GetPreView()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetProjects(ProjectType projectType)
        {
            throw new NotImplementedException();
        }
    }
}
