using MediatR;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Commands.ControlRecommendationIdCommand;

public class CreateControlRecommendationIdCommand: IRequest<EntityResponse<bool>>
{
    public string? ControlRemediationId { get; set; }
    public Guid SecurityScoreSnapshotId { get; set; }

    public CreateControlRecommendationIdCommand(string? controlRemediationId, Guid securityScoreSnapshotId)
    {
        ControlRemediationId = controlRemediationId;
        SecurityScoreSnapshotId = securityScoreSnapshotId;  
    }
}