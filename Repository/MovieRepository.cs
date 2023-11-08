using Contracts;
using Entities;

namespace Repository;
public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
{
    public MovieRepository(RepositoryContext context) : base(context)
    {
    }

    public Movie GetMovie(int movieId) => FindByCondition(m => m.Id.Equals(movieId))
        .SingleOrDefault();

    public IEnumerable<Movie> GetMovies() => FindAll().OrderBy(m => m.Name).ToList();
        
    
}
