using NLog;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.BusinessLogic.DTOModels;
using SnilAcademicDepartment.DataAccess;
using System;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using SnilAcademicDepartment.DataAccess.Models;
using SnilAcademicDepartment.Common.Enumerations;

namespace SnilAcademicDepartment.BusinessLogic.Services
{
	public class PeopleService : IPeople
	{
		private readonly ILogger _logger;
		private readonly SnilDBContext _repository;
		private readonly IMapper _mapper;

		public PeopleService(ILogger logger, SnilDBContext repository, IMapper mapper)
		{
			this._logger = logger;
			this._repository = repository;
			this._mapper = mapper;
		}

		/// <summary>
		/// Get leaders of the hall of fame.
		/// </summary>
		/// <param name="count">Number of leaders to display.</param>
		/// <param name="langLCID">Current language LCID.</param>
		/// <returns>Collection of the leader's short descriptions.</returns>
		public async Task<IEnumerable<Leader>> GetHallOfFameLeadersAsync(int count, int langLCID)
		{
			if (count <= 0)
				throw new ArgumentOutOfRangeException(nameof(count), "Argument can't be less or equal zero.");

			var leadersIdCollection = this._repository.HallOfFames
				.OrderByDescending(person => person.Points)
				.Take(count)
				.Select<HallOfFame, int>(p => p.Person.PersonUniqueIdentifire)
				.Distinct();

			var result = await this._repository.People
				.Where(p => leadersIdCollection.Any(id => id == p.PersonUniqueIdentifire) && p.Language.LanguageCode == langLCID)
				.Include(prop => prop.Image)
				.ToListAsync();

			return this._mapper.Map<IEnumerable<Leader>>(result);
		}

		/// <summary>
		/// Get person description by person's unique identifier and current localisation.
		/// </summary>
		/// <param name="personId">Person's unique id.</param>
		/// <param name="langLCID">Current language LCID.</param>
		/// <returns></returns>
		public async Task<PersonVM> GetPersonDescriptionAsync(int personId, int langLCID)
		{
			if (personId <= 0)
				throw new ArgumentOutOfRangeException(nameof(personId), "Argument can't be less or equal zero.");

			var result = await this._repository.People
				.Where(p => p.Language.LanguageCode == langLCID)
				.Include(prop => prop.Image)
				.Include(prop => prop.Degree)
				.Include(prop => prop.AcademicTitle)
				.Include(prop => prop.ProfessionStatus)
				.FirstOrDefaultAsync(p => p.PersonUniqueIdentifire == personId);

			return this._mapper.Map<PersonVM>(result);
		}

		/// <summary>
		/// Get person by degree.
		/// </summary>
		/// <typeparam name="T">Specific type of person model to map and return.</typeparam>
		/// <param name="degreeName">Person's degree.</param>
		/// <param name="langLCID">Current language LCID.</param>
		/// <returns>Returns collestion of persons of a specific education degree.</returns>
		public async Task<IEnumerable<T>> GetPersonsByDegreeAsync<T>(DegreeEnum degreeName, int langLCID)
		{
			if (degreeName != null)
			{
				throw new ArgumentNullException(nameof(degreeName), "Argument can't be null, empty or white space.");
			}

			var result = await this._repository.People
				.Where(p => p.Degree.UniqueCode == (int)degreeName && p.Language.LanguageCode == langLCID)
				.Include(prop => prop.Image)
				.Include(prop => prop.Degree)
				.Include(prop => prop.AcademicTitle)
				.Include(prop => prop.ProfessionStatus)
				.ToListAsync();

			return this._mapper.Map<IEnumerable<T>>(result);
		}

		/// <summary>
		/// Get person by academic title.
		/// </summary>
		/// <typeparam name="T">Specific type of person model to map and return.</typeparam>
		/// <param name="academicTitle"></param>
		/// <param name="langLCID"></param>
		/// <returns>Returns collestion of persons of a specific academic title.</returns>
		public async Task<IEnumerable<T>> GetPersonsByAcademicTitleAsync<T>(AcademicTitleEnum academicTitle, int langLCID)
		{
			if (academicTitle != null)
			{
				throw new ArgumentNullException(nameof(academicTitle), "Argument can't be null, empty or white space.");
			}

			var result = await this._repository.People
				.Where(p => p.AcademicTitle.UniqueCode == (int)academicTitle && p.Language.LanguageCode == langLCID)
				.Include(prop => prop.Image)
				.Include(prop => prop.Degree)
				.Include(prop => prop.AcademicTitle)
				.Include(prop => prop.ProfessionStatus)
				.ToListAsync();

			return this._mapper.Map<IEnumerable<T>>(result);
		}

		/// <summary>
		/// Get person by profession.
		/// </summary>
		/// <typeparam name="T">Specific type of person model to map and return.</typeparam>
		/// <param name="professionStatus"></param>
		/// <param name="langLCID"></param>
		/// <returns>Returns collestion of persons of a specific profession status.</returns>
		public async Task<IEnumerable<T>> GetPersonsByProfessionStatusAsync<T>(ProfessionStatusEnum professionStatus, int langLCID)
		{
			if (professionStatus != null)
			{
				throw new ArgumentNullException(nameof(professionStatus), "Argument can't be null, empty or white space.");
			}

			var result = await this._repository.People
				.Where(p => p.ProfessionStatus.UniqueCode == (int)professionStatus && p.Language.LanguageCode == langLCID)
				.Include(prop => prop.Image)
				.Include(prop => prop.Degree)
				.Include(prop => prop.AcademicTitle)
				.Include(prop => prop.ProfessionStatus)
				.ToListAsync();

			return this._mapper.Map<IEnumerable<T>>(result);
		}
	}
}
