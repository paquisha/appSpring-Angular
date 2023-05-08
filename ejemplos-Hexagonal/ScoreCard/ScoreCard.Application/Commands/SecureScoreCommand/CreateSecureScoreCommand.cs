using MediatR;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Commands.SecureScoreCommand;

public class CreateSecureScoreCommand : IRequest<EntityResponse<bool>>
{
    public string? Tenantid { get; set; }
    public string? SubscriptionId { get; set; }
    public decimal PercentageScore { get; set; }
    public decimal CurrentScore { get; set; }
    public int MaxScore { get; set; }
    public int Weight { get; set; }
    public Guid SecurityScoreSnapshotId { get; set; }

    public CreateSecureScoreCommand(string? tenantid, string? subscriptionId, decimal percentageScore,
        decimal currentScore, int maxScore, int weight, Guid securityScoreSnapshotId)
    {
        Tenantid = tenantid;
        SubscriptionId = subscriptionId;
        PercentageScore = percentageScore;
        CurrentScore = currentScore;
        MaxScore = maxScore;
        Weight = weight;
        SecurityScoreSnapshotId = securityScoreSnapshotId;
    }
}