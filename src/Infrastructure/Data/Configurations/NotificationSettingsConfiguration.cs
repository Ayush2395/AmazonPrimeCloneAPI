using AmazonPrimeClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonPrimeClone.Infrastructure.Data.Configurations;
public class NotificationSettingsConfiguration : IEntityTypeConfiguration<UserNotificationSetting>
{
    public void Configure(EntityTypeBuilder<UserNotificationSetting> builder)
    {
        builder.HasOne(x => x.User)
            .WithOne(x => x.NotificationSettings)
            .HasForeignKey<UserNotificationSetting>(x => x.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
