using BinaAz.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BinaAz.Persistence.DataSeeds;

public static class DataSeed
{
    public static void SeedToCity(this ModelBuilder builder)
    {
        builder.Entity<City>()
            .HasData(
                new City()
                {
                    Id = 1,
                    Name = "Baki"
                },
                new City()
                {
                    Id = 2,
                    Name = "Sumqayit"
                },
                new City()
                {
                    Id = 3,
                    Name = "Zaqatala"
                },
                new City()
                {
                    Id = 4,
                    Name = "Astara"
                },
                new City()
                {
                    Id = 5,
                    Name = "Yevlax"
                },
                new City()
                {
                    Id = 6,
                    Name = "Ucar"
                },
                new City()
                {
                    Id = 7,
                    Name = "Berde"
                },
                new City()
                {
                    Id = 8,
                    Name = "Cebrayil"
                },
                new City()
                {
                    Id = 9,
                    Name = "Qazax"
                },
                new City()
                {
                    Id = 10,
                    Name = "Quba"
                },
                new City()
                {
                    Id = 11,
                    Name = "Ismayilli"
                },
                new City()
                {
                    Id = 12,
                    Name = "Siyezen"
                },
                new City()
                {
                    Id = 13,
                    Name = "Tovuz"
                }
            );
    }

    public static void SeedToDistrict(this ModelBuilder builder)
    {
        builder.Entity<District>()
            .HasData(
                new District()
                {
                    Id = 1,
                    Name = "Yasamal",
                    CityId = 1
                },
                new District()
                {
                    Id = 2,
                    Name = "Suraxani",
                    CityId = 1
                },
                new District()
                {
                    Id = 3,
                    Name = "Sebail",
                    CityId = 1
                },
                new District()
                {
                    Id = 4,
                    Name = "Sabuncu",
                    CityId = 1
                },
                new District()
                {
                    Id = 5,
                    Name = "Nizami",
                    CityId = 1
                },
                new District()
                {
                    Id = 6,
                    Name = "Nesimi",
                    CityId = 1
                },
                new District()
                {
                    Id = 7,
                    Name = "Nerimanov",
                    CityId = 1
                },
                new District()
                {
                    Id = 8,
                    Name = "Qaradag",
                    CityId = 1
                }
            );
    }

    public static void SeedToSettlement(this ModelBuilder builder)
    {
        builder.Entity<Settlement>()
            .HasData(
                new Settlement()
                {
                    Id = 1,
                    Name = "Boyukshor",
                    DistrictId = 7
                },
                new Settlement()
                {
                    Id = 2,
                    Name = "Yasamal",
                    DistrictId = 1
                },
                new Settlement()
                {
                    Id = 3,
                    Name = "Yeni Yasamal",
                    DistrictId = 1
                },
                new Settlement()
                {
                    Id = 4,
                    Name = "8-ci kilometr",
                    DistrictId = 5
                },
                new Settlement()
                {
                    Id = 5,
                    Name = "Keshle",
                    DistrictId = 5
                },
                new Settlement()
                {
                    Id = 6,
                    Name = "Kubinka",
                    DistrictId = 6
                },
                new Settlement()
                {
                    Id = 7,
                    Name = "1-ci Mikrorayon",
                    DistrictId = 6
                },
                new Settlement()
                {
                    Id = 8,
                    Name = "2-ci Mikrorayon",
                    DistrictId = 6
                }
            );
    }
}