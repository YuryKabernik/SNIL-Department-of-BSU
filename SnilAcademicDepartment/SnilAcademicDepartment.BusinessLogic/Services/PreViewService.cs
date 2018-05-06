using NLog;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.DataAccess;
using System;
using System.Linq;
using System.Collections.Generic;

namespace SnilAcademicDepartment.BusinessLogic.Services
{
    public sealed class PreViewService : IService
    {
        private readonly ILogger _logger;
        private readonly SnilDBContext _repository;

        public PreViewService(ILogger logger, SnilDBContext repository)
        {
            this._logger = logger;
            this._repository = repository;
        }

        /// <summary>
        /// Method of getting firs or default preview of the page type.
        /// </summary>
        /// <param name="pageType">Type of the page.</param>
        /// <returns>Single page preview.</returns>
        public Models.PreView GetPagePreview(string pageType)
        {
            if (string.IsNullOrEmpty(pageType) || string.IsNullOrWhiteSpace(pageType))
            {
                throw new ArgumentNullException(nameof(pageType), "Your argument is Null, Empty or WhiteSpace");
            }

            var request = this._repository.PreViews.FirstOrDefault(e => e.PageTypeName.PageTypeName == pageType);

            if (request == null)
            {
                throw new InvalidOperationException("Cant't find page preview");
            }

            throw new NotImplementedException();
        }

        public IEnumerable<Models.PreView> GetPagePreviews(string pageType)
        {
            throw new NotImplementedException();
        }
    }
}
