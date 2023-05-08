namespace ScoreCard.Domain.EntitiesAzureResourceExplorer;

public class SecurityScoreControlAZR
{
   
    public string? TenantId { get; set; }
    public string? SubscriptionId { get; set; }
    public string? ControlName { get; set; }
    public string? ControlId { get; set; }
    public int UnhealthyResourceCount { get; set; }
    public int HealthyResourceCount { get; set; }
    public int NotAppliclableResourceCount { get; set; }
    public decimal PercentageScore { get; set; }
    public decimal CurrentScore { get; set; }
    public int MaxScore { get; set; }
    public int Weight { get; set; }
    public string? ControlType { get; set; }
   
}