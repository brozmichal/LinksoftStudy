using AutoMapper;

namespace LinksoftStudy.Web.AutoMapper
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            var mapperConfig = new MapperConfiguration(mapConfig =>
            {
                mapConfig.AddProfile(new MappingProfile());
            });

            return mapperConfig.CreateMapper();
        }
    }
}
