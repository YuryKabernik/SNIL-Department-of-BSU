using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SnilAcademicDepartment.BusinessLogic.DTOModels;

namespace SnilAcademicDepartment.BusinessLogic.Interfaces.API
{
	/// <summary>
	/// Class for diplomas api.
	/// </summary>
	public interface IDiplomasApiService
	{
		/// <summary>
		/// Gets all diplomas from database.
		/// </summary>
		/// <returns></returns>
		Task<List<UiDiploma>> GetDiplomas(int lcid);

		/// <summary>
		/// Gets the diplomas before selected date.
		/// </summary>
		/// <returns></returns>
		Task<List<UiDiploma>> GetDiplomasBeforeDate(DateTime dateTime, int lcid);

		/// <summary>
		/// Gets the diplomas after selected date.
		/// </summary>
		/// <returns></returns>
		Task<List<UiDiploma>> GetDiplomasAfterDate(DateTime dateTime, int lcid);

		/// <summary>
		/// Gets the diplomas from one to another selected date.
		/// </summary>
		/// <returns></returns>
		Task<List<UiDiploma>> GetDiplomasFromDateToDate(DateTime fromDate, DateTime toDate, int lcid);
	}
}
