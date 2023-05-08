using MediatR;
using ScoreCard.Application.Dtos.Responses;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Queries.CustomerQueries;

public class ReadCustomersQuery : IRequest<EntityResponse<List<CustomerResponse>>>
{
    
}