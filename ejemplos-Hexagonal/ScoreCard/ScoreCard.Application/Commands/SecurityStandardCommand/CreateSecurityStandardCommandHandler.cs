using MediatR;
using Microsoft.Extensions.Logging;
using ScoreCard.Domain.Entities;
using ScoreCard.Domain.Interfaces;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Commands.SecurityStandardCommand;

public class CreateSecurityStandardCommandHandler: IRequestHandler<CreateSecurityStandardCommand,
    EntityResponse<bool>>
{
    private readonly ILogger<CreateSecurityStandardCommandHandler> _logger;
    private readonly ISecurityStandardRepository _securityStandard;
    private readonly IMediator _mediator;

    public CreateSecurityStandardCommandHandler(ILogger<CreateSecurityStandardCommandHandler> logger, ISecurityStandardRepository securityStandard, IMediator mediator)
    {
        _logger = logger;
        _securityStandard = securityStandard;
        _mediator = mediator;   
    }

    public async Task<EntityResponse<bool>> Handle(CreateSecurityStandardCommand command,
        CancellationToken cancellationToken)

    {
        var securityStndard = new SecurityStandard(command.TenantId, command.SubscriptionId,
            command.ComplianceStandard, command.State,
            command.PassedControl,
            command.FailControl, command.UnsupportedControl, command.SecurityScoreSnapshotId);
        _securityStandard.Add(securityStndard);
        await _securityStandard.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        return EntityResponse.Success(true);
    }
}
