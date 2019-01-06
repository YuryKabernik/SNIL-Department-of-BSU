namespace SnilAcademicDepartment.BusinessLogic.DTOModels
{
    public class Leader
    {
        /// <summary>
        /// Leader id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Full name of leader.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Leader's foto.
        /// </summary>
        public int ImageId { get; set; }

        /// <summary>
        /// Leader's points.
        /// </summary>
        public int Points { get; set; }
    }
}
