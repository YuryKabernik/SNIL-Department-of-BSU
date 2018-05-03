using System.Threading.Tasks;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using System.Net.Mail;
using SnilAcademicDepartment.BusinessLogic.Models;

namespace SnilAcademicDepartment.BusinessLogic.Services
{
    public class SendMailService : IMailSender, ISendMail
    {
        public void SendMail(MailMessage mail)
        {
            throw new System.NotImplementedException();
        }

        public Task SendMailAsync(MailMessage mail)
        {
            throw new System.NotImplementedException();
        }

        public void SendMailToAdmin(ClientMail clientMail)
        {
            throw new System.NotImplementedException();
        }
    }
}
