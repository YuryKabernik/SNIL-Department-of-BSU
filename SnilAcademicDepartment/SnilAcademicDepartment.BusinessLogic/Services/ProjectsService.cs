using AutoMapper;
using NLog;
using SnilAcademicDepartment.BusinessLogic.DTOModels;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.DataAccess;
using SnilAcademicDepartment.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SnilAcademicDepartment.BusinessLogic.Services
{
	public class ProjectsService : IProjects, IProjectsPreview
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
		public T GetProjectPreview<T>(ProjectStatusDTO projectStatus, int langLCID)
		{
			var res = this.GetProjectByStatus(projectStatus, langLCID);

			return this._mapper.Map<T>(res);
		}

		/// <summary>
		/// Get all projects mapped to type <typeparamref name="T"/>.
		/// </summary>
		/// <param name="projectType">Status of the project.</param>
		/// <param name="langLCID"></param>
		/// <returns></returns>
		public IEnumerable<T> GetProjectsPreviews<T>(ProjectStatusDTO projectStatus, int langLCID)
		{
			var res = this.GetProjectsByStatus(projectStatus, langLCID);

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
		public IEnumerable<T> GetProjectsPreviews<T>(ProjectStatusDTO projectStatus, int startIndex, int endIndex, int langLCID)
		{
			var res = this.GetProjectsByStatus(projectStatus, startIndex, endIndex, langLCID);

			return this._mapper.Map<IEnumerable<T>>(res);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="projectStatus"></param>
		/// <param name="langLCID"></param>
		/// <returns></returns>
		public ProjectModel GetProjectByStatus(ProjectStatusDTO projectStatus, int langLCID)
		{
			if (!Enum.IsDefined(typeof(ProjectStatusDTO), projectStatus))
			{
				throw new ArgumentNullException(nameof(projectStatus), "Your argument is Null, Empty or WhiteSpace");
			}

			var requestResult = this._repository.Projects
				.FirstOrDefault(e => e.Status.Equals(projectStatus.ToString(), StringComparison.OrdinalIgnoreCase)
				&& e.Language.LanguageCode == langLCID);

			if (requestResult == null)
			{
				throw new InvalidOperationException("Cant't find project with such options.");
			}

			return this._mapper.Map<DTOModels.ProjectModel>(requestResult);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="projectStatus"></param>
		/// <param name="langLCID"></param>
		/// <returns></returns>
		public IEnumerable<ProjectModel> GetProjectsByStatus(ProjectStatusDTO projectStatus, int langLCID)
		{
			if (!Enum.IsDefined(typeof(ProjectStatusDTO), projectStatus))
			{
				throw new ArgumentNullException(nameof(projectStatus), "Your argument is Null, Empty or WhiteSpace");
			}

			var requestResult = this._repository.Projects
				.Where(e => e.Status.Equals(projectStatus.ToString(), StringComparison.OrdinalIgnoreCase) && e.Language.LanguageCode == langLCID)
				.AsEnumerable();

			if (requestResult == null)
			{
				throw new InvalidOperationException("Cant't find projects with such options.");
			}

			return this._mapper.Map<IEnumerable<DTOModels.ProjectModel>>(requestResult);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="projectStatus"></param>
		/// <param name="startIndex"></param>
		/// <param name="endIndex"></param>
		/// <param name="langLCID"></param>
		/// <returns></returns>
		public IEnumerable<ProjectModel> GetProjectsByStatus(ProjectStatusDTO projectStatus, int startIndex, int endIndex, int langLCID)
		{
			if (!Enum.IsDefined(typeof(ProjectStatusDTO), projectStatus))
			{
				throw new ArgumentNullException(nameof(projectStatus), "Your argument is Null, Empty or WhiteSpace");
			}

			if (startIndex < 0 || endIndex < 0)
			{
				throw new IndexOutOfRangeException("Your start or end index is smaller than zero.");
			}

			var requestResult = this._repository.Projects
				.Where(e => e.Status.Equals(projectStatus.ToString(), StringComparison.OrdinalIgnoreCase) && e.Language.LanguageCode == langLCID)
				.AsEnumerable().Skip(startIndex).Take(endIndex);

			if (requestResult == null)
			{
				throw new InvalidOperationException("Cant't find projects with such options.");
			}

			return this._mapper.Map<IEnumerable<DTOModels.ProjectModel>>(requestResult);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="projectId"></param>
		/// <param name="langLCID"></param>
		/// <returns></returns>
		public ProjectModel GetProjectById(int projectId, int langLCID)
		{
			try
			{
				var requestResult = this._repository.Projects
			   .First(o => o.CommonID == projectId
			   && o.Language.LanguageCode == langLCID);

				return this._mapper.Map<DTOModels.ProjectModel>(requestResult);
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException("Cant't find project with such id.", ex);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="projectStatus"></param>
		/// <param name="langLCID"></param>
		/// <returns></returns>
		public async Task<T> GetProjectPreviewAsync<T>(ProjectStatusDTO projectStatus, int langLCID)
		{
			var res = await this.GetProjectByStatusAsync(projectStatus, langLCID);

			return this._mapper.Map<T>(res);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="projectStatus"></param>
		/// <param name="langLCID"></param>
		/// <returns></returns>
		private async Task<ProjectModel> GetProjectByStatusAsync(ProjectStatusDTO projectStatus, int langLCID)
		{
			if (!Enum.IsDefined(typeof(ProjectStatusDTO), projectStatus))
			{
				throw new ArgumentNullException(nameof(projectStatus), "Your argument is Null, Empty or WhiteSpace");
			}

			var requestResult = await this._repository.Projects
				.FirstOrDefaultAsync(e => e.Status.Equals(projectStatus.ToString(), StringComparison.OrdinalIgnoreCase)
				&& e.Language.LanguageCode == langLCID);

			if (requestResult == null)
			{
				throw new InvalidOperationException("Cant't find project with such options.");
			}

			return this._mapper.Map<DTOModels.ProjectModel>(requestResult);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="projectStatus"></param>
		/// <param name="langLCID"></param>
		/// <returns></returns>
		public async Task<IEnumerable<T>> GetProjectsPreviewsAsync<T>(ProjectStatusDTO projectStatus, int langLCID)
		{
			var res = await this.GetProjectsByStatusAsync(projectStatus, langLCID);

			return this._mapper.Map<IEnumerable<T>>(res);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="projectStatus"></param>
		/// <param name="langLCID"></param>
		/// <returns></returns>
		private async Task<IEnumerable<ProjectModel>> GetProjectsByStatusAsync(ProjectStatusDTO projectStatus, int langLCID)
		{
			if (!Enum.IsDefined(typeof(ProjectStatusDTO), projectStatus))
			{
				throw new ArgumentNullException(nameof(projectStatus), "Your argument is Null, Empty or WhiteSpace");
			}

			var requestResult = await this._repository.Projects
				.Where(e => e.Status.Equals(projectStatus.ToString(), StringComparison.OrdinalIgnoreCase) && e.Language.LanguageCode == langLCID)
				.ToListAsync();

			if (requestResult == null)
			{
				throw new InvalidOperationException("Cant't find projects with such options.");
			}

			return this._mapper.Map<IEnumerable<DTOModels.ProjectModel>>(requestResult);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="projectStatus"></param>
		/// <param name="startIndex"></param>
		/// <param name="endIndex"></param>
		/// <param name="langLCID"></param>
		/// <returns></returns>
		public async Task<IEnumerable<T>> GetProjectsPreviewsAsync<T>(ProjectStatusDTO projectStatus, int startIndex, int endIndex, int langLCID)
		{
			var res = await this.GetProjectsByStatusAsync(projectStatus, startIndex, endIndex, langLCID);

			return this._mapper.Map<IEnumerable<T>>(res);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="projectStatus"></param>
		/// <param name="startIndex"></param>
		/// <param name="endIndex"></param>
		/// <param name="langLCID"></param>
		/// <returns></returns>
		private async Task<IEnumerable<ProjectModel>> GetProjectsByStatusAsync(ProjectStatusDTO projectStatus, int startIndex, int endIndex, int langLCID)
		{
			if (!Enum.IsDefined(typeof(ProjectStatusDTO), projectStatus))
			{
				throw new ArgumentNullException(nameof(projectStatus), "Your argument is Null, Empty or WhiteSpace");
			}

			if (startIndex < 0 || endIndex < 0)
			{
				throw new IndexOutOfRangeException("Your start or end index is smaller than zero.");
			}

			var requestResult = await this._repository.Projects
				.Where(e => e.Status.Equals(projectStatus.ToString(), StringComparison.OrdinalIgnoreCase) && e.Language.LanguageCode == langLCID)
				.ToListAsync();

			var takenProjects = requestResult
				.Skip(startIndex)
				.Take(endIndex);

			if (requestResult == null)
			{
				throw new InvalidOperationException("Cant't find projects with such options.");
			}

			return this._mapper.Map<IEnumerable<DTOModels.ProjectModel>>(takenProjects);
		}

	}
}
