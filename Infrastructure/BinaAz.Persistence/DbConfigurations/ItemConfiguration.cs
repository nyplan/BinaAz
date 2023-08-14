using BinaAz.Domain.Entities.TPH.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BinaAz.Persistence.DbConfigurations;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.HasIndex(x => x.ItemNumber).IsUnique();
        builder.Property(x => x.Area).IsRequired();
        builder.Property(x => x.AdditionalInformation).HasMaxLength(500);
        builder.Property(x => x.Address).HasMaxLength(120);
        builder.Property(x => x.ImageUrls).IsRequired();
        builder.Property(x => x.RelevantPerson).HasMaxLength(40).IsRequired();
        builder.Property(x => x.IsAgent).IsRequired();
        builder.Property(x => x.Email).HasMaxLength(150);
        builder.Property(x => x.Phone).HasMaxLength(13);
        builder.Property(x => x.Status).IsRequired();
    }
}