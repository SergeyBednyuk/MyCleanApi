using Microsoft.EntityFrameworkCore;
using MyCleanApi.Core;

namespace MyCleanApi.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseSqlServer(
    //         "Server=LAPTOP-RM76L8L8;Database=my-clean-api;TrustServerCertificate=True;Trusted_Connection=True;MultipleActiveResultSets=true");
    // }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     base.OnModelCreating(modelBuilder);
    //
    //     modelBuilder.Entity<Product>().HasData(
    //         new Product() { Id = 1, ProductName = "Tomato", Price = 4.99 },
    //         new Product() { Id = 2, ProductName = "Onion", Price = 5.99 },
    //         new Product() { Id = 3, ProductName = "Rice", Price = 6.99 },
    //         new Product() { Id = 4, ProductName = "Cucumber", Price = 7.99 },
    //         new Product() { Id = 5, ProductName = "Cheese", Price = 20 }
    //     );
    // }
}