namespace AmazonPrimeClone.Domain.Entities;
public class UserNotification : BaseEntity<string>
{
    public string? NotificationSettingId { get; set; }
    public UserNotificationSetting NotificationSetting { get; set; } = null!;
    public string? Title { get; set; }
    public string? SubTitle { get; set; }
    public string? VideoContentId { get; set; }
    public VideoContent VideoContent { get; set; } = null!;
}
