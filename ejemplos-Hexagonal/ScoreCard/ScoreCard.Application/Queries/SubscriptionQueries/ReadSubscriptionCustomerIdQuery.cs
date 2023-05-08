using MediatR;
using ScoreCard.Application.Dtos.Responses;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Queries.SubscriptionQueries;

public class ReadSubscriptionCustomerIdQuery : IRequest<EntityResponse<List<SubscriptionResponse>>>
{
    public Guid Id { get; set; }
    
    public ReadSubscriptionCustomerIdQuery(Guid id)
    {
        Id = id;
    }
}