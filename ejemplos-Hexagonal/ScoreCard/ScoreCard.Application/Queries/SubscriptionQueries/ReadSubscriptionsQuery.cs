using MediatR;
using ScoreCard.Application.Dtos.Responses;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Queries.SubscriptionQueries;

public class ReadSubscriptionsQuery: IRequest<EntityResponse<List<SubscriptionResponse>>>
{
   

    
}