using  System.Collections.Generic;
using System.Threading.Tasks;

namespace SnilAcademicDepartment.BusinessLogic.Interfaces
{
    public interface ILecturePreview
    {
        /// <summary>
        /// Get lectures.
        /// </summary>
        /// <typeparam name="TPreviewType">Type on what we should map type of Lecture.</typeparam>
        /// <param name="numberOfLectures">Number of the lecture to get.</param>
        /// <param name="lcid">Language code of the lecture.</param>
        /// <returns>Previews of the lecture.</returns>
        IEnumerable<TPreviewType> GetLecturePreviews<TPreviewType>(int numberOfLectures, int lcid);

        /// <summary>
        /// Get lectures async.
        /// </summary>
        /// <typeparam name="TPreviewType">Type on what we should map type of Lecture.</typeparam>
        /// <param name="numberOfLectures">Number of the lecture to get.</param>
        /// <param name="lcid">Language code of the lecture.</param>
        /// <returns>Previews of the lecture.</returns>
        Task<IEnumerable<TPreviewType>> GetLecturePreviewsAsync<TPreviewType>(int numberOfLectures, int lcid);
    }
}