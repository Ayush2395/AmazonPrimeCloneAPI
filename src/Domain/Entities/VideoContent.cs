namespace AmazonPrimeClone.Domain.Entities;
public class VideoContent : BaseEntity<string>
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public byte[]? Video { get; set; }
    public ICollection<VideoThumbnail> Thumbnails { get; set; } = [];
    public ICollection<UserWishList> WishLists { get; set; } = [];
    public ICollection<VideoLike> Likes { get; set; } = [];
    public ICollection<ReportedVideo> ReportedVideos { get; set; } = [];
    public ICollection<VideoReview> Reviews { get; set; } = [];
    public ICollection<UserNotification> Notification { get; set; } = [];
}
