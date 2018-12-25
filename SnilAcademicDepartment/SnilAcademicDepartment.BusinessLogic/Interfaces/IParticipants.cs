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
		/// <summary>
		/// Gets the stuff personal.
		/// </summary>
		/// <param name="langLCID">The language lcid.</param>
		/// <returns>Collection of the snil stuff.</returns>
		Task<IEnumerable<SpmaPerson>> GetStuffPersonal(int langLCID);
		/// <summary>
		/// Gets the stuff person by identifier.
		/// </summary>
		/// <param name="uniqueId">The unique identifier.</param>
		/// <param name="langLCID">The language lcid.</param>
		/// <returns>Spma person by unique identifier.</returns>
		Task<SpmaPerson> GetStuffPersonById(int uniqueId, int langLCID);
		/// <summary>
		/// Gets the stuff students.
		/// </summary>
		/// <param name="langLCID">The language lcid.</param>
		/// <returns>Spma student by unique identifier.</returns>
		Task<IEnumerable<SpmaStudent>> GetStuffStudents(int langLCID);
		/// <summary>
		/// Gets the stuff student by identifier.
		/// </summary>
		/// <param name="uniqueId">The unique identifier.</param>
		/// <param name="langLCID">The language lcid.</param>
		/// <returns>Collection of spma students.</returns>
		Task<SpmaStudent> GetStuffStudentById(int uniqueId, int langLCID);
	}
}
