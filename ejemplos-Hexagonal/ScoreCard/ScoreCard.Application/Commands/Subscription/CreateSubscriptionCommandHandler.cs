using MediatR;
using Microsoft.Extensions.Logging;
using ScoreCard.Domain.Interfaces;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Commands.Subscription;

public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, EntityResponse<bool>>
{
    private readonly ILogger<CreateSubscriptionCommand> _logger;
    private readonly ISubscriptionRepository _subscriptionRepository;
    private readonly IMediator _mediator;

    public CreateSubscriptionCommandHandler(ILogger<CreateSubscriptionCommand> logger,
        ISubscriptionRepository subscriptionRepository, IMediator mediator)
    {
        _logger = logger;
        _subscriptionRepository = subscriptionRepository;
        _mediator = mediator;
    }

    public async Task<EntityResponse<bool>> Handle(CreateSubscriptionCommand command,
        CancellationToken cancellationToken)
    {
        var subscription =
            new Domain.Entities.Subscription(command.SubscriptionId, command.Name, command.CustomerId);
        _subscriptionRepository.Add(subscription);
        await _subscriptionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        return EntityResponse.Success(true);
    }
}