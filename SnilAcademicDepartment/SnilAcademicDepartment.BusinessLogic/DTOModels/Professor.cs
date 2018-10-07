namespace SnilAcademicDepartment.BusinessLogic.DTOModels
{
    /// <summary>
    /// Data object of persons.
    /// </summary>
    public class Professor : PersonVM
    {
        /// <summary>
        /// Professor's email address.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Professor's phone number.
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
