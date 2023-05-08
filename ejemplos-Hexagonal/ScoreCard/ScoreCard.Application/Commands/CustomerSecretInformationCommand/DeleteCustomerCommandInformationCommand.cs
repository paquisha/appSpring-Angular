using MediatR;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Commands.CustomerSecretInformationCommand;

public class DeleteCustomerCommandInformationCommand: IRequest<EntityResponse<bool>>
{
    public Guid Id { get; set; }

    public DeleteCustomerCommandInformationCommand(Guid id)
    {
        Id = id;    
    }
}