using MediatR;
using Microsoft.Extensions.Logging;
using ScoreCard.Domain.Entities;
using ScoreCard.Domain.Interfaces;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Commands.CustomerSecretInformationCommand;

public class UpdateCustomerSecretInformationCommandHandler: IRequestHandler<UpdateCustomerSecretInformationCommand,
    EntityResponse<bool>>
{
    private readonly ICustomerSecretInformationRepository _customerSecretInformation;

    public UpdateCustomerSecretInformationCommandHandler(ICustomerSecretInformationRepository customerSecretInformation)
    {
        _customerSecretInformation = customerSecretInformation;
    }

    public async Task<EntityResponse<bool>> Handle(UpdateCustomerSecretInformationCommand command,
        CancellationToken cancellationToken)
    {
        var cSecretInformation = await _customerSecretInformation.GetByIdAsync(command.Id);
        if (cSecretInformation == null)
        {
            return EntityResponse<bool>.Error($"Doesn't customerSecretInformation with id {command.Id}");
        }
        
        cSecretInformation.ClientSecret = command.ClientSecret;
        cSecretInformation.ApplicationId = command.ApplicationId;
        cSecretInformation.TenantId = command.TenantId;
        _customerSecretInformation.Update(cSecretInformation);
        await _customerSecretInformation.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        return EntityResponse.Success(true);
    }
}