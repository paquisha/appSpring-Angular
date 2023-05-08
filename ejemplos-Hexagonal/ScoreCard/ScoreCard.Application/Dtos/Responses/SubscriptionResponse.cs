namespace ScoreCard.Application.Dtos.Responses;

public class SubscriptionResponse
{
    public Guid Id { get; set; }
    public string? SubscriptionId { get; set; }
    public string? Name { get; set; }
    public Guid CustomerId { get; set; }

    public SubscriptionResponse(Guid id,string? subscriptionId, string? name, Guid customerId)
    {
        Id = id;
        SubscriptionId = subscriptionId;
        Name = name;
        CustomerId = customerId;
    }
}