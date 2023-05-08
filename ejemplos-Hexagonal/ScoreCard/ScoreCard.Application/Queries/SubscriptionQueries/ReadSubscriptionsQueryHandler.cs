using MediatR;
using Microsoft.Extensions.Logging;
using ScoreCard.Application.Dtos.Responses;
using ScoreCard.Domain.Interfaces;
using ScoreCard.Domain.Models;
using Serilog;

namespace ScoreCard.Application.Queries.SubscriptionQueries;

public class ReadSubscriptionsQueryHandler: IRequestHandler<ReadSubscriptionsQuery,
    EntityResponse<List<SubscriptionResponse>>>
{
    private readonly ILogger<ReadSubscriptionsQueryHandler> _logger;
    private readonly ISubscriptionRepository _subscriptionRepository;
   

    public ReadSubscriptionsQueryHandler(ILogger<ReadSubscriptionsQueryHandler> logger,
        ISubscriptionRepository subscriptionRepository)
    {
        _logger = logger;
        _subscriptionRepository = subscriptionRepository;
        
    }

    public async Task<EntityResponse<List<SubscriptionResponse>>> Handle(
        ReadSubscriptionsQuery request,
        CancellationToken cancellationToken)
    {
        var subscriptions = await _subscriptionRepository.GetAllAsync();
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