using Entities;

namespace Contracts;
public interface IMovieService
{
    Task<IEnumerable<MovieDto>> GetMovies();
    Task<IEnumerable<MovieDto>> GetMoviesPaging(MovieParameters movieParameters);
    Task<MovieDto> GetMovie(int id);
    Task<MovieDto> CreateMovie(MovieForCreationDto movie);
    Task<IEnumerable<MovieDto>> CreateMovieCollection(
        IEnumerable<MovieForCreationDto> movieCollection);
    Task DeleteMovie(int id);
    Task UpdateMovie(int id, MovieForUpdateDto movie);

}
