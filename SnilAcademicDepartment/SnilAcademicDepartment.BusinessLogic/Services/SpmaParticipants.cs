using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnilAcademicDepartment.BusinessLogic.DTOModels;
using SnilAcademicDepartment.BusinessLogic.Interfaces;

namespace SnilAcademicDepartment.BusinessLogic.Services
{
	public class SpmaParticipants : ISpmaParticipants
	{
		public Task<SpmaPerson> GetStuffPersonal()
		{
			throw new NotImplementedException();
		}

		public Task<SpmaStudent> GetStuffStudents()
		{
			throw new NotImplementedException();
		}
	}
}
