using MediatR;
using Microsoft.Extensions.Logging;
using ScoreCard.Application.Dtos.Responses;
using ScoreCard.Domain.Interfaces;

namespace ScoreCard.Application.Queries.CustomerSecretInformationQueries;

public class ReadCustormerSecretInformationQueryHandler: IRequestHandler<ReadCustomerSecretInformationQuery, CustomerSecretInformationResponse>
{
    private readonly ILogger<ReadCustormerSecretInformationQueryHandler> _logger;
    private readonly ICustomerSecretInformationRepository _customerSecretInformation;
    private readonly IMediator _mediator;

    public ReadCustormerSecretInformationQueryHandler(ILogger<ReadCustormerSecretInformationQueryHandler> logger, ICustomerSecretInformationRepository customerSecretInformation, IMediator mediator)
    {
        _logger = logger;
        _customerSecretInformation = customerSecretInformation;
        _mediator = mediator;
    }

    public async Task<CustomerSecretInformationResponse> Handle(ReadCustomerSecretInformationQuery query,
        CancellationToken canelationToken)
    {
        var customerSecretInformation = await _customerSecretInformation.GetByIdAsync(query.Id);
        return new CustomerSecretInformationResponse(customerSecretInformation.Id,customerSecretInformation.TenantId,
            customerSecretInformation.ClientSecret, customerSecretInformation.ApplicationId, customerSecretInformation.CustomerId);
    }
}