namespace AmazonPrimeClone.Domain.Events;
public record UserCreatedEvent(UserProfile User) : BaseEvent;
