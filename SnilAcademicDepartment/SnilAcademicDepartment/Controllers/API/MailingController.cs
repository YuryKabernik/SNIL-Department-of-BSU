using System;
using System.Threading.Tasks;
using System.Web.Http;
using NLog;
using SnilAcademicDepartment.BusinessLogic.DTOModels;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.Filters;
using SnilAcademicDepartment.ViewModels;
using SnilAcademicDepartment.Resources.ContactsResources;

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
		[HttpCultureAttribute]
		[ValidateHttpAntiForgeryToken]
		public async Task<IHttpActionResult> SendMailMessage([FromBody]ClientMail mail)
		{
			var mailresult = new MailingResult();
			try
			{
				await this._mailSender.SendMailToAdminAsync(mail);
				mailresult.ResultCode = 200;
				mailresult.ResultMessage = ContactsResource.MessageSentSuccess;
			}
			catch (Exception)
			{
				return this.BadRequest(ContactsResource.MessageSentFailed + ContactsResource.VictorSkakunMail);
			}
			return this.Ok(mailresult);
		}
	}
}
