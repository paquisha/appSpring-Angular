using MediatR;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Commands.Subscription;

public class DeleteSubscriptionCommand : IRequest<EntityResponse<bool>>
{
    public Guid Id { get; set; }

    public DeleteSubscriptionCommand(Guid id)
    {
        Id = id;
    }
}