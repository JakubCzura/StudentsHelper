using Advice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Advice.Infrastructure.Persistence.DatabaseContext;

internal class AdviceDbContext(DbContextOptions<AdviceDbContext> dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<QuickTip> QuickTips { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}