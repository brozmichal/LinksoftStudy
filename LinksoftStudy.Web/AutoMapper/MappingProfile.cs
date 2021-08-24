using AutoMapper;
using LinksoftStudy.Data.Models;

namespace LinksoftStudy.Web.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Data.Models.PersonEntity, Data.Models.PersonModel>().ReverseMap();
            CreateMap<Data.Models.PersonModel, Services.Models.Person>().ReverseMap();
            CreateMap<Services.Models.Person, Web.Models.Person>().ReverseMap();
        }
    }
}
