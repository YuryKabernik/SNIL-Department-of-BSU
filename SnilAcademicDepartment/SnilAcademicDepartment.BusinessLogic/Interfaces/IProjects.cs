using SnilAcademicDepartment.BusinessLogic.DTOModels;
using System.Collections.Generic;

namespace SnilAcademicDepartment.BusinessLogic.Interfaces
{
    public interface IProjects
    {
        /// <summary>
        /// Get first project by type anf language code.
        /// </summary>
        /// <param name="projectType"></param>
        /// <param name="langLCID"></param>
        /// <returns></returns>
        Project GetProject(string projectStatus, int langLCID);

        /// <summary>
        /// Get all projects.
        /// </summary>
        /// <param name="projectType">Status of the project.</param>
        /// <param name="langLCID"></param>
        /// <returns></returns>
        IEnumerable<Project> GetProjects(string projectStatus, int langLCID);

        /// <summary>
        /// Get number of projects from start to end index.
        /// </summary>
        /// <param name="projectType"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="langLCID"></param>
        /// <returns></returns>
        IEnumerable<Project> GetProjects(string projectStatus, int startIndex, int endIndex, int langLCID);
    }
}