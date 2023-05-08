using MediatR;
using Microsoft.Extensions.Logging;
using ScoreCard.Application.Dtos.Responses;
using ScoreCard.Domain.Interfaces;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Queries.CustomerQueries;

public class ReadCustomersByIdsQueryHandler : IRequestHandler<ReadCustomersByIdsQuery, EntityResponse<List<CustomerResponse>>>
{
    private readonly ILogger<ReadCustomersByIdsQueryHandler> _logger;
    private readonly ICustomerRepository _customerRepository;
    private readonly IMediator _mediator;

    public ReadCustomersByIdsQueryHandler(ILogger<ReadCustomersByIdsQueryHandler> logger, ICustomerRepository customerRepository, IMediator mediator)
    {
        _logger = logger;
        _customerRepository = customerRepository;
        _mediator = mediator;
    }

    public async Task<EntityResponse<List<CustomerResponse>>> Handle(ReadCustomersByIdsQuery request,
        CancellationToken cancellationToken)
    {
        var customersIsActive = await _customerRepository.GetActiveCustomers();
        _logger.Log(LogLevel.Information, "Get Customers", customersIsActive);
        if (customersIsActive.Count <= 0)
        {
            return EntityResponse<List<CustomerResponse>>.Error("Doesn't exist customers");
        }

        var customerResponse = customersIsActive
            .Select(x => new CustomerResponse(x.Id, x.Name, x.IsActive, 
                x.Subscriptions.Select(y=> new SubscriptionResponse(y.Id, y.SubscriptionId, y.Name, y.CustomerId)).ToList(), 
                new CustomerSecretInformationResponse(x.CustomerSecretInformation.Id, x.CustomerSecretInformation.TenantId,
                    x.CustomerSecretInformation.ClientSecret, x.CustomerSecretInformation.ApplicationId, x.CustomerSecretInformation.CustomerId))).ToList();
        return EntityResponse.Success(customerResponse);
    }
}