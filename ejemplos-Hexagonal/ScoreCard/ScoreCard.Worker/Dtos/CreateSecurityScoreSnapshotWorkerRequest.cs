using ScoreCard.Application.Commands.SecurityScoreSnapshotCommand;

namespace ScoreCard.Worker.Dtos;

public class CreateSecurityScoreSnapshotWorkerRequest
{
    public DateTime SnapshotDate { get; set; }
    public Guid CustomerId { get; set; }
    public Guid SubscriptionId { get; set; }

    public CreateSecurityScoreSnapshotWorkerRequest(DateTime snapshotDate, Guid customerId, Guid subscriptionId)
    {
        SnapshotDate = snapshotDate;
        CustomerId = customerId;
        SubscriptionId = subscriptionId;
    }

    public CreateSecurityScoreSnapshotCommand ToApplicationRequest()
    {
        return new CreateSecurityScoreSnapshotCommand(SnapshotDate, CustomerId, SubscriptionId);
    }
}