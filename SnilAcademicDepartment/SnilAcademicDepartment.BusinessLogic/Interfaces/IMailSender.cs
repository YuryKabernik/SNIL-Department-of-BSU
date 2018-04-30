using System.Threading.Tasks;

namespace SnilAcademicDepartment.BusinessLogic.Interfaces
{
    public interface IMailSender
    {
        Task SendMailAsync();
        void SendMail();
    }
}