using MediatR;
using Microsoft.Extensions.Logging;
using ScoreCard.Domain.Entities;
using ScoreCard.Domain.Interfaces;
using ScoreCard.Domain.Models;


namespace ScoreCard.Application.Commands.CustomerCommand;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, EntityResponse<bool>>
{

    private readonly ILogger<CreateCustomerCommandHandler> _logger;
    private readonly ICustomerRepository _customerRepository;
    private readonly IMediator _mediator;

    public CreateCustomerCommandHandler(ILogger<CreateCustomerCommandHandler> logger,
        ICustomerRepository customerRepository, IMediator mediator)
    {
        _logger = logger;
        _customerRepository = customerRepository;
        _mediator = mediator;
    }
    public async Task<EntityResponse<bool>> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var customer = new Customer(command.Name, command.IsActive);
        _customerRepository.Add(customer);
        await _customerRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        return EntityResponse.Success(true);
    }
}
