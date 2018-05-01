using System.Threading.Tasks;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using System.Net.Mail;

namespace SnilAcademicDepartment.BusinessLogic.Services
{
    public class SendMailService : IMailSender
    {
        public void SendMail(MailMessage mail)
        {
            throw new System.NotImplementedException();
        }

        public Task SendMailAsync(MailMessage mail)
        {
            throw new System.NotImplementedException();
        }
    }
}
