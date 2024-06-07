namespace AmazonPrimeClone.Domain.Entities;
public class UserProfile : BaseEntity<string>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public byte[]? ProfilePic { get; set; }
    public DateTimeOffset? DateOfBirth { get; set; }
    public string? CountryId { get; set; }
    public string? CityId { get; set; }
    public Gender? Gender { get; set; }
    public Country Country { get; set; } = null!;
    public City City { get; set; } = null!;
    public ICollection<UserWishList> WishLists { get; set; } = [];
    public ICollection<VideoLike> Likes { get; set; } = [];
    public ICollection<ReportedVideo> ReportedVideos { get; set; } = [];
    public ICollection<VideoReview> Reviews { get; set; } = [];
    public UserNotificationSetting NotificationSettings { get; set; } = null!;
    public ICollection<Subscription> Subscriptions { get; set; } = [];
}
