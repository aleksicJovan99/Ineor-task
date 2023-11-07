using Contracts;
using Entities;

namespace Repository;
public class DirectorRepository : RepositoryBase<Director>, IDirectorRepository
{
    public DirectorRepository(RepositoryContext context) : base(context)
    {
    }
}
