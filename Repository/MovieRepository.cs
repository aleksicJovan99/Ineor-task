using Contracts;
using Entities;

namespace Repository;
public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
{
    public MovieRepository(RepositoryContext context) : base(context)
    {
    }

    public void CreateMovie(Movie movie) => Create(movie);

    public Movie GetMovie(int movieId) => FindByCondition(m => m.Id.Equals(movieId))
        .SingleOrDefault();

    public IEnumerable<Movie> GetMovies() => FindAll().OrderBy(m => m.Name).ToList();
        
    
}
