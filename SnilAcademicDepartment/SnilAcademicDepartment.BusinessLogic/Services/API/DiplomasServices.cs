using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NLog;
using SnilAcademicDepartment.BusinessLogic.DTOModels;
using SnilAcademicDepartment.BusinessLogic.Interfaces.API;
using SnilAcademicDepartment.DataAccess;
using SnilAcademicDepartment.DataAccess.Models.Education;

namespace SnilAcademicDepartment.BusinessLogic.Services.API
{
	public class DiplomasServices : IDiplomasApiService
	{
		private readonly ILogger _logger;
		private readonly IMapper _mapper;
		private readonly SnilDBContext _repository;

		/// <summary>
		/// Initializes a new instance of the <see cref="DiplomasServices"/> class.
		/// </summary>
		/// <param name="logger">The logger.</param>
		/// <param name="repository">The repository.</param>
		/// <param name="mapper">The mapper.</param>
		public DiplomasServices(ILogger logger, SnilDBContext repository, IMapper mapper)
		{
			this._logger = logger;
			this._mapper = mapper;
			this._repository = repository;
		}

		/// <summary>
		/// Gets all diplomas from database.
		/// </summary>
		/// <param name="lcid"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException">Language id cant be equal or less than zero. - lcid</exception>
		/// <exception cref="ArgumentNullException">requestResult - Cant finde any diploma by requested parameters.</exception>
		public async Task<List<UiDiploma>> GetDiplomas(int lcid)
		{
			if (lcid <= 0)
			{
				throw new ArgumentException("Language id cant be equal or less than zero.", nameof(lcid));
			}

			List<Diploma> requestResult = await this._repository.Diplomas
				.Include(d => d.Localization)
				.Include(d => d.Teachers)
				.Where(diploma => diploma.Localization.LanguageCode == lcid)
				.ToListAsync();

			if (requestResult == null)
			{
				throw new ArgumentNullException(nameof(requestResult), "Cant finde any diploma by requested parameters.");
			}

			return this._mapper.Map<List<UiDiploma>>(requestResult);
		}

		/// <summary>
		/// Gets the diplomas after selected date.
		/// </summary>
		/// <param name="dateTime"></param>
		/// <param name="lcid"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException">Language id cant be equal or less than zero. - lcid</exception>
		/// <exception cref="ArgumentNullException">requestResult - Cant finde any diploma by requested parameters.</exception>
		public async Task<List<UiDiploma>> GetDiplomasAfterDate(DateTime dateTime, int lcid)
		{
			if (lcid <= 0)
			{
				throw new ArgumentException("Language id cant be equal or less than zero.", nameof(lcid));
			}

			List<Diploma> requestResult = await this._repository.Diplomas
				.Include(d => d.Localization)
				.Include(d => d.Teachers)
				.Where(diploma =>
					diploma.Localization.LanguageCode == lcid &&
					diploma.ProtectionDate.Date > dateTime.Date
				)
				.ToListAsync();

			if (requestResult == null)
			{
				throw new ArgumentNullException(nameof(requestResult), "Cant finde any diploma by requested parameters.");
			}

			return this._mapper.Map<List<UiDiploma>>(requestResult);
		}

		/// <summary>
		/// Gets the diplomas before selected date.
		/// </summary>
		/// <param name="dateTime"></param>
		/// <param name="lcid"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException">Language id cant be equal or less than zero. - lcid</exception>
		/// <exception cref="ArgumentNullException">requestResult - Cant finde any diploma by requested parameters.</exception>
		public async Task<List<UiDiploma>> GetDiplomasBeforeDate(DateTime dateTime, int lcid)
		{
			if (lcid <= 0)
			{
				throw new ArgumentException("Language id cant be equal or less than zero.", nameof(lcid));
			}

			List<Diploma> requestResult = await this._repository.Diplomas
				.Include(d => d.Localization)
				.Include(d => d.Teachers)
				.Where(diploma =>
					diploma.Localization.LanguageCode == lcid &&
					diploma.ProtectionDate.Date < dateTime.Date
				).ToListAsync();

			if (requestResult == null)
			{
				throw new ArgumentNullException(nameof(requestResult), "Cant finde any diploma by requested parameters.");
			}

			return this._mapper.Map<List<UiDiploma>>(requestResult);
		}

		/// <summary>
		/// Gets the diplomas from one to another selected date.
		/// </summary>
		/// <param name="fromDate"></param>
		/// <param name="toDate"></param>
		/// <param name="lcid"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException">Language id cant be equal or less than zero. - lcid</exception>
		/// <exception cref="ArgumentNullException">requestResult - Cant finde any diploma by requested parameters.</exception>
		public async Task<List<UiDiploma>> GetDiplomasFromDateToDate(DateTime fromDate, DateTime toDate, int lcid)
		{
			if (lcid <= 0)
			{
				throw new ArgumentException("Language id cant be equal or less than zero.", nameof(lcid));
			}

			List<Diploma> requestResult = await this._repository.Diplomas
				.Include(d => d.Localization)
				.Include(d => d.Teachers)
				.Where(diploma =>
					diploma.Localization.LanguageCode == lcid &&
					diploma.ProtectionDate.Date < fromDate.Date &&
					diploma.ProtectionDate.Date > toDate.Date
				).ToListAsync();

			if (requestResult == null)
			{
				throw new ArgumentNullException(nameof(requestResult), "Cant finde any diploma by requested parameters.");
			}

			return this._mapper.Map<List<UiDiploma>>(requestResult);
		}
	}
}