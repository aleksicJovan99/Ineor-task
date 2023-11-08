using Entities;

namespace Contracts;
public interface IDirectorRepository
{
    IEnumerable<Director> GetDirectors();
    Director GetDirector(int directorId);
    void CreateDirector(Director director);
}
