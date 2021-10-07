using AutoMapper;
using Fc.Entities.Domain;
using Fc.Entities.Dto;

namespace Fc.DomainServices.Implementations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>();
        }

        public static IMapper Initialize()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperConfig());
            });

            return mapperConfig.CreateMapper();
        }
    }
}