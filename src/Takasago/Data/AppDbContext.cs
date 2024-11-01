using Microsoft.EntityFrameworkCore;
using Takasago.Domain;

namespace Takasago.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options, CurrentUser user) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        modelBuilder.Entity<UserPreference>()
            .HasQueryFilter(x => x.UserId == user.Id);
    }
}