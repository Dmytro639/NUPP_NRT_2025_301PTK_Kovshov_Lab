using Microsoft.EntityFrameworkCore;
using Plants.Infrastructure.Models;


namespace Plants.Infrastructure.Data;


public class PlantsContext : DbContext
{
public PlantsContext(DbContextOptions<PlantsContext> options) : base(options) { }


public DbSet<Plant> Plants => Set<Plant>();
public DbSet<PlantDetail> Details => Set<PlantDetail>();
public DbSet<Watering> Waterings => Set<Watering>();
public DbSet<Tag> Tags => Set<Tag>();
public DbSet<PlantTag> PlantTags => Set<PlantTag>();


protected override void OnModelCreating(ModelBuilder modelBuilder)
{
modelBuilder.Entity<PlantTag>()
.HasKey(pt => new { pt.PlantId, pt.TagId });


modelBuilder.Entity<PlantTag>()
.HasOne(pt => pt.Plant)
.WithMany(p => p.PlantTags)
.HasForeignKey(pt => pt.PlantId);


modelBuilder.Entity<PlantTag>()
.HasOne(pt => pt.Tag)
.WithMany(t => t.PlantTags)
.HasForeignKey(pt => pt.TagId);
}
}
