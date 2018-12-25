using AutoMapper;
using NLog;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using SnilAcademicDepartment.BusinessLogic.DTOModels;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.DataAccess;
using System.Data.Entity;

namespace SnilAcademicDepartment.BusinessLogic.Services
{
	/// <summary>
	/// Spma stuff structure service.
	/// </summary>
	/// <seealso cref="SnilAcademicDepartment.BusinessLogic.Interfaces.ISpmaParticipants" />
	public class SpmaParticipants : ISpmaParticipants
	{
		private readonly ILogger _logger;
		private readonly SnilDBContext _repository;
		private readonly IMapper _mapper;

		/// <summary>
		/// Initializes a new instance of the <see cref="SpmaParticipants"/> class.
		/// </summary>
		/// <param name="logger">The logger.</param>
		/// <param name="repository">The repository.</param>
		/// <param name="mapper">The mapper.</param>
		public SpmaParticipants(ILogger logger, SnilDBContext repository, IMapper mapper)
		{
			_logger = logger;
			_repository = repository;
			_mapper = mapper;
		}

		/// <summary>
		/// Gets the stuff personal.
		/// </summary>
		/// <param name="langLCID">The language lcid.</param>
		/// <returns>Collection of the snil stuff.</returns>
		public async Task<IEnumerable<SpmaPerson>> GetStuffPersonal(int langLCID)
		{
			var result = await this._repository.StuffPersonals
				.Where(p => p.PersonId.Language.LanguageCode == langLCID)
				.Include(prop => prop.PersonId)
				.Include(prop => prop.PersonId.Image)
				.ToListAsync();

			return this._mapper.Map<IEnumerable<SpmaPerson>>(result);
		}

		/// <summary>
		/// Gets the stuff person by identifier.
		/// </summary>
		/// <param name="uniqueId">The unique identifier.</param>
		/// <param name="langLCID">The language lcid.</param>
		/// <returns>Spma person by unique identifier.</returns>
		/// <exception cref="ArgumentOutOfRangeException">uniqueId - Argument can't be less or equal zero.</exception>
		public async Task<SpmaPerson> GetStuffPersonById(int uniqueId, int langLCID)
		{
			if (uniqueId <= 0)
				throw new ArgumentOutOfRangeException(nameof(uniqueId), "Argument can't be less or equal zero.");

			var result = await this._repository.StuffPersonals
				.Where(p => p.PersonId.Language.LanguageCode == langLCID)
				.Include(prop => prop.PersonId)
				.Include(prop => prop.PersonId.Image)
				.FirstOrDefaultAsync(p => p.PersonId.PersonUniqueIdentifire == uniqueId);

			return this._mapper.Map<SpmaPerson>(result);
		}

		/// <summary>
		/// Gets the stuff student by identifier.
		/// </summary>
		/// <param name="uniqueId">The unique identifier.</param>
		/// <param name="langLCID">The language lcid.</param>
		/// <returns>Spma student by unique identifier.</returns>
		/// <exception cref="ArgumentOutOfRangeException">uniqueId - Argument can't be less or equal zero.</exception>
		public async Task<SpmaStudent> GetStuffStudentById(int uniqueId, int langLCID)
		{
			if (uniqueId <= 0)
				throw new ArgumentOutOfRangeException(nameof(uniqueId), "Argument can't be less or equal zero.");

			var result = await this._repository.StuffStudents
				.Where(p => p.Student.Language.LanguageCode == langLCID)
				.Include(prop => prop.Student)
				.Include(prop => prop.Student.Image)
				.FirstOrDefaultAsync(p => p.Student.UniqueIdentifier == uniqueId);

			return this._mapper.Map<SpmaStudent>(result);
		}

		/// <summary>
		/// Gets the stuff students.
		/// </summary>
		/// <param name="langLCID">The language lcid.</param>
		/// <returns>Collection of spma students.</returns>
		public async Task<IEnumerable<SpmaStudent>> GetStuffStudents(int langLCID)
		{
			var result = await this._repository.StuffStudents
				.Where(p => p.Student.Language.LanguageCode == langLCID)
				.Include(prop => prop.Student)
				.Include(prop => prop.Student.Image)
				.ToListAsync();

			return this._mapper.Map<IEnumerable<SpmaStudent>>(result);
		}
	}
}
