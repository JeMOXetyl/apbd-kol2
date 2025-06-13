using KolE.Models;
using Microsoft.EntityFrameworkCore;

namespace KolE.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Nursery> Nurseries { get; set; }
    public DbSet<TreeSpecies> TreeSpecies { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<SeedlingBatch> SeedlingBatches { get; set; }
    public DbSet<Responsible> Responsibles { get; set; }
    
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}