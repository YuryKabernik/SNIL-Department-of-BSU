using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnilAcademicDepartment.BusinessLogic
{
    /// <summary>
    /// Interface of the main service methods.
    /// </summary>
    public interface IService
    {
        string GetText();
        byte[] GetPhoto();
        string GetArticle();
        byte[] GetFile();
        string GetPreview();
    }
}
