namespace AmazonPrimeClone.Domain.Entities;
public class SubscriptionPlan : BaseEntity<string>
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public SubscriptionType PlanType { get; set; }
    public ICollection<Subscription> Subscriptions { get; set; } = [];
}
