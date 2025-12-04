using Plants.REST.Models;
using Microsoft.EntityFrameworkCore;


namespace Plants.REST.Data
{
public class ApplicationDbContext : DbContext
{
public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


public DbSet<Plant> Plants { get; set; }
public DbSet<Author> Authors { get; set; }


protected override void OnModelCreating(ModelBuilder modelBuilder)
{
base.OnModelCreating(modelBuilder);
// конфігурації, якщо потрібно
}
}
}
