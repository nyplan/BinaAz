﻿// <auto-generated />
using System;
using System.Collections.Generic;
using BinaAz.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BinaAz.Persistence.Migrations
{
    [DbContext(typeof(BinaAzDbContext))]
    partial class BinaAzDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BinaAz.Domain.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Baki"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sumqayit"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Zaqatala"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Astara"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Yevlax"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Ucar"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Berde"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Cebrayil"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Qazax"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Quba"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Ismayilli"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Siyezen"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Tovuz"
                        });
                });

            modelBuilder.Entity("BinaAz.Domain.Entities.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Districts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            Name = "Yasamal"
                        },
                        new
                        {
                            Id = 2,
                            CityId = 1,
                            Name = "Suraxani"
                        },
                        new
                        {
                            Id = 3,
                            CityId = 1,
                            Name = "Sebail"
                        },
                        new
                        {
                            Id = 4,
                            CityId = 1,
                            Name = "Sabuncu"
                        },
                        new
                        {
                            Id = 5,
                            CityId = 1,
                            Name = "Nizami"
                        },
                        new
                        {
                            Id = 6,
                            CityId = 1,
                            Name = "Nesimi"
                        },
                        new
                        {
                            Id = 7,
                            CityId = 1,
                            Name = "Nerimanov"
                        },
                        new
                        {
                            Id = 8,
                            CityId = 1,
                            Name = "Qaradag"
                        });
                });

            modelBuilder.Entity("BinaAz.Domain.Entities.Settlement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DistrictId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.ToTable("Settlements");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DistrictId = 7,
                            Name = "Boyukshor"
                        },
                        new
                        {
                            Id = 2,
                            DistrictId = 1,
                            Name = "Yasamal"
                        },
                        new
                        {
                            Id = 3,
                            DistrictId = 1,
                            Name = "Yeni Yasamal"
                        },
                        new
                        {
                            Id = 4,
                            DistrictId = 5,
                            Name = "8-ci kilometr"
                        },
                        new
                        {
                            Id = 5,
                            DistrictId = 5,
                            Name = "Keshle"
                        },
                        new
                        {
                            Id = 6,
                            DistrictId = 6,
                            Name = "Kubinka"
                        },
                        new
                        {
                            Id = 7,
                            DistrictId = 6,
                            Name = "1-ci Mikrorayon"
                        },
                        new
                        {
                            Id = 8,
                            DistrictId = 6,
                            Name = "2-ci Mikrorayon"
                        });
                });

            modelBuilder.Entity("BinaAz.Domain.Entities.TPH.Base.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AdditionalInformation")
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Area")
                        .HasColumnType("integer");

                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<int?>("CountOfFloor")
                        .HasColumnType("integer");

                    b.Property<int?>("CountOfRoom")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DayOrMonth")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DistrictId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool?>("Extract")
                        .HasColumnType("boolean");

                    b.Property<int?>("Floor")
                        .HasColumnType("integer");

                    b.Property<List<string>>("ImageUrls")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<bool>("IsAgent")
                        .HasColumnType("boolean");

                    b.Property<bool?>("IsPremium")
                        .HasColumnType("boolean");

                    b.Property<bool?>("IsVip")
                        .HasColumnType("boolean");

                    b.Property<int>("ItemNumber")
                        .HasColumnType("integer");

                    b.Property<bool?>("Mortgage")
                        .HasColumnType("boolean");

                    b.Property<int>("Phone")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("PremiumEnds")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<string>("RelevantPerson")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool?>("Repair")
                        .HasColumnType("boolean");

                    b.Property<int?>("SaleOrRent")
                        .HasColumnType("integer");

                    b.Property<int>("SettlementId")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("VipEnds")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("DistrictId");

                    b.HasIndex("ItemNumber")
                        .IsUnique();

                    b.HasIndex("SettlementId");

                    b.HasIndex("UserId");

                    b.ToTable("Items");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Item");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("BinaAz.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Balance")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text");

                    b.Property<DateTime?>("RefreshTokenExpires")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("BinaAz.Domain.Entities.TPH.Garage", b =>
                {
                    b.HasBaseType("BinaAz.Domain.Entities.TPH.Base.Item");

                    b.HasDiscriminator().HasValue("Garage");
                });

            modelBuilder.Entity("BinaAz.Domain.Entities.TPH.GardenHouse", b =>
                {
                    b.HasBaseType("BinaAz.Domain.Entities.TPH.Base.Item");

                    b.Property<int>("PlotOfLand")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue("GardenHouse");
                });

            modelBuilder.Entity("BinaAz.Domain.Entities.TPH.Ground", b =>
                {
                    b.HasBaseType("BinaAz.Domain.Entities.TPH.Base.Item");

                    b.HasDiscriminator().HasValue("Ground");
                });

            modelBuilder.Entity("BinaAz.Domain.Entities.TPH.NewBuilding", b =>
                {
                    b.HasBaseType("BinaAz.Domain.Entities.TPH.Base.Item");

                    b.HasDiscriminator().HasValue("NewBuilding");
                });

            modelBuilder.Entity("BinaAz.Domain.Entities.TPH.Object", b =>
                {
                    b.HasBaseType("BinaAz.Domain.Entities.TPH.Base.Item");

                    b.HasDiscriminator().HasValue("Object");
                });

            modelBuilder.Entity("BinaAz.Domain.Entities.TPH.Office", b =>
                {
                    b.HasBaseType("BinaAz.Domain.Entities.TPH.Base.Item");

                    b.Property<int?>("TypeOfOffice")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue("Office");
                });

            modelBuilder.Entity("BinaAz.Domain.Entities.TPH.OldBuilding", b =>
                {
                    b.HasBaseType("BinaAz.Domain.Entities.TPH.Base.Item");

                    b.HasDiscriminator().HasValue("OldBuilding");
                });

            modelBuilder.Entity("BinaAz.Domain.Entities.Agency", b =>
                {
                    b.HasBaseType("BinaAz.Domain.Entities.User");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("HandOverYear")
                        .HasColumnType("integer");

                    b.Property<bool>("IsResidentialComplex")
                        .HasColumnType("boolean");

                    b.Property<string>("RelevantPerson")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Agency");
                });

            modelBuilder.Entity("BinaAz.Domain.Entities.District", b =>
                {
                    b.HasOne("BinaAz.Domain.Entities.City", "City")
                        .WithMany("Districts")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("BinaAz.Domain.Entities.Settlement", b =>
                {
                    b.HasOne("BinaAz.Domain.Entities.District", "District")
                        .WithMany("Settlements")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("District");
                });

            modelBuilder.Entity("BinaAz.Domain.Entities.TPH.Base.Item", b =>
                {
                    b.HasOne("BinaAz.Domain.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BinaAz.Domain.Entities.District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BinaAz.Domain.Entities.Settlement", "Settlement")
                        .WithMany()
                        .HasForeignKey("SettlementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BinaAz.Domain.Entities.User", "User")
                        .WithMany("Items")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("District");

                    b.Navigation("Settlement");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BinaAz.Domain.Entities.City", b =>
                {
                    b.Navigation("Districts");
                });

            modelBuilder.Entity("BinaAz.Domain.Entities.District", b =>
                {
                    b.Navigation("Settlements");
                });

            modelBuilder.Entity("BinaAz.Domain.Entities.User", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
