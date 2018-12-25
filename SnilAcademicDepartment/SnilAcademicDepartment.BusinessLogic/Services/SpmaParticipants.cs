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
	public class SpmaParticipants : ISpmaParticipants
	{
		private readonly ILogger _logger;
		private readonly SnilDBContext _repository;
		private readonly IMapper _mapper;

		public SpmaParticipants(ILogger logger, SnilDBContext repository, IMapper mapper)
		{
			_logger = logger;
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<SpmaPerson>> GetStuffPersonal(int langLCID)
		{
			var result = await this._repository.StuffPersonals
				.Where(p => p.PersonId.Language.LanguageCode == langLCID)
				.Include(prop => prop.PersonId)
				.Include(prop => prop.PersonId.Image)
				.ToListAsync();

			return this._mapper.Map<IEnumerable<SpmaPerson>>(result);
		}

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
