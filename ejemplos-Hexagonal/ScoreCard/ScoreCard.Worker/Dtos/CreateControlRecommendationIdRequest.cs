using ScoreCard.Application.Commands.ControlRecommendationIdCommand;

namespace ScoreCard.Worker.Dtos;

public class CreateControlRecommendationIdRequest
{
    public string? ControlRemediationId { get; set; }
    public Guid SecureScoreSnapshotId { get; set; }

    public CreateControlRecommendationIdRequest(string? controlRemediationId, Guid secureScoreSnapshotId)
    {
        ControlRemediationId = controlRemediationId;
        SecureScoreSnapshotId = secureScoreSnapshotId;  
    }
    public CreateControlRecommendationIdCommand ToApplicationRequest()
    {
        return new CreateControlRecommendationIdCommand(ControlRemediationId, SecureScoreSnapshotId);
    }
}