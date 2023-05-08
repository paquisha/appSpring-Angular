using MediatR;
using ScoreCard.Application.Dtos.Responses;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Queries.CustomerQueries;

public class ReadCustomersByIdsQuery : IRequest<EntityResponse<List<CustomerResponse>>>
{
    
}