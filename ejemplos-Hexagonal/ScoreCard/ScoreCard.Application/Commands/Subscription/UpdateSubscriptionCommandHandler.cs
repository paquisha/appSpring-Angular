using MediatR;
using ScoreCard.Domain.Interfaces;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Commands.Subscription;

public class UpdateSubscriptionCommandHandler: IRequestHandler<UpdateSubscriptionCommand, EntityResponse<bool>>
{
    private readonly ISubscriptionRepository _subscriptionRepository;

    public UpdateSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository)
    {
        _subscriptionRepository = subscriptionRepository;
    }

    public async Task<EntityResponse<bool>> Handle(UpdateSubscriptionCommand command,
        CancellationToken cancellationToken)
    {
        var subscription = await _subscriptionRepository.GetByIdAsync(command.Id);
        if (subscription == null)
        {
            return EntityResponse<bool>.Error($"Doesn't customer exist with id {command.CustomerId}");
        }

        subscription.CustomerId = command.CustomerId;
        subscription.Name = command.Name;
        _subscriptionRepository.Update(subscription);
        await _subscriptionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        return EntityResponse.Success(true);
    }
}