namespace ScoreCard.Application.Dtos.Responses.ResponseAZR;

public class SecureScoreAZRResponse
{
    public string? Tenantid { get; set; }
    public string? SubscriptionId { get; set; }
    public decimal PercentageScore { get; set; }
    public decimal CurrentScore { get; set; }
    public int MaxScore { get; set; }
    public int Weight { get; set; }

    public SecureScoreAZRResponse(string? tenantid, string? subscriptionId, decimal percentageScore,
        decimal currentScore, int maxScore, int weight)
    {
        Tenantid = tenantid;
        SubscriptionId = subscriptionId;
        PercentageScore = percentageScore;
        CurrentScore = currentScore;
        MaxScore = maxScore;
        Weight = weight;
    }
}