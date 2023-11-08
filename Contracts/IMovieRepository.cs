using Entities;

namespace Contracts;
public interface IMovieRepository
{
    IEnumerable<Movie> GetMovies();
}
