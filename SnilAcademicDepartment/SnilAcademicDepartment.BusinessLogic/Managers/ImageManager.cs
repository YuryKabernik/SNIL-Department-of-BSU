using System;
using System.Data.Entity;
using System.IO;
using AutoMapper;
using System.Threading.Tasks;
using SnilAcademicDepartment.BusinessLogic.DTOModels;
using SnilAcademicDepartment.DataAccess;

namespace SnilAcademicDepartment.BusinessLogic.Managers
{
    public class ImageManager
    {
        private readonly SnilDBContext _snilDbContext;
        private readonly IMapper _mapper;

        public ImageManager(SnilDBContext snilDbContext, IMapper mapper)
        {
            this._snilDbContext = snilDbContext;
            this._mapper = mapper;
        }

        public async Task<ImageModel> GetImageAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id cant be equal or less than zero.");
            }

            var image = await _snilDbContext.Images.FirstAsync(p => p.ImageId == id);

            if (image == null)
            {
                throw new FileNotFoundException($"Cant finde file with id : {id}.");
            }

            return this._mapper.Map<ImageModel>(image);
        }
    }
}
