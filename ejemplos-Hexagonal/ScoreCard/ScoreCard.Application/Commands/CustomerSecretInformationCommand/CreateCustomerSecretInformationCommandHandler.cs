using MediatR;
using Microsoft.Extensions.Logging;
using ScoreCard.Domain.Entities;
using ScoreCard.Domain.Interfaces;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Commands.CustomerSecretInformationCommand;

public class CreateCustomerSecretInformationCommandHandler : IRequestHandler<CreateCustomerSecretInformationCommand,
    EntityResponse<bool>>
{
    private readonly ILogger<CreateCustomerSecretInformationCommandHandler> _logger;
    private readonly ICustomerSecretInformationRepository _customerSecretInformation;

    public CreateCustomerSecretInformationCommandHandler(ILogger<CreateCustomerSecretInformationCommandHandler> logger,
        ICustomerSecretInformationRepository customerSecretInformation)
    {
        _logger = logger;
        _customerSecretInformation = customerSecretInformation;
    }

    public async Task<EntityResponse<bool>> Handle(CreateCustomerSecretInformationCommand command,
        CancellationToken cancellationToken)
    {
        var cSecretInformation = new CustomerSecretInformation(command.TenantId, command.ClientSecret,
            command.ApplicationId, command.CustomerId);
        _customerSecretInformation.Add(cSecretInformation);
        await _customerSecretInformation.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        return EntityResponse.Success(true);
    }
}