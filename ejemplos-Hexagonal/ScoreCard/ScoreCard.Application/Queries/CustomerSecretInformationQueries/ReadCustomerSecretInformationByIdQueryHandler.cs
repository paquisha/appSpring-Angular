using MediatR;
using Microsoft.Extensions.Logging;
using ScoreCard.Application.Dtos.Responses;
using ScoreCard.Domain.Interfaces;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Queries.CustomerSecretInformationQueries;

public class ReadCustomerSecretInformationByIdQueryHandler : IRequestHandler<ReadCustomerSecretInformationByIdQuery, CustomerSecretInformationResponse> 
{
    private readonly ILogger<ReadCustomerSecretInformationByIdQueryHandler> _logger;
    private readonly ICustomerSecretInformationRepository _customerSecretInformationRepository;
    private readonly IMediator _mediator;

    public ReadCustomerSecretInformationByIdQueryHandler(ILogger<ReadCustomerSecretInformationByIdQueryHandler> logger, ICustomerSecretInformationRepository customerSecretInformationRepository, IMediator mediator)
    {
        _logger = logger;
        _customerSecretInformationRepository = customerSecretInformationRepository;
        _mediator = mediator;
    }

    public async Task<CustomerSecretInformationResponse> Handle(ReadCustomerSecretInformationByIdQuery query,
        CancellationToken canelationToken)
    {
        var customerSecretInformation = await _customerSecretInformationRepository.GetByCustomerIdAsync(query.CustomerId);
        return new CustomerSecretInformationResponse(customerSecretInformation.Id, customerSecretInformation.TenantId,
            customerSecretInformation.ClientSecret, customerSecretInformation.ApplicationId, customerSecretInformation.CustomerId);
    }
}