using System.Net.Mail;
using System.Threading.Tasks;

namespace SnilAcademicDepartment.BusinessLogic.Interfaces
{
    public interface IMailSender
    {
        void SendMail(MailMessage mail);
        Task SendMailAsync(MailMessage mail);
    }
}