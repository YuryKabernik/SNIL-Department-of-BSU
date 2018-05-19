using SnilAcademicDepartment.BusinessLogic.DTOModels;
using System.Collections.Generic;

namespace SnilAcademicDepartment.BusinessLogic.Interfaces
{
    public interface IProjects
    {
        /// <summary>
        /// Get first project by type and language code.
        /// </summary>
        /// <param name="projectType"></param>
        /// <param name="langLCID"></param>
        /// <returns></returns>
        ProjectModel GetProjectByStatus(string projectStatus, int langLCID);

        /// <summary>
        /// Get project by id and language code.
        /// </summary>
        /// <param name="projectType"></param>
        /// <param name="langLCID"></param>
        /// <returns></returns>
        ProjectModel GetProjectById(int projectStatus, int langLCID);

        /// <summary>
        /// Get all projects.
        /// </summary>
        /// <param name="projectType">Status of the project.</param>
        /// <param name="langLCID"></param>
        /// <returns></returns>
        IEnumerable<ProjectModel> GetProjectsByStatus(string projectStatus, int langLCID);

        /// <summary>
        /// Get number of projects from start to end index.
        /// </summary>
        /// <param name="projectType"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="langLCID"></param>
        /// <returns></returns>
        IEnumerable<ProjectModel> GetProjectsByStatus(string projectStatus, int startIndex, int endIndex, int langLCID);
    }
}