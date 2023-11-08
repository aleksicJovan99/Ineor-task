using AutoMapper;
using Entities;

namespace MovieApp;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Movie, MovieDto>();
    }

}
