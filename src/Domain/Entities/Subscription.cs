namespace AmazonPrimeClone.Domain.Entities;
public class Subscription : BaseEntity<string>
{
    public string? UserId { get; set; }
    public string? PlanId { get; set; }
    public DateTimeOffset ValidUpto { get; set; }
    public UserProfile User { get; set; } = null!;
    public SubscriptionPlan Plan { get; set; } = null!;
}
