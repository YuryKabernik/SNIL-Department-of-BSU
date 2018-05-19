using AutoMapper;
using NLog;
using SnilAcademicDepartment.BusinessLogic.DTOModels;
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

        /// <summary>
        /// Get first project by type anf language code mapped to type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="projectType"></param>
        /// <param name="langLCID"></param>
        /// <returns></returns>
        public T GetProject<T>(string projectStatus, int langLCID)
        {
            var res = this.GetProject(projectStatus, langLCID);

            return this._mapper.Map<T>(res);
        }
        /// <summary>
        /// Get all projects mapped to type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="projectType">Status of the project.</param>
        /// <param name="langLCID"></param>
        /// <returns></returns>
        public IEnumerable<T> GetProjects<T>(string projectStatus, int langLCID)
        {
            var res = this.GetProjects(projectStatus, langLCID);

            return this._mapper.Map<IEnumerable<T>>(res);
        }

        /// <summary>
        /// Get number of projects from start to end index mapped to type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="projectType"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="langLCID"></param>
        /// <returns></returns>
        public IEnumerable<T> GetProjects<T>(string projectStatus, int startIndex, int endIndex, int langLCID)
        {
            var res = this.GetProjects(projectStatus, startIndex, endIndex, langLCID);

            return this._mapper.Map<IEnumerable<T>>(res);
        }

        public ProjectModel GetProject(string projectStatus, int langLCID)
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

        public IEnumerable<ProjectModel> GetProjects(string projectStatus, int langLCID)
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

        public IEnumerable<ProjectModel> GetProjects(string projectStatus, int startIndex, int endIndex, int langLCID)
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
