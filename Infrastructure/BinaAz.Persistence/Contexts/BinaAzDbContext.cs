using BinaAz.Domain.Entities;
using BinaAz.Domain.Entities.Common;
using BinaAz.Domain.Entities.TPH;
using BinaAz.Domain.Entities.TPH.Base;
using BinaAz.Persistence.DataSeeds;
using BinaAz.Persistence.DbConfigurations;
using Microsoft.EntityFrameworkCore;
using Object = BinaAz.Domain.Entities.TPH.Object;

namespace BinaAz.Persistence.Contexts;

public class BinaAzDbContext : DbContext
{
    public BinaAzDbContext(DbContextOptions options) : base(options) {}

    public DbSet<City> Cities { get; set; } = null!;
    public DbSet<District> Districts { get; set; } = null!;
    public DbSet<Settlement> Settlements { get; set; } = null!;
    // public DbSet<Image> Images { get; set; } = null!;
    // public DbSet<ItemImage> ItemImages { get; set; } = null!;
    // public DbSet<ProfilePhoto> ProfilePhotos { get; set; } = null!;
    public DbSet<Item> Items { get; set; } = null!;
    public DbSet<Garage> Garages { get; set; } = null!;
    public DbSet<GardenHouse> GardenHouses { get; set; } = null!;
    public DbSet<Ground> Grounds { get; set; } = null!;
    public DbSet<NewBuilding> NewBuildings { get; set; } = null!;
    public DbSet<Object> Objects { get; set; } = null!;
    public DbSet<Office> Offices { get; set; } = null!;
    public DbSet<OldBuilding> OldBuildings { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Agency> Agencies { get; set; } = null!;
    
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.SeedToCity();
        modelBuilder.SeedToDistrict();
        modelBuilder.SeedToSettlement();

        modelBuilder.ApplyConfiguration(new ItemConfiguration());
    }


    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.State == EntityState.Deleted)
            {
                entry.State = EntityState.Modified;
                entry.Entity.DeletedAt = DateTime.UtcNow;
            }
            else
            {
                _ = entry.State switch
                {
                    EntityState.Added => entry.Entity.CreatedAt = DateTime.UtcNow,
                    EntityState.Modified => entry.Entity.UpdatedAt = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }
        }
        return await base.SaveChangesAsync(cancellationToken);
    }
}