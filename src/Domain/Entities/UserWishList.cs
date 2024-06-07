namespace AmazonPrimeClone.Domain.Entities;
public class UserWishList : BaseEntity<string>
{
    public string? VideoContentId { get; set; }
    public string? UserId { get; set; }
    public VideoContent VideoContent { get; set; } = null!;
    public UserProfile? User { get; set; } = null!;
}
