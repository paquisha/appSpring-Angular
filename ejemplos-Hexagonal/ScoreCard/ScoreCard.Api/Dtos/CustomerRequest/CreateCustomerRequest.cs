using ScoreCard.Application.Commands.CustomerCommand;
using ScoreCard.Domain.Entities;

namespace ScoreCard.Api.Dtos.CustomerRequest;

public class CreateCustomerRequest
{
    public string Name { get; set; }
    public bool IsActive { get; set; }
    

    public CreateCustomerRequest(string name, bool isActive)
    {
        Name = name;
        IsActive = isActive;    
    }

    public CreateCustomerCommand ToApplicationRequest()
    {
        return new CreateCustomerCommand(Name, IsActive);
    }
}