using System.Collections.Generic;

namespace SnilAcademicDepartment.BusinessLogic.Interfaces
{
    public interface ISeminarPreview
    {
        /// <summary>
        /// Get seminars.
        /// </summary>
        /// <typeparam name="TPreviewType">Type on what we should map type of Seminar.</typeparam>
        /// <param name="numberOfSeminars">Number of the seminars to get.</param>
        /// <param name="lcid">Language code of the seminar.</param>
        /// <returns>Previews of the seminars.</returns>
        IEnumerable<TPreviewType> GetSeminarPreviews<TPreviewType>(int numberOfSeminars, int lcid);
    }
}
