using ScoreCard.Domain.Seed;

namespace ScoreCard.Domain.Entities;

public class Customer: BaseEntity
{
    public string Name { get; set; }
    public bool IsActive { get; set; }
    
    public CustomerSecretInformation? CustomerSecretInformation { get; private set; }
    
    private readonly List<Subscription>? _subscriptions;
    public IReadOnlyCollection<Subscription>? Subscriptions => _subscriptions;


    protected Customer()
    {
        Id = Guid.NewGuid();
        _subscriptions = new List<Subscription>();
    }

    public Customer(string name, bool isActive)
    {
        Name = name;
        IsActive = isActive;
    
    }
}
