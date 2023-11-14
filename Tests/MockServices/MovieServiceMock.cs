using Contracts;
using Entities;

namespace Tests;
public class MovieServiceMock : IMovieService
{
    private readonly IEnumerable<MovieDto> _movies;
    public MovieServiceMock()
    {
        _movies = new List<MovieDto> 
        {
            new MovieDto 
            {
                Id=1, 
                Name="Movie1", 
                Rating=10, 
                ReleaseDate=DateTime.Now, 
                DirectorName="Director1"
            },
            new MovieDto 
            {
                Id=2, 
                Name="Movie2", 
                Rating=8, 
                ReleaseDate=DateTime.Now, 
                DirectorName="Director2"
            },
            new MovieDto 
            {
                Id=3, 
                Name="Movie3", 
                Rating=7, 
                ReleaseDate=DateTime.Now, 
                DirectorName="Director3"
            },

        };
    }

    public Task<MovieDto> CreateMovie(MovieForCreationDto movie)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<MovieDto>> CreateMovieCollection(IEnumerable<MovieForCreationDto> movieCollection)
    {
        throw new NotImplementedException();
    }

    public Task DeleteMovie(int id)
    {
        throw new NotImplementedException();
    }

    public Task<MovieDto> GetMovie(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<MovieDto>> GetMovies()
    {
        return Task.FromResult<IEnumerable<MovieDto>>(_movies);
    }

    public Task<IEnumerable<MovieDto>> GetMoviesPaging(MovieParameters movieParameters)
    {
        throw new NotImplementedException();
    }

    public Task UpdateMovie(int id, MovieForUpdateDto movie)
    {
        throw new NotImplementedException();
    }
}
