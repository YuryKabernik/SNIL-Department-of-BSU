using AutoMapper;
using SnilAcademicDepartment.DataAccess;
using System.Linq;

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

            this.CreateMap<EducationBlock, Models.KeyAreaBlock>()
                .ForMember(des => des.Title, opt => opt.MapFrom(s => s.Name))
                .ForMember(des => des.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(des => des.Image, opt => opt.MapFrom(s => s.Image1.Image1))
                .ForMember(des => des.Topics, opt => opt.MapFrom(s => s.EducationTopics.Select(p=>p.TopicName)));

            this.CreateMap<HallOfFame, Models.Leader>()
                .ForMember(des => des.Image, opt => opt.MapFrom(s => s.Person.Image.Image1))
                .ForMember(des => des.FullName, opt => opt.MapFrom(s => s.Person.SecoundName + s.Person.PersonName + s.Person.FathersName));
        }
    }
}
