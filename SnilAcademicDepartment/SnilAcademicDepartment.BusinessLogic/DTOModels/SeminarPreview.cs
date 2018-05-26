using System.Collections.Generic;

namespace SnilAcademicDepartment.BusinessLogic.DTOModels
{
    public class SeminarPreview
    {
        public string Title { get; set; }

        public IEnumerable<string> SpeakersFullName { get; set; }

        public string ProfessionStatus { get; set; }

        public string Description { get; set; }
    }
}
