using System.Threading.Tasks;
using SnilAcademicDepartment.BusinessLogic.DTOModels;

namespace SnilAcademicDepartment.BusinessLogic.Interfaces
{
	/// <summary>
	/// Interface of SPMA stuff (Students + Persons)
	/// </summary>
	public interface ISpmaParticipants
	{
		Task<SpmaPerson> GetStuffPersonal();
		Task<SpmaStudent> GetStuffStudents();
	}
}
