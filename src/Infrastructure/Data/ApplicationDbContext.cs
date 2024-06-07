using System.Reflection;
using AmazonPrimeClone.Application.Common.Interfaces;
using AmazonPrimeClone.Domain.Entities;
using AmazonPrimeClone.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AmazonPrimeClone.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options), IApplicationDbContext
{
    public DbSet<UserProfile> UserProfiles => Set<UserProfile>();

    public DbSet<Subscription> Subscriptions => Set<Subscription>();

    public DbSet<SubscriptionPlan> SubscriptionPlans => Set<SubscriptionPlan>();

    public DbSet<Country> Countries => Set<Country>();

    public DbSet<City> Cities => Set<City>();

    public DbSet<ReportedVideo> ReportedVideos => Set<ReportedVideo>();

    public DbSet<UserNotification> UserNotifications => Set<UserNotification>();

    public DbSet<UserNotificationSetting> NotificationSettings => Set<UserNotificationSetting>();

    public DbSet<UserWishList> WishLists => Set<UserWishList>();

    public DbSet<VideoContent> VideoContents => Set<VideoContent>();

    public DbSet<VideoLike> Likes => Set<VideoLike>();

    public DbSet<VideoReview> Reviews => Set<VideoReview>();

    public DbSet<VideoThumbnail> Thumbnails => Set<VideoThumbnail>();

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();

    public DbSet<TodoList> TodoLists => Set<TodoList>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema("AmazonPrime");
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
