using AmazonPrimeClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonPrimeClone.Infrastructure.Data.Configurations;
public class ReportedVideoConfiguration : IEntityTypeConfiguration<ReportedVideo>
{
    public void Configure(EntityTypeBuilder<ReportedVideo> builder)
    {
        builder.Property(x => x.Id)
            .IsRequired()
            .HasDefaultValueSql("NEWID()");

        builder.HasOne(x => x.User)
            .WithMany(x => x.ReportedVideos)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.VideoContent)
            .WithMany(x => x.ReportedVideos)
            .HasForeignKey(x => x.VideoContentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
