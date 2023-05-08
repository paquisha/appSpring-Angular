using MediatR;
using ScoreCard.Application.Dtos.Responses;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Queries.CustomerSecretInformationQueries;

public class ReadCustomerSecretInformationByIdQuery: IRequest<CustomerSecretInformationResponse>
{
    public Guid CustomerId { get; set; }

    public ReadCustomerSecretInformationByIdQuery(Guid customerId)
    {
        CustomerId = customerId;
    }
}