namespace SnilAcademicDepartment.DataAccess.Models
{
    public partial class EducationTopic
    {
        public int EducationTopicId { get; set; }

        public string TopicName { get; set; }

        public int EducationBlockType { get; set; }

        public virtual EducationBlock EducationBlock { get; set; }
    }
}
