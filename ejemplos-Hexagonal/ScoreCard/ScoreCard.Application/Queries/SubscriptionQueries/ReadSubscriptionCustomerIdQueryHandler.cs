using MediatR;
using Microsoft.Extensions.Logging;
using ScoreCard.Application.Dtos.Responses;
using ScoreCard.Domain.Interfaces;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Queries.SubscriptionQueries;

public class ReadSubscriptionCustomerIdQueryHandler : IRequestHandler<ReadSubscriptionCustomerIdQuery,
    EntityResponse<List<SubscriptionResponse>>>
{
    private readonly ILogger<ReadSubscriptionCustomerIdQueryHandler> _logger;
    private readonly ISubscriptionRepository _subscriptionRepository;
    private readonly IMediator _mediator;

    public ReadSubscriptionCustomerIdQueryHandler(ILogger<ReadSubscriptionCustomerIdQueryHandler> logger, ISubscriptionRepository subscriptionRepository, IMediator mediator)
    {
        _logger = logger;
        _subscriptionRepository = subscriptionRepository;
        _mediator = mediator;
    }

    public async Task<EntityResponse<List<SubscriptionResponse>>> Handle(
        ReadSubscriptionCustomerIdQuery query,
        CancellationToken cancellationToken)
    {
        var subscriptions = await _subscriptionRepository.GetByCustomerIdAsync(query.Id);
        _logger.Log(LogLevel.Information, "Get Subscriptions", subscriptions);
        if (subscriptions.Count == 0)
        {
            return EntityResponse<List<SubscriptionResponse>>.Error(
                "Doesn't exist subscriptions");
        }

        return EntityResponse.Success(subscriptions.Select(x =>
            new SubscriptionResponse(x.Id ,x.SubscriptionId, x.Name, x.CustomerId)).ToList());
    }
}