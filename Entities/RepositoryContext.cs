using Microsoft.EntityFrameworkCore;

namespace Entities;
public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Director> Directors { get; set; }
    
}
