using EFLab.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFLab;

public class LabDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=NEPTUN;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
            .LogTo(Console.WriteLine, LogLevel.Information);
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>()
            .Property(c => c.Name)
            .HasMaxLength(15);

        modelBuilder.Entity<Category>().HasData(
            new Category() { Name = "Ital", Id = 1 }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product() { Name = "Sör", Id = 1, UnitPrice = 50, CategoryId = 1 },
            new Product() { Name = "Bor", Id = 2, UnitPrice = 550, CategoryId = 1 },
            new Product() { Name = "Tej", Id = 3, UnitPrice = 260, CategoryId = 1 }
        );
    }
}
