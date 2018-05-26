using System.Collections.Generic;

namespace SnilAcademicDepartment.BusinessLogic.DTOModels
{
    public class EducationBlockModel
    {
        /// <summary>
        /// Key area block title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Description of the key area block.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Image of the current block.
        /// </summary>
        public byte[] Image { get; set; }

        /// <summary>
        /// Topics of this ke area block.
        /// </summary>
        public IEnumerable<string> Topics { get; set; }

        /// <summary>
        /// The id of the action.
        /// </summary>
        public int ActionId { get; set; }
    }
}
