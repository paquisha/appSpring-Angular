using MediatR;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Commands.Subscription;

public class CreateSubscriptionCommand: IRequest<EntityResponse<bool>>
{
    public string? SubscriptionId { get; set; }
    public string? Name { get; set; }
    public Guid CustomerId { get; set; }
    

    public CreateSubscriptionCommand(string? subscriptionId, string? name, Guid customerId)
    {
        SubscriptionId = subscriptionId;
        Name = name;
        CustomerId = customerId;
    }
}