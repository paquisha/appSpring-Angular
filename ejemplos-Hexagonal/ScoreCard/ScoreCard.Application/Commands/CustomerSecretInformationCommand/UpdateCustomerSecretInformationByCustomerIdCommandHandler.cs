using MediatR;
using ScoreCard.Domain.Interfaces;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Commands.CustomerSecretInformationCommand;

public class UpdateCustomerSecretInformationByCustomerIdCommandHandler : IRequestHandler<UpdateCustomerSecretInformationByCustomerIdCommand, EntityResponse<bool>>
{
    private readonly ICustomerSecretInformationRepository _customerSecretInformation;

    public UpdateCustomerSecretInformationByCustomerIdCommandHandler(ICustomerSecretInformationRepository customerSecretInformation)
    {
        _customerSecretInformation = customerSecretInformation;
    }

    public async Task<EntityResponse<bool>> Handle(UpdateCustomerSecretInformationByCustomerIdCommand command,
        CancellationToken cancellationToken)
    {
        var cSecretInformation = await _customerSecretInformation.GetByCustomerIdAsync(command.CustomerId);
        if (String.IsNullOrEmpty(cSecretInformation.ClientSecret))
        {
            return EntityResponse<bool>.Error($"Doesn't customerSecretInformation with id {command.CustomerId}");
        }
        
        cSecretInformation.ClientSecret = command.ClientSecret;
        cSecretInformation.ApplicationId = command.ApplicationId;
        cSecretInformation.TenantId = command.TenantId;
        _customerSecretInformation.UpdateByCustomerId(cSecretInformation);
        await _customerSecretInformation.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        return EntityResponse.Success(true);
    }
}