using BinaAz.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BinaAz.Persistence.DbConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasMany(x => x.Liked)
            .WithMany(x => x.LikedUsers);

        builder.Property(x => x.Email).HasMaxLength(150);
        builder.Property(x => x.Phone).HasMaxLength(13);

        builder.Property(x => x.CompanyName).HasMaxLength(50);
        builder.Property(x => x.RelevantPerson).HasMaxLength(50);
        builder.Property(x => x.Address).HasMaxLength(120);
    }
}