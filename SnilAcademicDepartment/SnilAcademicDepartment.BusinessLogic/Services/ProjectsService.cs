using AutoMapper;
using NLog;
using SnilAcademicDepartment.BusinessLogic.DTOModels;
using SnilAcademicDepartment.BusinessLogic.Enums;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SnilAcademicDepartment.BusinessLogic.Services
{
    public class ProjectsService : IProjects
    {
        private readonly ILogger _logger;
        private readonly SnilDBContext _repository;
        private readonly IMapper _mapper;

        public ProjectsService(ILogger logger, SnilDBContext repository, IMapper mapper)
        {
            this._logger = logger;
            this._repository = repository;
            this._mapper = mapper;
        }

        public DTOModels.ProjectModel GetProject(string projectStatus, int langLCID)
        {
            if (string.IsNullOrEmpty(projectStatus) || string.IsNullOrWhiteSpace(projectStatus))
            {
                throw new ArgumentNullException(nameof(projectStatus), "Your argument is Null, Empty or WhiteSpace");
            }

            var requestResult = this._repository.Projects
                .FirstOrDefault(e => projectStatus.Equals(e.ProjectStatus, StringComparison.OrdinalIgnoreCase)
                && e.Language.LanguageCode == langLCID);

            if (requestResult == null)
            {
                throw new InvalidOperationException("Cant't find project with such options.");
            }

            return this._mapper.Map<DTOModels.ProjectModel>(requestResult);
        }

        public IEnumerable<DTOModels.ProjectModel> GetProjects(string projectStatus, int langLCID)
        {
            if (string.IsNullOrEmpty(projectStatus) || string.IsNullOrWhiteSpace(projectStatus))
            {
                throw new ArgumentNullException(nameof(projectStatus), "Your argument is Null, Empty or WhiteSpace");
            }

            var requestResult = this._repository.Projects
                .Where(e => e.ProjectStatus == projectStatus && e.Language.LanguageCode == langLCID)
                .AsEnumerable();

            if (requestResult == null)
            {
                throw new InvalidOperationException("Cant't find projects with such options.");
            }

            return this._mapper.Map<IEnumerable<DTOModels.ProjectModel>>(requestResult);
        }

        public IEnumerable<DTOModels.ProjectModel> GetProjects(string projectStatus, int startIndex, int endIndex, int langLCID)
        {
            if (string.IsNullOrEmpty(projectStatus) || string.IsNullOrWhiteSpace(projectStatus))
            {
                throw new ArgumentNullException(nameof(projectStatus), "Your argument is Null, Empty or WhiteSpace");
            }

            if (startIndex <= 0 || endIndex <= 0)
            {
                throw new IndexOutOfRangeException("Your start or end index is smaller or equal to zero.");
            }

            var requestResult = this._repository.Projects
                .Where(e => e.ProjectStatus == projectStatus && e.Language.LanguageCode == langLCID)
                .Skip(startIndex).Take(endIndex)
                .AsEnumerable();

            if (requestResult == null)
            {
                throw new InvalidOperationException("Cant't find projects with such options.");
            }

            return this._mapper.Map<IEnumerable<DTOModels.ProjectModel>>(requestResult);
        }
    }
}
