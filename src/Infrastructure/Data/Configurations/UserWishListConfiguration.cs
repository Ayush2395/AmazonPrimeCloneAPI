using AmazonPrimeClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonPrimeClone.Infrastructure.Data.Configurations;
public class UserWishListConfiguration : IEntityTypeConfiguration<UserWishList>
{
    public void Configure(EntityTypeBuilder<UserWishList> builder)
    {
        builder.Property(x => x.Id).IsRequired().HasDefaultValueSql("NEWID()");

        builder.HasOne(x => x.User)
            .WithMany(x => x.WishLists)
            .HasForeignKey(fk => fk.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.VideoContent)
            .WithMany(x => x.WishLists)
            .HasForeignKey(fk => fk.VideoContentId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
