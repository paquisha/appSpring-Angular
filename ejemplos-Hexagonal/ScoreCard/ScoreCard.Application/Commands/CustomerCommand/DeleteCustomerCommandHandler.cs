using MediatR;
using Microsoft.Extensions.Logging;
using ScoreCard.Domain.Entities;
using ScoreCard.Domain.Interfaces;
using ScoreCard.Domain.Models;
using ScoreCard.Domain.Specifications;

namespace ScoreCard.Application.Commands.CustomerCommand;

public class DeleteCustomerCommandHandler: IRequestHandler<DeleteCustomerCommand, EntityResponse<bool>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMediator _mediator;
    public DeleteCustomerCommandHandler(ICustomerRepository customerRepository, IMediator mediator)
    {
        _customerRepository = customerRepository;
        _mediator = mediator;
    }
    public async Task<EntityResponse<bool>> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
    {
        var customerExist = await _customerRepository.GetByIdAsync(command.Id);
        if (customerExist.Name == "")
        {
            return EntityResponse<bool>.Error($"Doesn't customer exist with id {command.Id}");
        }

        _customerRepository.Delete(customerExist);
        await _customerRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        return EntityResponse.Success(true);
    }
}