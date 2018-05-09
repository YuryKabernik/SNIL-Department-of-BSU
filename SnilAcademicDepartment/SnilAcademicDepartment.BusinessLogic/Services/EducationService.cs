using NLog;
using System;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.DataAccess;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using AutoMapper;
using SnilAcademicDepartment.BusinessLogic.DTOModels;

namespace SnilAcademicDepartment.BusinessLogic.Services
{
    public class EducationService : IEducation
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly SnilDBContext _repository;

        public EducationService(ILogger logger, SnilDBContext repository, IMapper mapper)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._repository = repository;
        }

        /// <summary>
        /// Search key areas of education blocks.
        /// </summary>
        /// <param name="pages">Number of pages to get.</param>
        /// <param name="LCID">Languahe code</param>
        /// <returns>Collection of education key areas.</returns>
        public List<EducationBlockModel> GetKeyAreas(int pages, int LCID)
        {
            if (pages <= 0)
            {
                throw new IndexOutOfRangeException($"Argument {nameof(pages)} is equal or less than zero.");
            }
            else if (LCID <= 0)
            {
                throw new IndexOutOfRangeException($"Argument {nameof(LCID)} is equal or less than zero.");
            }

            var resultCollection = this._repository.EducationBlocks
                .Where(s => s.Language.LanguageCode == CultureInfo.CurrentCulture.LCID)
                .Take(pages);

            if (resultCollection == null)
            {
                throw new ArgumentNullException(nameof(resultCollection), "Sorry, but there is no EducationBlocks you are looking for.");
            }

            return this._mapper.Map<List<EducationBlockModel>>(resultCollection);
        }
    }
}
