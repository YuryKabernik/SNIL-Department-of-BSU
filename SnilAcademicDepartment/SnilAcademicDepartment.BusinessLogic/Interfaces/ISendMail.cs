using SnilAcademicDepartment.BusinessLogic.Models;

namespace SnilAcademicDepartment.BusinessLogic.Interfaces
{
    public interface ISendMail
    {
        void SendMailToAdmin(ClientMail clientMail);
    }
}