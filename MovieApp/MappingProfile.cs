using AutoMapper;
using Entities;

namespace MovieApp;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Movie, MovieDto>();
        CreateMap<Director, MovieDto>();
        CreateMap<MovieForCreationDto, Movie>();
        CreateMap<DirectorForCreationDto, Director>();
    }

}
