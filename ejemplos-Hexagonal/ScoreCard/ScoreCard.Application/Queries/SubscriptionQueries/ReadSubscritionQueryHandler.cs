using MediatR;
using Microsoft.Extensions.Logging;
using ScoreCard.Application.Dtos.Responses;
using ScoreCard.Domain.Interfaces;

namespace ScoreCard.Application.Queries.SubscriptionQueries;

public class ReadSubscritionQueryHandler: IRequestHandler<ReadSubscriptionQuery, SubscriptionResponse>
{
    private readonly ILogger<ReadSubscritionQueryHandler> _logger;
    private readonly ISubscriptionRepository _subscriptionRepository;
    private readonly IMediator _mediator;

    public ReadSubscritionQueryHandler(ILogger<ReadSubscritionQueryHandler> logger, ISubscriptionRepository subscriptionRepository, IMediator mediator)
    {
        _logger = logger;
        _subscriptionRepository = subscriptionRepository;
        _mediator = mediator;
    }
    
    public async Task<SubscriptionResponse> Handle(ReadSubscriptionQuery query,
        CancellationToken cancellationToken)
    {
        /////////TODO
        var subscription = await _subscriptionRepository.GetByIdAsync(query.Id);
        return new SubscriptionResponse(subscription.Id,subscription.SubscriptionId, subscription.Name, subscription.CustomerId);

    }
}