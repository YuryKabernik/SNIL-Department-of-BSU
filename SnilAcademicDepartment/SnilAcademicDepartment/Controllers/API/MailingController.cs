using System.Threading.Tasks;
using System.Web.Http;
using NLog;
using SnilAcademicDepartment.BusinessLogic.DTOModels;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.Resources.ContactsResources;
using SnilAcademicDepartment.ViewModels;

namespace SnilAcademicDepartment.Controllers
{
	public class MailingController : ApiController
	{
		private readonly ISendMail _mailSender;
		private readonly ILogger _logger;

		public MailingController(ILogger logger, ISendMail mailSender)
		{
			this._mailSender = mailSender;
			this._logger = logger;
		}

		[HttpPost]
		public async Task<IHttpActionResult> SendMailMessage([FromBody]ClientMail mail)
		{
			await this._mailSender.SendMailToAdminAsync(mail);

			return this.Ok(new MailingResult
			{
				ResultCode = 200,
				ResultMessage = ContactsResource.MessageSentSuccess
			});
		}
	}
}
