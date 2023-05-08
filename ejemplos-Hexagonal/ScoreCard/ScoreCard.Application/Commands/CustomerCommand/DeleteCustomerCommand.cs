using MediatR;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Commands.CustomerCommand;

public class DeleteCustomerCommand: IRequest<EntityResponse<bool>>
{
    public Guid Id { get; set; }

    public DeleteCustomerCommand(Guid id)
    {
        Id = id;    
    }
}