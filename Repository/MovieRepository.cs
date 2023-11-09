using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository;
public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
{
    public MovieRepository(RepositoryContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Movie>> GetMoviesAsync() => 
        await FindAll().OrderBy(m => m.Id)
        .ToListAsync();

    public async Task<Movie> GetMovieAsync(int movieId) => 
        await FindByCondition(m => m.Id.Equals(movieId))
        .SingleOrDefaultAsync();


    public void CreateMovie(Movie movie) => Create(movie);

    public void DeleteMovie(Movie movie)
    {
       Delete(movie);
    }

    public async Task<IEnumerable<Movie>> GetMoviesPagingAsync(MovieParameters movieParameters) =>
        await FindAll()
        .OrderBy(m => m.Id)
        .Skip((movieParameters.PageNumber - 1) * movieParameters.PageSize)
        .Take(movieParameters.PageSize)
        .ToListAsync();
}
