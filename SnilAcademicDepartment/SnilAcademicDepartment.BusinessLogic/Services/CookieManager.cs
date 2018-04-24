using NLog;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.DataAccess.Interface;
using System;
using System.Web;

namespace SnilAcademicDepartment.BusinessLogic.Services
{
    class CookieManager : ICookieManager
    {
        private readonly ILogger _logger;
        private readonly IRepository _repository;

        public CookieManager(ILogger logger, IRepository repository)
        {
            this._logger = logger;
            this._repository = repository;
        }
        
        public HttpCookie ChangeCulture(string language)
        {
            throw new NotImplementedException();
        }
    }
}
