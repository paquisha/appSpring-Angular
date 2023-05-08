namespace ScoreCard.Domain.EntitiesAzureResourceExplorer;

public class SecureScoreAZR
{
    public string? Tenantid { get; set; }
    public string? SubscriptionId { get; set; }
    public decimal PercentageScore { get; set; }
    public decimal CurrentScore { get; set; }
    public int MaxScore { get; set; }
    public int Weight { get; set; }
}