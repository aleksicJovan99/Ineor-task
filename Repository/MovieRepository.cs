using Contracts;
using Entities;

namespace Repository;
public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
{
    public MovieRepository(RepositoryContext context) : base(context)
    {
    }

    public IEnumerable<Movie> GetMovies() => FindAll().OrderBy(m => m.Name).ToList();
        
    
}
