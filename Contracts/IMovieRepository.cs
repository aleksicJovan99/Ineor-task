using Entities;

namespace Contracts;
public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetMoviesAsync();
    Task<Movie> GetMovieAsync(int movieId);
    Task<IEnumerable<Movie>> GetMoviesPagingAsync(MovieParameters movieParameters);
    void CreateMovie(Movie movie);
    void DeleteMovie(Movie movie);
}
