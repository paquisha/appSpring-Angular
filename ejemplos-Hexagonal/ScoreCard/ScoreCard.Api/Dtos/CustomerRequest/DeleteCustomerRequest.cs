using ScoreCard.Application.Commands.CustomerCommand;

namespace ScoreCard.Api.Dtos.CustomerRequest;

public class DeleteCustomerRequest
{
    public DeleteCustomerCommand ToApplicationRequest(Guid id)
    {
        return new DeleteCustomerCommand(id);
    }
}