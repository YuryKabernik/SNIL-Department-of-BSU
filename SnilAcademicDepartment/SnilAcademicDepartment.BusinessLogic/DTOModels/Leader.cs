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
        public byte[] Image { get; set; }
    }
}
