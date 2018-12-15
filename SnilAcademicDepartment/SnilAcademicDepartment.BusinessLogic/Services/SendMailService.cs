using System;
using System.Threading.Tasks;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using System.Net.Mail;
using AutoMapper;
using SnilAcademicDepartment.BusinessLogic.DTOModels;
using SnilAcademicDepartment.MailService;
using SnilAcademicDepartment.Common.ConfigManagerAdapter;
using MailService.Properties;

namespace SnilAcademicDepartment.BusinessLogic.Services
{
    public class SendMailService : ISendMail
    {
        private readonly SMTPService _mailClient;
		private readonly ISNILConfigurationManager _configManager;
		private readonly IMapper _mapper;

        public SendMailService(SMTPService mailClient, ISNILConfigurationManager configManager, IMapper mapper)
        {
			this._mailClient = mailClient;
			this._configManager = configManager;
			this._mapper = mapper;
        }

        public async Task SendMailToAdminAsync(ClientMail clientMail)
        {
            if (string.IsNullOrWhiteSpace(clientMail.Email) || 
                string.IsNullOrWhiteSpace(clientMail.FullName) || 
                string.IsNullOrWhiteSpace(clientMail.Subject) ||
                string.IsNullOrWhiteSpace(clientMail.Message))
            {
                throw new ArgumentException("Mail can't be null or empty.", nameof(clientMail));
            }

			var mailMessage = this._mapper.Map<ClientMail, MailMessage>(clientMail);
			var departmentHeadMail = await this._configManager.GetConfigValueStringAsync(SnilMailingConfigurationKeys.EmailHeadOfDepartment);
			var departmentHelperMail = await this._configManager.GetConfigValueStringAsync(SnilMailingConfigurationKeys.EmailRightHandOfDepartment);

			mailMessage.To.Add(departmentHeadMail);
			mailMessage.CC.Add(new MailAddress(clientMail.Email));
			mailMessage.CC.Add(new MailAddress(departmentHelperMail));
			await this._mailClient.SendEmailAsync(mailMessage);
        }
    }
}
