using AmazonPrimeClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonPrimeClone.Infrastructure.Data.Configurations;
public class VideoReviewConfiguration : IEntityTypeConfiguration<VideoReview>
{
    public void Configure(EntityTypeBuilder<VideoReview> builder)
    {
        builder.Property(x => x.Id)
            .IsRequired()
            .HasDefaultValueSql("NEWID()");

        builder.HasOne(x => x.User)
            .WithMany(x => x.Reviews)
            .HasForeignKey(fk => fk.UserId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.VideoContent)
            .WithMany(x => x.Reviews)
            .HasForeignKey(fk => fk.VideoContentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
