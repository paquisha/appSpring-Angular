namespace ScoreCard.Application.Dtos.Responses.ResponseAZR;

public class ControlRecommendationIdAZRResponse
{
    public string? ControlRemediationId { get; set; }

    public ControlRecommendationIdAZRResponse(string? controlRemediationId)
    {
        ControlRemediationId = controlRemediationId;
    }
}