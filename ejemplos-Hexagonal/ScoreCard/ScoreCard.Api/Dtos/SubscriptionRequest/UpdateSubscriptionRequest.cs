using ScoreCard.Application.Commands.Subscription;

namespace ScoreCard.Api.Dtos.SubscriptionRequest;

public class UpdateSubscriptionRequest
{
    public string SubscriptionId { get; set; }
    public string Name { get; set; }
    public Guid CustomerId { get; set; }

    public UpdateSubscriptionRequest(string subscriptionId,string name, Guid customerId)
    {
        SubscriptionId = subscriptionId;
        Name = name;
        CustomerId = customerId;
    }

    public UpdateSubscriptionCommand ToApplicationRequest(Guid id)
    {
        return new UpdateSubscriptionCommand(id, SubscriptionId, Name, CustomerId);
    }
}