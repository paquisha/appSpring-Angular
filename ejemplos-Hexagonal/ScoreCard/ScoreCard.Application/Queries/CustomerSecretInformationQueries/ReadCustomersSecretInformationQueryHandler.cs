using MediatR;
using Microsoft.Extensions.Logging;
using ScoreCard.Application.Dtos.Responses;
using ScoreCard.Application.Queries.CustomerSecretInformationQueries;
using ScoreCard.Domain.Interfaces;
using ScoreCard.Domain.Models;


public class ReadCustomersSecretInformationQueryHandler : IRequestHandler<ReadCustomersSecretInformationQuery,
    EntityResponse<List<CustomerSecretInformationResponse>>>
{
    private readonly ILogger<ReadCustomersSecretInformationQueryHandler> _logger;
    private readonly ICustomerSecretInformationRepository _customerSecretInformationRepository;
    private readonly IMediator _mediator;

    public ReadCustomersSecretInformationQueryHandler(ILogger<ReadCustomersSecretInformationQueryHandler> logger,
        ICustomerSecretInformationRepository customerSecretInformationRepository, IMediator mediator)
    {
        _logger = logger;
        _customerSecretInformationRepository = customerSecretInformationRepository;
        _mediator = mediator;
    }

    public async Task<EntityResponse<List<CustomerSecretInformationResponse>>> Handle(
        ReadCustomersSecretInformationQuery request,
        CancellationToken cancellationToken)
    {
        var customersecret = await _customerSecretInformationRepository.GetAllAsync();
        _logger.Log(LogLevel.Information, "Get Customers", customersecret);
        if (customersecret.Count == 0)
        {
            return EntityResponse<List<CustomerSecretInformationResponse>>.Error("Doesn't exist customer secret information");
        }

        return EntityResponse.Success(customersecret.Select(x =>
            new CustomerSecretInformationResponse(x.Id ,x.TenantId, x.ClientSecret, x.ApplicationId, x.CustomerId)).ToList());
    }
}