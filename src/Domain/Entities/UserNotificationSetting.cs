namespace AmazonPrimeClone.Domain.Entities;
public class UserNotificationSetting : BaseEntity<string>
{
    public bool? IsEnabled { get; set; }
    public UserProfile User { get; set; } = null!;
    public ICollection<UserNotification> Notifications { get; set; } = [];
}
