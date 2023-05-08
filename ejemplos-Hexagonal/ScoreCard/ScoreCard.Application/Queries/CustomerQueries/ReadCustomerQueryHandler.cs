using MediatR;
using Microsoft.Extensions.Logging;
using ScoreCard.Application.Dtos.Responses;
using ScoreCard.Domain.Entities;
using ScoreCard.Domain.Interfaces;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Queries.CustomerQueries;

public class ReadCustomerQueryHandler : IRequestHandler<ReadCustomerQuery, CustomerResponse>
{
    private readonly ILogger<ReadCustomerQueryHandler> _logger;
    private readonly ICustomerRepository _customerRepository;
    private readonly IMediator _mediator;

    public ReadCustomerQueryHandler(ILogger<ReadCustomerQueryHandler> logger,
        ICustomerRepository customerRepository, IMediator mediator)
    {
        _logger = logger;
        _customerRepository = customerRepository;
        _mediator = mediator;
    }

    public async Task<CustomerResponse> Handle(ReadCustomerQuery query,
        CancellationToken cancellationToken)
    {
        /////////TODO
        var customer = await _customerRepository.GetByIdAsync(query.Id);
        return new CustomerResponse(customer.Id, customer.Name, customer.IsActive);

    }
}