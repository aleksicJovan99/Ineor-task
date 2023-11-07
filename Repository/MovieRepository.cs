using Contracts;
using Entities;

namespace Repository;
public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
{
    public MovieRepository(RepositoryContext context) : base(context)
    {
    }
}
