using System.Collections.Generic;
using System.Threading.Tasks;
using SnilAcademicDepartment.BusinessLogic.DTOModels;

namespace SnilAcademicDepartment.BusinessLogic.Interfaces
{
	/// <summary>
	/// Interface of SPMA stuff (Students + Persons)
	/// </summary>
	public interface ISpmaParticipants
	{
		Task<IEnumerable<SpmaPerson>> GetStuffPersonal(int langLCID);
		Task<SpmaPerson> GetStuffPersonById(int uniqueId, int langLCID);
		Task<IEnumerable<SpmaStudent>> GetStuffStudents(int langLCID);
		Task<SpmaStudent> GetStuffStudentById(int uniqueId, int langLCID);
	}
}
