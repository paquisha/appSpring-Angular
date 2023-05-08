using MediatR;
using ScoreCard.Application.Dtos.Responses;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Queries.CustomerQueries;

public class ReadCustomerQuery: IRequest<CustomerResponse>
{
    public Guid Id { get; set; }

    public ReadCustomerQuery(Guid id)
    {
        Id = id;
    }

}
