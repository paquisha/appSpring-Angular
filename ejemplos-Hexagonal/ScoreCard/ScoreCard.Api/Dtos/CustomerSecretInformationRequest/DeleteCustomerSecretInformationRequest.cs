using ScoreCard.Application.Commands.CustomerSecretInformationCommand;

namespace ScoreCard.Api.Dtos.CustomerSecretInformationRequest;

public class DeleteCustomerSecretInformationRequest
{
    public DeleteCustomerCommandInformationCommand ToApplicationRequest(Guid id)
    {
        return new DeleteCustomerCommandInformationCommand(id);
    }
}