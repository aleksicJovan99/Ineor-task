using Contracts;
using Entities;

namespace Repository;
public class DirectorRepository : RepositoryBase<Director>, IDirectorRepository
{
    public DirectorRepository(RepositoryContext context) : base(context)
    {
    }

    public void CreateDirector(Director director) => Create(director);

    public void DeleteDirector(Director director)
    {
        Delete(director);
    }

    public Director GetDirector(int directorId) =>
        FindByCondition(d => d.Id.Equals(directorId))
        .SingleOrDefault();

    public IEnumerable<Director> GetDirectors() => FindAll().OrderBy(d => d.Name);
    
    
}
