using MediatR;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Commands.SecurityStandardCommand;

public class CreateSecurityStandardCommand : IRequest<EntityResponse<bool>>
{
    public string? TenantId { get; set; }
    public string? SubscriptionId { get; set; }
    public string? ComplianceStandard { get; set; }
    public string? State { get; set; }
    public int PassedControl { get; set; }
    public int FailControl { get; set; }
    public int UnsupportedControl { get; set; }
    public Guid SecurityScoreSnapshotId { get; set; }

    public CreateSecurityStandardCommand(string? tenantId, string? subscriptionId, string? complianceStandard,
        string? state, int passedControl, int failControl, int unsupportedControl, Guid securityScoreSnapshotId)
    {
        TenantId = tenantId;
        SubscriptionId = subscriptionId;
        ComplianceStandard = complianceStandard;
        State = state;
        PassedControl = passedControl;
        FailControl = failControl;
        UnsupportedControl = unsupportedControl;
        SecurityScoreSnapshotId = securityScoreSnapshotId;
    }
}