using MediatR;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Commands.SecurityPlanCommand;

public class CreateSecurityPlanCommand : IRequest<EntityResponse<bool>>
{
    public string? SubscriptionId { get; set; }
    public string? AzureDefenderPlan { get; set; }
    public string? Status { get; set; }
    public Guid SecurityScoreSnapshotId { get; set; }

    public CreateSecurityPlanCommand(string? subscriptionId, string? azureDefenderPlan, string? status,
        Guid securityScoreSnapshotId)
    {
        SubscriptionId = subscriptionId;
        AzureDefenderPlan = azureDefenderPlan;
        Status = status;
        SecurityScoreSnapshotId = securityScoreSnapshotId;
    }
}