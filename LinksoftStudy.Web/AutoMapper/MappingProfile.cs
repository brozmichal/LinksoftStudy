using AutoMapper;
using LinksoftStudy.Common.Models;

namespace LinksoftStudy.Web.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Data.Models.PersonEntity, Data.Models.PersonModel>().ReverseMap();
            CreateMap<Data.Models.PersonModel, Services.Models.Person>().ReverseMap();
            CreateMap<Services.Models.Person, Web.Models.Person>().ReverseMap();

            CreateMap<Services.Models.Person, ContactModel>()
                .ForMember(from => from.ContactPrimary, mce => mce.MapFrom(to => to.PersonId))
                .ForMember(from => from.ContactSecondary, mce => mce.MapFrom(to => to.ContactId));

            CreateMap<ContactModel, Services.Models.Person>()
                .ForMember(from => from.PersonId, mce => mce.MapFrom(to => to.ContactPrimary))
                .ForMember(from => from.ContactId, mce => mce.MapFrom(to => to.ContactSecondary));
        }
    }
}
