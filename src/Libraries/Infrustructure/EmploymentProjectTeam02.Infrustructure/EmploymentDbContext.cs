using Microsoft.EntityFrameworkCore;

namespace EmploymentProjectTeam02.Infrustructure;

public class EmploymentDbContext : DbContext
{
    public EmploymentDbContext(DbContextOptions<EmploymentDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmploymentDbContext).Assembly);
    }

}
