using MediatR;
using Microsoft.Extensions.Logging;
using ScoreCard.Domain.Interfaces;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Commands.CustomerSecretInformationCommand;

public class DeleteCustomerSecretInformationCommandHandler : IRequestHandler<DeleteCustomerCommandInformationCommand, EntityResponse<bool>>
{
    private readonly ILogger<DeleteCustomerSecretInformationCommandHandler> _logger;
    private readonly ICustomerSecretInformationRepository _customerSecretInformationRepository;
    private readonly IMediator _mediator;

    public DeleteCustomerSecretInformationCommandHandler(ILogger<DeleteCustomerSecretInformationCommandHandler> logger,
        ICustomerSecretInformationRepository customerSecretInformationRepository, IMediator mediator)
    {
        _logger = logger;
        _customerSecretInformationRepository = customerSecretInformationRepository;
        _mediator = mediator;
    }

    public async Task<EntityResponse<bool>> Handle(DeleteCustomerCommandInformationCommand command, CancellationToken cancellationToken)
    {
        var customerSecretRExist = await _customerSecretInformationRepository.GetByIdAsync(command.Id);
        if (customerSecretRExist == null)
        {
            return EntityResponse<bool>.Error($"Doesn't customer exist with id {command.Id}");
        }
        _customerSecretInformationRepository.Delete(customerSecretRExist);
        await _customerSecretInformationRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        return EntityResponse.Success(true);
    }
}