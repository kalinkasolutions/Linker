using Linker.BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace Linker.BusinessLogic.Dal;

public class LinkerContext : DbContext
{
    public DbSet<Link> Links => Set<Link>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=/var/data/Linker.db");
        base.OnConfiguring(optionsBuilder);
    }
}