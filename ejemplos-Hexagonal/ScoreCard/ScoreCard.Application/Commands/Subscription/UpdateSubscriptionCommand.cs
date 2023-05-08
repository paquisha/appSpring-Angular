using MediatR;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Commands.Subscription;

public class UpdateSubscriptionCommand: IRequest<EntityResponse<bool>>
{
    public Guid Id { get; set; }
    public string SubscriptionId { get; set; }
    public string Name { get; set; }
    public Guid CustomerId { get; set; }

    public UpdateSubscriptionCommand(Guid id,string subscriptionId, string name, Guid customerId)
    {
        Id = id;
        SubscriptionId = subscriptionId;
        Name = name;
        CustomerId = customerId;
    }
}