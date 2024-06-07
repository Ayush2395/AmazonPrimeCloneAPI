using AmazonPrimeClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonPrimeClone.Infrastructure.Data.Configurations;
public class VideoThumbnailConfiguration : IEntityTypeConfiguration<VideoThumbnail>
{
    public void Configure(EntityTypeBuilder<VideoThumbnail> builder)
    {
        builder.Property(x => x.Id)
            .IsRequired()
            .HasDefaultValueSql("NEWID()");

        builder.HasOne(x => x.VideoContent)
            .WithMany(x => x.Thumbnails)
            .HasForeignKey(x => x.VideoContentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
