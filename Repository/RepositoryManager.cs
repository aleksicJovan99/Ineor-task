using Contracts;
using Entities;

namespace Repository;
public class RepositoryManager : IRepositoryManager
{
    private RepositoryContext _context;
    private IMovieRepository _movieRepository;
    private IDirectorRepository _directorRepository;

    public RepositoryManager(RepositoryContext context)
    {
        _context = context;
    }

    public IMovieRepository Movie 
    {
        get
        {
            if(_movieRepository == null)
                _movieRepository = new MovieRepository(_context);

            return _movieRepository;
        }
    }

    public IDirectorRepository Director 
    {
        get
        {
            if(_directorRepository == null)
                _directorRepository = new DirectorRepository(_context);

            return _directorRepository;
        }
    }

    public Task SaveAsync() => _context.SaveChangesAsync();
}
