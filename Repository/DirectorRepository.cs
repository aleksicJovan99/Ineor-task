using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository;
public class DirectorRepository : RepositoryBase<Director>, IDirectorRepository
{
    public DirectorRepository(RepositoryContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Director>> GetDirectorsAsync() => 
        await FindAll()
        .OrderBy(d => d.Id)
        .ToListAsync();

    public async Task<Director> GetDirectorAsync(int directorId) =>
        await FindByCondition(d => d.Id.Equals(directorId))
        .SingleOrDefaultAsync();

    public void CreateDirector(Director director) => Create(director);

    public void DeleteDirector(Director director)
    {
        Delete(director);
    }


    
    
}
