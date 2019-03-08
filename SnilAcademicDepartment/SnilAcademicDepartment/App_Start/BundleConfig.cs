using System.Web;
using System.Web.Optimization;

namespace SnilAcademicDepartment
{
	public class BundleConfig
	{
		// For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.UseCdn = true;   //включаем поддержку CDN

			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/jquery.validate*"));

			// Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
			// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
					  "~/Scripts/bootstrap.js",
					  "~/Scripts/respond.js"));

			var jqueryCdnPath = "https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css";

			bundles.Add(new ScriptBundle("~/bundles/font-awesome",
						jqueryCdnPath).Include(
						"~/Scripts/font-awesome.*"));

			bundles.Add(new ScriptBundle("~/bundles/form").Include(
						"~/Scripts/Platform/form.js"));
			//Layout page
			bundles.Add(new StyleBundle("~/Content/layoutcss").Include(
						"~/Content/Site.css",
						"~/Content/dropdown-box.css",
						"~/Content/bootstrap.min.css"));

			//IndexStyle
			bundles.Add(new StyleBundle("~/Content/indexcss").Include(
						"~/Content/IndexStyle.css"));
			//ProjectStyle
			bundles.Add(new StyleBundle("~/Content/projectscss").Include(
						"~/Content/Projects/ProjectsStyle.css"));
			//ParticipantsStyle
			bundles.Add(new StyleBundle("~/Content/participantscss").Include(
						"~/Content/Participants/ParticipantsStyle.css"));
			//HistoryStyle
			bundles.Add(new StyleBundle("~/Content/historycss").Include(
						"~/Content/History/HistoryStyle.css"));
			//PersonsStyle
			bundles.Add(new StyleBundle("~/Content/peoplecss").Include(
						"~/Content/Persons/PersonsStyle.css"));
			//PersonalPageStyle
			bundles.Add(new StyleBundle("~/Content/personalpagestylecss").Include(
						"~/Content/Persons/PersonalPageStyle.css"));
			//EducationStyle
			bundles.Add(new StyleBundle("~/Content/educationcss").Include(
					   "~/Content/Education/EducationStyle.css"));
			//ContactStyle
			bundles.Add(new StyleBundle("~/Content/contactcss").Include(
					   "~/Content/ContactStyle.css"));

			// Code removed for clarity.
			BundleTable.EnableOptimizations = true;
		}
	}
}
