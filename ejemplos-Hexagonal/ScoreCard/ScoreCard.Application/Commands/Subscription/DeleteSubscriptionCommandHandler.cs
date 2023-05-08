using MediatR;
using ScoreCard.Domain.Interfaces;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Commands.Subscription;

public class DeleteSubscriptionCommandHandler : IRequestHandler<DeleteSubscriptionCommand, EntityResponse<bool>>
{
    private readonly ISubscriptionRepository _subscriptionRepository;
    private readonly IMediator _mediator;

    public DeleteSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository, IMediator mediator)
    {
        _subscriptionRepository = subscriptionRepository;
        _mediator = mediator;
    }
    
    public async Task<EntityResponse<bool>> Handle(DeleteSubscriptionCommand command, CancellationToken cancellationToken)
    {
        var subscription = await _subscriptionRepository.GetByIdAsync(command.Id);
        if (subscription.Name == "")
        {
            return EntityResponse<bool>.Error($"Doesn't customer exist with id {command.Id}");
        }

        _subscriptionRepository.Delete(subscription);
        await _subscriptionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        return EntityResponse.Success(true);
    }
}