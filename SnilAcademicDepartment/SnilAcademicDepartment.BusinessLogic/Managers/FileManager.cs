using System;
using  System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SnilAcademicDepartment.BusinessLogic.DTOModels;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.DataAccess;

namespace SnilAcademicDepartment.BusinessLogic.Managers
{
    public class FileManager : IDataBaseFileManager
    {
        private readonly SnilDBContext _dbContext;
        private readonly IMapper _mapper;

        public FileManager(SnilDBContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        public DocumentModel GetFileById(int id, int lcid)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Incorrect file id.");
            }

            if (lcid <= 0)
            {
                throw new ArgumentException("Bad language code, it must be bigger than zero.",nameof(lcid));
            }

            var file = this._dbContext.Documents.FirstOrDefault(s => s.DocumentId == id);

            if (file == null)
            {
                throw new ArgumentNullException(nameof(file), "There is no file with this id and lcid code.");
            }

            return this._mapper.Map<DocumentModel>(file);
        }

        public DocumentModel GetFileByName(string name, int lcid)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("File name cant be null or white space.", nameof(name));
            }

            if (lcid <= 0)
            {
                throw new ArgumentException("Bad language code, it must be bigger than zero.", nameof(lcid));
            }

            var file = this._dbContext.Documents.FirstOrDefault(s =>
                s.DocumentName.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (file == null)
            {
                throw new ArgumentNullException(nameof(file), "There is no file with this name and lcid code.");
            }

            return this._mapper.Map<DocumentModel>(file);
        }
    }
}
