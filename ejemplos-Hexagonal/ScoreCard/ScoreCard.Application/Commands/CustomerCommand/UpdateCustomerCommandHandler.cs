using MediatR;
using Microsoft.Extensions.Logging;
using ScoreCard.Domain.Entities;
using ScoreCard.Domain.Interfaces;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Commands.CustomerCommand;

public class UpdateCustomerCommandHandler: IRequestHandler<UpdateCustomerCommand, EntityResponse<bool>>
{
    private readonly ICustomerRepository _customerRepository;

    public UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<EntityResponse<bool>> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(command.Id);
        if (customer == null)
        {
            return EntityResponse<bool>.Error($"Doesn't customer exist with id {command.Id}");
        }

        customer.IsActive = command.IsActive;
        customer.Name = command.Name;
        _customerRepository.Update(customer);
        await _customerRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        return EntityResponse.Success(true);
    }
    
}