using AutoMapper;
using LinksoftStudy.Common.Models;

namespace LinksoftStudy.Web.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Data.Models.UserEntity, Data.Models.UserModel>().ReverseMap();
            CreateMap<Data.Models.UserModel, Services.Models.User>().ReverseMap();
            CreateMap<Services.Models.User, Web.Models.User>().ReverseMap();

            CreateMap<Services.Models.User, ContactModel>()
                .ForMember(from => from.ContactPrimary, mce => mce.MapFrom(to => to.UserId))
                .ForMember(from => from.ContactSecondary, mce => mce.MapFrom(to => to.ContactId));

            CreateMap<ContactModel, Services.Models.User>()
                .ForMember(from => from.UserId, mce => mce.MapFrom(to => to.ContactPrimary))
                .ForMember(from => from.ContactId, mce => mce.MapFrom(to => to.ContactSecondary));
        }
    }
}
