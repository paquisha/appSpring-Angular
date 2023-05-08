namespace ScoreCard.Domain.EntitiesAzureResourceExplorer;

public class SecurityStandardAZR
{
    public string? TenantId { get; set; }
    public string? SubscriptionId { get; set; }
    public string? ComplianceStandard { get; set; }
    public string? State { get; set; }
    public int PassedControls { get; set; }
    public int FailedControls { get; set; }
    public int SkippedControls { get; set; }
    public int UnsupportedControls { get; set; }
}