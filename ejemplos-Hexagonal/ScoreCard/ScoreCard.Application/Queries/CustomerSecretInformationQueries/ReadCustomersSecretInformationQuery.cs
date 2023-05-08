using MediatR;
using ScoreCard.Application.Dtos.Responses;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Queries.CustomerSecretInformationQueries;

public class ReadCustomersSecretInformationQuery : IRequest<EntityResponse<List<CustomerSecretInformationResponse>>>
{
    
}
