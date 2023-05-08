using MediatR;
using Microsoft.Extensions.Logging;
using ScoreCard.Application.Dtos.Responses;
using ScoreCard.Domain.Interfaces;
using ScoreCard.Domain.Models;




namespace ScoreCard.Application.Queries.CustomerQueries;

public class ReadCustomersQueryHandler: IRequestHandler<ReadCustomersQuery, EntityResponse<List<CustomerResponse>>>
{
    private readonly ILogger<ReadCustomersQueryHandler> _logger;
    private readonly ICustomerRepository _customerRepository;


    public ReadCustomersQueryHandler(ILogger<ReadCustomersQueryHandler> logger,
        ICustomerRepository customerRepository)
    {
        _logger = logger;
        _customerRepository = customerRepository;
       
    }

    public async Task<EntityResponse<List<CustomerResponse>>> Handle(ReadCustomersQuery request,
        CancellationToken cancellationToken)
    {
        var customers = await _customerRepository.GetAllAsync();
        _logger.Log(LogLevel.Information, "Get Customers", customers);
        if (customers.Count == 0)
        {
            return EntityResponse<List<CustomerResponse>>.Error("Doesn't exist customers");
        }

        return EntityResponse.Success(customers.Select(x => new CustomerResponse(x.Id,x.Name, x.IsActive)).ToList());

    }


}