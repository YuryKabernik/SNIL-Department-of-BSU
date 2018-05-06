using AutoMapper;
using SnilAcademicDepartment.DataAccess;

namespace SnilAcademicDepartment.BusinessLogic
{
    class BLLMappingConfig : Profile
    {
        public BLLMappingConfig()
        {
            this.CreateMap<PreView, Models.PreView>()
                .ForMember(des => des.Title, opt => opt.MapFrom(s => s.Header))
                .ForMember(des => des.Description, opt => opt.MapFrom(s => s.ShortDescription))
                .ForMember(des => des.Image, opt => opt.MapFrom(s => s.Image));
        }
    }
}
