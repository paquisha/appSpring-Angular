using ScoreCard.Application.Commands.Subscription;

namespace ScoreCard.Api.Dtos.SubscriptionRequest;

public class CreateSubscriptionRequest
{
    public string? SubscriptionId { get; set; }
    public string? Name { get; set; }
    public Guid CustomerId { get; set; }

    public CreateSubscriptionRequest(string? subscriptionId, string? name, Guid customerId)
    {
        SubscriptionId = subscriptionId;
        Name = name;
        CustomerId = customerId;
    }

    public CreateSubscriptionCommand ToApplicationRequest()
    {
        return new CreateSubscriptionCommand(SubscriptionId, Name, CustomerId);
    }
}