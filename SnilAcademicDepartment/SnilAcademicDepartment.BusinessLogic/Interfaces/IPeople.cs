using SnilAcademicDepartment.BusinessLogic.DTOModels;
using SnilAcademicDepartment.Common.Enumerations.DepartmentStaff;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnilAcademicDepartment.BusinessLogic.Interfaces
{
	/// <summary>
	/// Interface of getter person service.
	/// </summary>
	public interface IPeople
    {
		/// <summary>
		/// 
		/// </summary>
		/// <param name="count">Number of leaders to display.</param>
		/// <param name="langLCID">Language LCID.</param>
		/// <returns></returns>
        Task<IEnumerable<Leader>> GetHallOfFameLeadersAsync(int count, int langLCID);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="personId">Person unique di.</param>
		/// <param name="langLCID">Language LCID.</param>
		/// <returns></returns>
		Task<PersonVM> GetPersonDescriptionAsync(int personId, int langLCID);

		/// <summary>
		/// Gets pedagogical staff by
		/// </summary>
		/// <param name="staffType"></param>
		/// <param name="langLCID">Language LCID.</param>
		/// <returns></returns>
		Task<IEnumerable<Pedagogue>> GetPedagogicalStaffAsync(PedagogicalStaffType staffType, int langLCID);
	}
}