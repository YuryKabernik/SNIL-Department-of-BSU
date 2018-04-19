using SnilAcademicDepartment.BusinessLogic.Enums;
using SnilAcademicDepartment.BusinessLogic.Models;
using System.Collections.Generic;

namespace SnilAcademicDepartment.BusinessLogic.Interfaces
{
    public interface IProjects
    {
        PreView GetPreView();

        /// <summary>
        /// Get current/finished/conference projects.
        /// </summary>
        IEnumerable<Project> GetProjects(ProjectType projectType);
    }
}