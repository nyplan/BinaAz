using BinaAz.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BinaAz.Persistence;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BinaAzDbContext>
{
    public BinaAzDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<BinaAzDbContext> dbContextOptionsBuilder = new();
        dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
        return new(dbContextOptionsBuilder.Options);
    }
}