using System.Collections.Generic;

namespace SnilAcademicDepartment.BusinessLogic.DTOModels
{
    public class PersonVM
    {
        public int Id { get; set; }

        public string PersonName { get; set; }

        public string SecoundName { get; set; }

        public string FathersName { get; set; }

        public string ProfessionStatus { get; set; }

        public string Degree { get; set; }

        public string AcademicTitle { get; set; }

        public string PersonalInterests { get; set; }

        public int ImageId { get; set; }

        public string Biography { get; set; }

        public IEnumerable<string> Projects { get; set; }

        public IEnumerable<string> Seminars { get; set; }

        public IEnumerable<string> Lectures { get; set; }
    }
}
