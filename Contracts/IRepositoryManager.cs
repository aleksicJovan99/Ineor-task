namespace Contracts;
public interface IRepositoryManager
{
    public IMovieRepository Movie { get; }
    public IDirectorRepository Director { get; }
    public void Save();
}
