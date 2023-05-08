using MediatR;
using Microsoft.Extensions.Logging;
using ScoreCard.Domain.Entities;
using ScoreCard.Domain.Interfaces;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Commands.SecurityPlanCommand;

public class CreateSecurityPlanCommandHandler: IRequestHandler<CreateSecurityPlanCommand,
    EntityResponse<bool>>
{
    private readonly ILogger<CreateSecurityPlanCommandHandler> _logger;
    private readonly ISecurityPlanRepository _securityPlan;
    private readonly IMediator _mediator;

    public CreateSecurityPlanCommandHandler(ILogger<CreateSecurityPlanCommandHandler> logger, ISecurityPlanRepository securityPlan, IMediator mediator)
    {
        _logger = logger;
        _securityPlan = securityPlan;
        _mediator = mediator;
    }

    public async Task<EntityResponse<bool>> Handle(CreateSecurityPlanCommand command,
        CancellationToken cancellationToken)

    {
        var securityPlan = new SecurityPlan(command.SubscriptionId, command.AzureDefenderPlan, command.Status, command.SecurityScoreSnapshotId
           );
        _securityPlan.Add(securityPlan);
        await _securityPlan.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        return EntityResponse.Success(true);
    }
}