using System;
using System.Collections.Generic;

namespace SnilAcademicDepartment.BusinessLogic.DTOModels
{
    public class SeminarPreview
    {
        public string Title { get; set; }

        public string Topic { get; set; }

        public string Speacker { get; set; }

        public IEnumerable<string> SpeakersProfessionStatusAndFullNames { get; set; }

        public int? DocumentId { get; set; }

        public DateTime EventDate { get; set; }
    }
}
