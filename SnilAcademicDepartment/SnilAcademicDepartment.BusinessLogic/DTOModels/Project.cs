using System;

namespace SnilAcademicDepartment.BusinessLogic.DTOModels
{
    public class ProjectModel
    {
        public int ProjectId { get; set; }

        public string ProjectTitle { get; set; }

        public string Description { get; set; }

        public string ShortDescription { get; set; }

        public string ProjectStatus { get; set; }

        public byte[] Document { get; set; }

        public int ImageId { get; set; }

        /// <summary>
        /// Language LCID code.
        /// </summary>
        public int Localisation { get; set; }

        public DateTime? CreationDate { get; set; }
    }
}
