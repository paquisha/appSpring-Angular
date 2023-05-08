using MediatR;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Commands.CustomerCommand;

public class UpdateCustomerCommand: IRequest<EntityResponse<bool>>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }

    public UpdateCustomerCommand(Guid id, string name, bool isActive)
    {
        Id = id;
        Name = name;
        IsActive = isActive;
    }
}