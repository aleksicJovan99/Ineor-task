using AutoMapper;
using Entities;

namespace MovieApp;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Movie, MovieDto>();
        CreateMap<Director, DirectorDto>();
        CreateMap<MovieForCreationDto, Movie>();
        CreateMap<DirectorForCreationDto, Director>();
        CreateMap<MovieForUpdateDto, Movie>();
        CreateMap<DirectorForUpdateDto, Director>();
    }

}
