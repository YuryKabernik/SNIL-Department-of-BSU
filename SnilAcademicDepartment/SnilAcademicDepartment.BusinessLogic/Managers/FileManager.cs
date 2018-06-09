using System;
using AutoMapper;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
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

        public DocumentModel GetFileById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Incorrect file id.");
            }

            var file = this._dbContext.Documents.FirstOrDefault(s => s.DocumentId == id);

            if (file == null)
            {
                throw new ArgumentNullException(nameof(file), "There is no file with this id and lcid code.");
            }

            return this._mapper.Map<DocumentModel>(file);
        }

        public async Task<DocumentModel> GetFileByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Incorrect file id.");
            }

            var file = await this._dbContext.Documents.FirstOrDefaultAsync(s => s.DocumentId == id);

            if (file == null)
            {
                throw new ArgumentNullException(nameof(file), "There is no file with this id and lcid code.");
            }

            return this._mapper.Map<DocumentModel>(file);
        }

        public DocumentModel GetFileByName(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("File name cant be null or white space.", nameof(name));
            }

            var file = this._dbContext.Documents.FirstOrDefault(s =>
                s.DocumentName.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (file == null)
            {
                throw new ArgumentNullException(nameof(file), "There is no file with this name and lcid code.");
            }

            return this._mapper.Map<DocumentModel>(file);
        }

        public async Task<DocumentModel> GetFileByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("File name cant be null or white space.", nameof(name));
            }

            var file = await this._dbContext.Documents.FirstOrDefaultAsync(s =>
                s.DocumentName.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (file == null)
            {
                throw new ArgumentNullException(nameof(file), "There is no file with this name and lcid code.");
            }

            return this._mapper.Map<DocumentModel>(file);
        }
    }
}
