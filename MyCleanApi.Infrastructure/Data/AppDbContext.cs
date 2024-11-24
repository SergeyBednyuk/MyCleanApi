using Microsoft.EntityFrameworkCore;
using MyCleanApi.Core;

namespace MyCleanApi.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=LAPTOP-RM76L8L8;Database=my-clean-api;TrustServerCertificate=True;Trusted_Connection=True;MultipleActiveResultSets=true");
    }
}