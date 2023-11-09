using Entities;

namespace Contracts;
public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetMoviesAsync();
    Task<Movie> GetMovieAsync(int movieId);
    void CreateMovie(Movie movie);
    void DeleteMovie(Movie movie);
}
