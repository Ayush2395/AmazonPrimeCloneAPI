using AmazonPrimeClone.Domain.Entities;

namespace AmazonPrimeClone.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<UserProfile> UserProfiles { get; }

    DbSet<Subscription> Subscriptions { get; }

    DbSet<SubscriptionPlan> SubscriptionPlans { get; }

    DbSet<Country> Countries { get; }

    DbSet<City> Cities { get; }

    DbSet<ReportedVideo> ReportedVideos { get; }

    DbSet<UserNotification> UserNotifications { get; }

    DbSet<UserNotificationSetting> NotificationSettings { get; }

    DbSet<UserWishList> WishLists { get; }

    DbSet<VideoContent> VideoContents { get; }

    DbSet<VideoLike> Likes { get; }

    DbSet<VideoReview> Reviews { get; }

    DbSet<VideoThumbnail> Thumbnails { get; }
    DbSet<TodoItem> TodoItems { get; }

    DbSet<TodoList> TodoLists { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
