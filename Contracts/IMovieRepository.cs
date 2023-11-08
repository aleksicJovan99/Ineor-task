using Entities;

namespace Contracts;
public interface IMovieRepository
{
    IEnumerable<Movie> GetMovies();
    Movie GetMovie(int movieId);
    void CreateMovie(Movie movie);
}
