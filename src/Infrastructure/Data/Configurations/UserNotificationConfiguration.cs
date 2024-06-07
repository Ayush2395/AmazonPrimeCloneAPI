using AmazonPrimeClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonPrimeClone.Infrastructure.Data.Configurations;
public class UserNotificationConfiguration : IEntityTypeConfiguration<UserNotification>
{
    public void Configure(EntityTypeBuilder<UserNotification> builder)
    {
        builder.Property(x => x.Id)
            .IsRequired().HasDefaultValueSql("NEWID()");

        builder.HasOne(x => x.NotificationSetting)
            .WithMany(x => x.Notifications)
            .HasForeignKey(x => x.NotificationSettingId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.VideoContent)
            .WithMany(x => x.Notification)
            .HasForeignKey(x => x.VideoContentId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
