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
        modelBuilder.Entity<Employee>().HasData(new List<Employee>
        {
            new Employee()
                { EmployeeId = 1, FirstName = "Anna", LastName = "Kowalska", HireDate = DateTime.Now.AddYears(-20) },
            new Employee()
                { EmployeeId = 1, FirstName = "Jan", LastName = "Nowak", HireDate = DateTime.Now.AddYears(-20) }
        });

        modelBuilder.Entity<Nursery>().HasData(new Nursery
        {
            NurseryId = 1,
            Name = "Green Forest Nursery",
            EstablilishedDate = DateTime.Now.AddYears(-20)
        });

        modelBuilder.Entity<TreeSpecies>().HasData(new TreeSpecies
        {
            SpeciesId = 1,
            LatinName = "Quercus robur",
            GrowthTimeInYears = 5
        });
        
        modelBuilder.Entity<SeedlingBatches>().HasData(new SeedlingBatch()
        {
            BatchId = 1,
            NurseryId = 1,
            SpeciesId = 1,
            Quantity = 500,
            SownDate = DateTime.Now.AddYears(-20),
            ReadyDate = DateTime.Now.AddYears(-10)
        });

        modelBuilder.Entity<Responsibles>().HasData(new List<Responsible>
        {
            new Responsible() { 1, 1, "Supervisor" },
            new Responsible() { 1, 2, "Planter" }
        });
}