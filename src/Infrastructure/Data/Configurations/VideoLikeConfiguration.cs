using AmazonPrimeClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonPrimeClone.Infrastructure.Data.Configurations;
public class VideoLikeConfiguration : IEntityTypeConfiguration<VideoLike>
{
    public void Configure(EntityTypeBuilder<VideoLike> builder)
    {
        builder.Property(x => x.Id)
            .IsRequired()
            .HasDefaultValueSql("NEWID()");

        builder.HasOne(x => x.User)
            .WithMany(x => x.Likes)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.VideoContent)
            .WithMany(x => x.Likes)
            .HasForeignKey(fk => fk.VideoContentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
