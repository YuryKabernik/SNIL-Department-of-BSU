using SnilAcademicDepartment.BusinessLogic.DTOModels;

namespace SnilAcademicDepartment.BusinessLogic.Interfaces
{
    public interface ISendMail
    {
        void SendMailToAdmin(ClientMail clientMail);
    }
}