using System;
using System.Threading.Tasks;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using System.Net.Mail;
using AutoMapper;
using SnilAcademicDepartment.BusinessLogic.DTOModels;

namespace SnilAcademicDepartment.BusinessLogic.Services
{
    public class SendMailService : IMailSender, ISendMail
    {
        private readonly SmtpClient _mailClient;
        private readonly IMapper _mapper;

        public SendMailService(SmtpClient mailClient, IMapper mapper)
        {
            _mailClient = mailClient;
            _mapper = mapper;
        }

        public void SendMail(MailMessage mail)
        {
            this._mailClient.Send(mail);
        }

        public async Task SendMailAsync(MailMessage mail)
        {
            await this._mailClient.SendMailAsync(mail);
        }

        public void SendMailToAdmin(ClientMail clientMail)
        {
            var mailMessage = this._mapper.Map<MailMessage>(clientMail);
            this._mailClient.Send(mailMessage);
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

            var mailMessage = new MailMessage(clientMail.Email, "kobernicyri@mail.ru", clientMail.Subject,
                clientMail.Company + clientMail.Message);
            
            await this._mailClient.SendMailAsync(mailMessage);
        }
    }
}
