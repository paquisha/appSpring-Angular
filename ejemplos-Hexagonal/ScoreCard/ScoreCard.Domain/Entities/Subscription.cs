using ScoreCard.Domain.Seed;

namespace ScoreCard.Domain.Entities;

public class Subscription: BaseEntity
{
    public string? SubscriptionId { get; set; }
    public string? Name { get; set; }
    public Guid CustomerId { get; set; }
    private readonly List<SecurityScoreSnapshot>? _securityScoreSnapshots;
    public IReadOnlyCollection<SecurityScoreSnapshot>? SecurityScoreSnapshots => _securityScoreSnapshots;

    protected Subscription()
    {
        Id = Guid.NewGuid();
        _securityScoreSnapshots= new List<SecurityScoreSnapshot>();
    }

    public Subscription(string? subscriptionId, string? name, Guid customerId)
    {
        SubscriptionId = subscriptionId;
        Name = name;
        CustomerId = customerId;
    }   
}