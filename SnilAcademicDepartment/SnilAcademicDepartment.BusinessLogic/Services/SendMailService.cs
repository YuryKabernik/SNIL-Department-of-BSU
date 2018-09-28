using System;
using System.Threading.Tasks;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using System.Net.Mail;
using AutoMapper;
using SnilAcademicDepartment.BusinessLogic.DTOModels;
using SnilAcademicDepartment.MailService;

namespace SnilAcademicDepartment.BusinessLogic.Services
{
    public class SendMailService : IMailSender, ISendMail
    {
        private readonly SMTPService _mailClient;
        private readonly IMapper _mapper;

        public SendMailService(SMTPService mailClient, IMapper mapper)
        {
            _mailClient = mailClient;
            _mapper = mapper;
        }

        public void SendMail(MailMessage mail)
        {
            this._mailClient.SendEmail(mail);
        }

        public Task SendMailAsync(MailMessage mail)
        {
            // await this._mailClient.SendMailAsync(mail);
            return Task.CompletedTask;
        }

        public void SendMailToAdmin(ClientMail clientMail)
        {
            var mailMessage = this._mapper.Map<ClientMail,MailMessage>(clientMail);
            mailMessage.To.Add("kobernicyri@mail.ru");
            mailMessage.To.Add("skakun@bsu.by");
            mailMessage.CC.Add(new MailAddress(clientMail.Email));
            mailMessage.CC.Add(new MailAddress("yakubovskiy@bsu.by"));
            this._mailClient.SendEmail(mailMessage);
        }

        public Task SendMailToAdminAsync(ClientMail clientMail)
        {
            if (string.IsNullOrWhiteSpace(clientMail.Email) || 
                string.IsNullOrWhiteSpace(clientMail.FullName) || 
                string.IsNullOrWhiteSpace(clientMail.Subject) ||
                string.IsNullOrWhiteSpace(clientMail.Message))
            {
                throw new ArgumentException("Mail can't be null or empty.", nameof(clientMail));
            }

            var mailMessage = this._mapper.Map<MailMessage>(clientMail);
            //await this._mailClient.SendMailAsync(mailMessage);
            return Task.CompletedTask;
        }
    }
}
