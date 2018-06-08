using NLog;
using System;
using AutoMapper;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.DataAccess;
using SnilAcademicDepartment.BusinessLogic.DTOModels;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SnilAcademicDepartment.BusinessLogic.Services
{
    public class EducationService : IEducation, ILection
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
        /// <param name="lcid">Languahe code</param>
        /// <returns>Collection of education key areas.</returns>
        /// <exception cref="IndexOutOfRangeException">Throws when argument 'pages' or 'lcid' is equal or less than zero.</exception>
        /// <exception cref="ArgumentNullException">Throws when result from database is null.</exception>
        public List<EducationBlockModel> GetKeyAreas(int pages, int lcid)
        {
            if (pages <= 0)
            {
                throw new IndexOutOfRangeException($"Argument {nameof(pages)} is equal or less than zero.");
            }
            else if (lcid <= 0)
            {
                throw new IndexOutOfRangeException($"Argument {nameof(lcid)} is equal or less than zero.");
            }

            var resultCollection = this._repository.EducationBlocks
                .Where(s => s.Language.LanguageCode == CultureInfo.CurrentCulture.LCID)
                .Take(pages).ToList();

            if (resultCollection == null)
            {
                throw new ArgumentNullException(nameof(resultCollection), "Sorry, but there is no EducationBlocks you are looking for.");
            }

            return this._mapper.Map<List<EducationBlockModel>>(resultCollection);
        }

        /// <summary>
        /// Get education block by it's name.
        /// </summary>
        /// <param name="blockName">Name of the education block.</param>
        /// <param name="lcid">Languahe code.</param>
        /// <returns>Education block as requested.</returns>
        /// <exception cref="IndexOutOfRangeException">Throws when argument lcid is equal or less than zero.</exception>
        /// <exception cref="ArgumentNullException">Throws when blockName is null, empty or whitespace. Throws when result from database is null.</exception>
        public EducationBlockModel GetEducationBlock(string blockName, int lcid)
        {
            if (string.IsNullOrWhiteSpace(blockName))
            {
                throw new ArgumentException($"Parameter {nameof(blockName)} is null, empty or white space.",
                    nameof(blockName));
            }
            else if (lcid <= 0)
            {
                throw new IndexOutOfRangeException($"Argument {nameof(lcid)} is equal or less than zero.");
            }

            var block = this._repository.EducationBlocks.FirstOrDefault(s =>
                s.Name == blockName && s.Language.LanguageCode == lcid);

            if (block == null)
            {
                throw new ArgumentNullException(nameof(block),
                    $"Sorry, but there is no EducationBlock you are looking for (Name : {blockName}).");
            }

            return this._mapper.Map<EducationBlockModel>(block);
        }

        /// <summary>
        /// Method to get education block by common multi language Id.
        /// </summary>
        /// <param name="commonBlockTypeId">Id of a multi language project id.</param>
        /// <param name="lcid">Language LCID code.</param>
        /// <returns>Education block by common Id.</returns>
        public EducationBlockModel GetEducationBlockById(int commonBlockTypeId, int lcid)
        {
            if (commonBlockTypeId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(commonBlockTypeId), "Id cant be equal or less than zero.");
            }

            if (lcid <= 0)
            {
                throw new ArgumentException("Language id cant be equal or less than zero.", nameof(lcid));
            }

            var res = this._repository.EducationBlocks.FirstOrDefault(s =>
                s.CommonBlockTypeId == commonBlockTypeId && s.Language.LanguageCode == lcid);

            if (res == null)
            {
                throw new ArgumentNullException("There is no Education block with such ID and LCID.");
            }

            return this._mapper.Map<EducationBlockModel>(res);
        }

        /// <summary>
        /// Get education areas async.
        /// </summary>
        /// <param name="pages">Number of pages to take.</param>
        /// <param name="lcid">Language LCID code.</param>
        /// <returns>List of education blocks.</returns>
        /// <exception cref="IndexOutOfRangeException">Throws when argument 'pages' or 'lcid' is equal or less than zero.</exception>
        /// <exception cref="ArgumentNullException">Throws when result from database is null.</exception>
        public async Task<List<EducationBlockModel>> GetKeyAreasAsync(int pages, int lcid)
        {
            if (pages <= 0)
            {
                throw new IndexOutOfRangeException($"Argument {nameof(pages)} is equal or less than zero.");
            }
            else if (lcid <= 0)
            {
                throw new IndexOutOfRangeException($"Argument {nameof(lcid)} is equal or less than zero.");
            }

            var resultCollection = await this._repository.EducationBlocks
                .Where(s => s.Language.LanguageCode == CultureInfo.CurrentCulture.LCID)
                .Take(pages).ToListAsync();

            if (resultCollection == null)
            {
                throw new ArgumentNullException(nameof(resultCollection), "Sorry, but there is no EducationBlocks you are looking for.");
            }

            return this._mapper.Map<List<EducationBlockModel>>(resultCollection);
        }
    }
}
