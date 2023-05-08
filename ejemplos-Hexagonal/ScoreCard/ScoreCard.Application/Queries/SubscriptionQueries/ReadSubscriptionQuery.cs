using MediatR;
using ScoreCard.Application.Dtos.Responses;

namespace ScoreCard.Application.Queries.SubscriptionQueries;

public class ReadSubscriptionQuery: IRequest<SubscriptionResponse>
{
    public Guid Id { get; set; }
    
    public ReadSubscriptionQuery(Guid id)
    {
        Id = id;
    }
}