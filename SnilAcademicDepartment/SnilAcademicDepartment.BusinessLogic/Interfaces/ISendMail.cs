using System.Threading.Tasks;
using SnilAcademicDepartment.BusinessLogic.DTOModels;

namespace SnilAcademicDepartment.BusinessLogic.Interfaces
{
    public interface ISendMail
    {
        /// <summary>
        /// Send mail to static person( site administrator ) in async.
        /// </summary>
        /// <param name="clientMail">Custom mail object.</param>
        /// <returns></returns>
        Task SendMailToAdminAsync(ClientMail clientMail);
    }
}