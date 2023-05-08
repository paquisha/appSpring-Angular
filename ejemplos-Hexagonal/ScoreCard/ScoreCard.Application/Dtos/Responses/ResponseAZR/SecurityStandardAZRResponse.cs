namespace ScoreCard.Application.Dtos.Responses.ResponseAZR;

public class SecurityStandardAZRResponse
{
    public string? TenantId { get; set; }
    public string? SubscriptionId { get; set; }
    public string? ComplianceStandard { get; set; }
    public string? State { get; set; }
    public int PassedControl { get; set; }
    public int FailControl { get; set; }
    public int UnsupportedControl { get; set; }

    public SecurityStandardAZRResponse(string? tenantId, string? subscriptionId, string? complianceStandard,
        string? state, int passedControl, int failControl, int unsupportedControl)
    {
        TenantId = tenantId;
        SubscriptionId = subscriptionId;
        ComplianceStandard = complianceStandard;
        State = state;
        PassedControl = passedControl;
        FailControl = failControl;
        UnsupportedControl = unsupportedControl;
    }
}