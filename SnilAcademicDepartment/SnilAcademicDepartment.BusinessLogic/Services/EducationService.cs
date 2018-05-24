using NLog;
using System;
using AutoMapper;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.DataAccess;
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

        /// <summary>
        /// Get education block by it's name.
        /// </summary>
        /// <param name="pages">Name of the education block.</param>
        /// <param name="LCID">Languahe code.</param>
        /// <returns>Education block as requested.</returns>
        public EducationBlockModel GetEducationBlock(string blockName, int LCID)
        {
            if (string.IsNullOrEmpty(blockName) || string.IsNullOrWhiteSpace(blockName))
            {
                throw new ArgumentException($"Parameter {nameof(blockName)} is null, empty or white space.",
                    nameof(blockName));
            }
            else if (LCID <= 0)
            {
                throw new IndexOutOfRangeException($"Argument {nameof(LCID)} is equal or less than zero.");
            }

            var block = this._repository.EducationBlocks.FirstOrDefault(s =>
                s.Name == blockName && s.Language.LanguageCode == LCID);

            if (block == null)
            {
                throw new ArgumentNullException(nameof(block),
                    $"Sorry, but there is no EducationBlock you are looking for (Name : {blockName}).");
            }

            return this._mapper.Map<EducationBlockModel>(block);
        }

        public EducationBlockModel GetEducationBlockById(int educationBlockId, int LCID)
        {
            if (educationBlockId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(educationBlockId), "Id cant be equal or less than zero.");
            }

            if (LCID <= 0)
            {
                throw new ArgumentException("Language id cant be equal or less than zero.", nameof(LCID));
            }

            var res = this._repository.EducationBlocks.FirstOrDefault(s =>
                s.BlockId == educationBlockId && s.Language.LanguageCode == LCID);

            if (res == null)
            {
                throw new ArgumentNullException("There is no Education block with such ID and LCID.");
            }

            return this._mapper.Map<EducationBlockModel>(res);
        }
    }
}
