using SnilAcademicDepartment.BusinessLogic.DTOModels;
using System.Collections.Generic;

namespace SnilAcademicDepartment.BusinessLogic.Interfaces
{
    public interface IEducation
    {
        List<EducationBlockModel> GetKeyAreas(int pages, int lCID);
    }
}