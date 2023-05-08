using ScoreCard.Application.Commands.CustomerCommand;

namespace ScoreCard.Api.Dtos.CustomerRequest;

public class UpdateCustomerRequest
{
    public string Name { get; set; }
    public bool IsActive { get; set; }
    

    public UpdateCustomerRequest(string name, bool isActive)
    {
        Name = name;
        IsActive = isActive;    
    }

    public UpdateCustomerCommand ToApplicationRequest(Guid id)
    {
        return new UpdateCustomerCommand(id, Name, IsActive);
    }
}