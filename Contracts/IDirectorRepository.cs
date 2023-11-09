using Entities;

namespace Contracts;
public interface IDirectorRepository
{
    Task<IEnumerable<Director>> GetDirectorsAsync();
    Task<Director> GetDirectorAsync(int directorId);
    void CreateDirector(Director director);
    void DeleteDirector(Director director);
}
