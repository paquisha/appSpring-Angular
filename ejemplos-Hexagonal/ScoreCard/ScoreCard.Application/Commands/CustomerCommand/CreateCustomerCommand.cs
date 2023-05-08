using MediatR;
using ScoreCard.Domain.Entities;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Commands.CustomerCommand;

public class CreateCustomerCommand: IRequest<EntityResponse<bool>>
{
    public string Name { get; set; }
    public bool IsActive { get; set; }
  
    public CreateCustomerCommand(string name, bool isActive)
    {
        Name = name;
        IsActive = isActive;
    }
}