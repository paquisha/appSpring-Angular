using MediatR;
using Microsoft.Extensions.Logging;
using ScoreCard.Application.Dtos.Responses.ResponseAZR;
using ScoreCard.Application.Queries.QueriesAZR;
using ScoreCard.Domain.Entities;
using ScoreCard.Domain.EntitiesAzureResourceExplorer;
using ScoreCard.Domain.Interfaces;
using ScoreCard.Domain.Models;
using ScoreCard.Domain.Seed;

namespace ScoreCard.Application.Commands.SecurityScoreControlCommand;

public class CreateSecurityScoreControlCommandHandler : IRequestHandler<CreateSecurityScoreControlCommand,
    EntityResponse<bool>>
{
    private readonly ILogger<CreateSecurityScoreControlCommandHandler> _logger;
    private readonly ISecurityScoreControlRepository _securityScoreControl;
    // private readonly ControlRecommendationIdAZRResponse _controlRecommendationAzr;
    private readonly IMediator _mediator;

    public CreateSecurityScoreControlCommandHandler(ILogger<CreateSecurityScoreControlCommandHandler> logger,
        ReadSecurityScoreControlAZRQuery rsecurityScoreControl,
        SecurityScoreControlAzrResponse securityScoreControlResponse, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    public async Task<EntityResponse<bool>> Handle(CreateSecurityScoreControlCommand command,
        CancellationToken cancellationToken)

    {
        var securityScoreControl = new SecurityScoreControl(command.TenantId, command.SubscriptionId,
            command.ControlName, command.ControlId,
            command.UnhealthyResourceCount,
            command.HealthyResourceCount, command.NotAppliclableResourceCount, command.PercentageScore,
            command.CurrentScore,
            command.MaxScore, command.Weight, command.ControlType, command.SecurityScoreSnapshotId);
        
        _securityScoreControl.Add(securityScoreControl);
        await _securityScoreControl.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        return EntityResponse.Success(true);
    }
}

