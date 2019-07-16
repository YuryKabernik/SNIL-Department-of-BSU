using System.Web.Mvc;

namespace SnilAcademicDepartment.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	/// <seealso cref="System.Web.Mvc.Controller" />
	[RoutePrefix("{language}")]
	public class ErrorController : Controller
	{
		/// <summary>
		/// Errors this instance.
		/// </summary>
		/// <returns></returns>
		[Route("error")]
		public ActionResult Error()
		{
			return View("Error");
		}

		/// <summary>
		/// Sorries the unavailable.
		/// </summary>
		/// <returns></returns>
		[Route("unavailable")]
		public ActionResult SorryUnavailable()
		{
			return View("SorryUnavaliable");
		}
	}
}