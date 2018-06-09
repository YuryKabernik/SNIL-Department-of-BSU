using NLog;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.DataAccess;
using System;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using SnilAcademicDepartment.BusinessLogic.DTOModels;
using AutoMapper.QueryableExtensions;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SnilAcademicDepartment.BusinessLogic.Services
{
    public sealed class PreViewService : IService, ILecturePreview, ISeminarPreview
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly SnilDBContext _repository;

        public PreViewService(ILogger logger, SnilDBContext repository, IMapper mapper)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._repository = repository;
        }

        /// <summary>
        /// Method of getting firs or default preview of the page type.
        /// </summary>
        /// <param name="pageType">Type of the page.</param>
        /// <returns>Single page preview.</returns>
        public PreViewModel GetPagePreview(string pageType, int langLCID)
        {
            if (string.IsNullOrEmpty(pageType) || string.IsNullOrWhiteSpace(pageType))
            {
                throw new ArgumentNullException(nameof(pageType), "Your argument is Null, Empty or WhiteSpace");
            }

            var requestResult = this._repository.PreViews
                .FirstOrDefault(e => pageType.Equals(e.PageTypeName.PageTypeName,StringComparison.OrdinalIgnoreCase)
                && e.Language.LanguageCode == langLCID);

            if (requestResult == null)
            {
                throw new InvalidOperationException("Cant't find page preview");
            }

            return this._mapper.Map<PreViewModel>(requestResult);
        }

        /// <summary>
        /// Return a collection of previews from database.
        /// </summary>
        /// <param name="pageType">Name of the preview type.</param>
        /// <returns>Collection of preview.</returns>
        public IEnumerable<PreViewModel> GetPagePreviews(string pageType, int langLCID)
        {
            if (string.IsNullOrEmpty(pageType) || string.IsNullOrWhiteSpace(pageType))
            {
                throw new ArgumentNullException(nameof(pageType), "Your argument is Null, Empty or WhiteSpace");
            }

            var requestResult = this._repository.PreViews
                .Where(e => e.PageTypeName.PageTypeName == pageType && e.Language.LanguageCode == langLCID)
                .AsEnumerable();

            if (requestResult == null)
            {
                throw new InvalidOperationException("Cant't find previews for this page.");
            }

            return this._mapper.Map<IEnumerable<PreViewModel>>(requestResult);
        }


        /// <inheritdoc cref="ILecturePreview"/>
        public IEnumerable<TPreviewType> GetLecturePreviews<TPreviewType>(int numberOfLectures, int lcid)
        {
            if (numberOfLectures <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfLectures), "Number of lectures cant be equal or less than zero.");
            }

            if (lcid <= 0)
            {
                throw new ArgumentException("Language id cant be equal or less than zero.", nameof(lcid));
            }

            var lectures = this._repository.Lectures
                .Where(s => s.Language.LanguageCode == lcid)
                .Take(numberOfLectures)
                .AsEnumerable();

            if (lectures == null)
            {
                throw new ArgumentNullException(nameof(lectures),"Cant finde any lecture by requested parameters.");
            }

            return this._mapper.Map<IEnumerable<TPreviewType>>(lectures);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TPreviewType"></typeparam>
        /// <param name="numberOfSeminars"></param>
        /// <param name="lcid"></param>
        /// <returns></returns>
        public IEnumerable<IGrouping<int, TPreviewType>> GetSeminarPreviews<TPreviewType>(int numberOfSeminars, int lcid) where TPreviewType : SeminarPreview
        {
            if (numberOfSeminars <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfSeminars), "Number of seminars cant be equal or less than zero.");
            }

            if (lcid <= 0)
            {
                throw new ArgumentException("Language id cant be equal or less than zero.", nameof(lcid));
            }

            var seminars = this._repository.Seminars
                .Where(s => s.Language.LanguageCode == lcid)
                .Take(numberOfSeminars)
                .ToList()
                .AsQueryable()
                .ProjectTo<SeminarPreview>(this._mapper.ConfigurationProvider) // AutoMapper Extension
                .GroupBy<SeminarPreview, int>(k => k.EventDate.Year)
                .ToList();

            if (seminars == null)
            {
                throw new ArgumentNullException(nameof(seminars), "Cant finde any seminar by requested parameters.");
            }

            return (IEnumerable<IGrouping<int, TPreviewType>>)seminars;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageType"></param>
        /// <param name="langLCID"></param>
        /// <returns></returns>
        public async Task<PreViewModel> GetPagePreviewAsync(string pageType, int langLCID)
        {
            if (string.IsNullOrEmpty(pageType) || string.IsNullOrWhiteSpace(pageType))
            {
                throw new ArgumentNullException(nameof(pageType), "Your argument is Null, Empty or WhiteSpace");
            }

            var requestResult = await this._repository.PreViews
                .FirstOrDefaultAsync(e => pageType.Equals(e.PageTypeName.PageTypeName, StringComparison.OrdinalIgnoreCase)
                && e.Language.LanguageCode == langLCID);

            if (requestResult == null)
            {
                throw new InvalidOperationException("Cant't find page preview");
            }

            return this._mapper.Map<PreViewModel>(requestResult);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageType"></param>
        /// <param name="langLCID"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PreViewModel>> GetPagePreviewsAsync(string pageType, int langLCID)
        {
            if (string.IsNullOrEmpty(pageType) || string.IsNullOrWhiteSpace(pageType))
            {
                throw new ArgumentNullException(nameof(pageType), "Your argument is Null, Empty or WhiteSpace");
            }

            var requestResult = await this._repository.PreViews
                .Where(e => e.PageTypeName.PageTypeName == pageType && e.Language.LanguageCode == langLCID)
                .ToListAsync();

            if (requestResult == null)
            {
                throw new InvalidOperationException("Cant't find previews for this page.");
            }

            return this._mapper.Map<IEnumerable<PreViewModel>>(requestResult);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TPreviewType"></typeparam>
        /// <param name="numberOfLectures"></param>
        /// <param name="lcid"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TPreviewType>> GetLecturePreviewsAsync<TPreviewType>(int numberOfLectures, int lcid)
        {
            if (numberOfLectures <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfLectures), "Number of lectures cant be equal or less than zero.");
            }

            if (lcid <= 0)
            {
                throw new ArgumentException("Language id cant be equal or less than zero.", nameof(lcid));
            }

            var lectures = await this._repository.Lectures
                .Where(s => s.Language.LanguageCode == lcid)
                .Take(numberOfLectures)
                .ToListAsync();

            if (lectures == null)
            {
                throw new ArgumentNullException(nameof(lectures), "Cant finde any lecture by requested parameters.");
            }

            return this._mapper.Map<IEnumerable<TPreviewType>>(lectures);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TPreviewType"></typeparam>
        /// <param name="numberOfSeminars"></param>
        /// <param name="lcid"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IGrouping<int, TPreviewType>>> GetSeminarPreviewsAsync<TPreviewType>(int numberOfSeminars, int lcid) where TPreviewType : SeminarPreview
        {
            if (numberOfSeminars <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfSeminars), "Number of seminars cant be equal or less than zero.");
            }

            if (lcid <= 0)
            {
                throw new ArgumentException("Language id cant be equal or less than zero.", nameof(lcid));
            }

            // Taking list of seminars.
            var seminars = await this._repository.Seminars
                .Where(s => s.Language.LanguageCode == lcid)
                .Take(numberOfSeminars)
                .ToListAsync();

            // Mapping and grouping seminars.
            var mappedAndGroupedSeminars = seminars
                .AsQueryable()
                .ProjectTo<SeminarPreview>(this._mapper.ConfigurationProvider)
                .GroupBy<SeminarPreview, int>(k => k.EventDate.Year);

            if (mappedAndGroupedSeminars == null)
            {
                throw new ArgumentNullException(nameof(seminars), "Cant finde any seminar by requested parameters.");
            }

            return (IEnumerable<IGrouping<int, TPreviewType>>)mappedAndGroupedSeminars;
        }
    }
}
