using MediatR;
using ScoreCard.Application.Dtos.Responses;
namespace ScoreCard.Application.Queries.CustomerSecretInformationQueries;

public class ReadCustomerSecretInformationQuery: IRequest<CustomerSecretInformationResponse>
{
    public Guid Id { get; set; }

    public ReadCustomerSecretInformationQuery(Guid id)
    {
        Id = id;
    }
}