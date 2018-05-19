using SnilAcademicDepartment.BusinessLogic.DTOModels;
using System.Collections.Generic;

namespace SnilAcademicDepartment.BusinessLogic.Interfaces
{
    public interface IProjects
    {
        /// <summary>
        /// Get first project by type anf language code mapped to type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="projectType"></param>
        /// <param name="langLCID"></param>
        /// <returns></returns>
        T GetProject<T>(string projectStatus, int langLCID);

        /// <summary>
        /// Get all projects mapped to type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="projectType">Status of the project.</param>
        /// <param name="langLCID"></param>
        /// <returns></returns>
        IEnumerable<T> GetProjects<T>(string projectStatus, int langLCID);

        /// <summary>
        /// Get number of projects from start to end index mapped to type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="projectType"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="langLCID"></param>
        /// <returns></returns>
        IEnumerable<T> GetProjects<T>(string projectStatus, int startIndex, int endIndex, int langLCID);

        /// <summary>
        /// Get first project by type anf language code.
        /// </summary>
        /// <param name="projectType"></param>
        /// <param name="langLCID"></param>
        /// <returns></returns>
        ProjectModel GetProject(string projectStatus, int langLCID);

        /// <summary>
        /// Get all projects.
        /// </summary>
        /// <param name="projectType">Status of the project.</param>
        /// <param name="langLCID"></param>
        /// <returns></returns>
        IEnumerable<ProjectModel> GetProjects(string projectStatus, int langLCID);

        /// <summary>
        /// Get number of projects from start to end index.
        /// </summary>
        /// <param name="projectType"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="langLCID"></param>
        /// <returns></returns>
        IEnumerable<ProjectModel> GetProjects(string projectStatus, int startIndex, int endIndex, int langLCID);
    }
}