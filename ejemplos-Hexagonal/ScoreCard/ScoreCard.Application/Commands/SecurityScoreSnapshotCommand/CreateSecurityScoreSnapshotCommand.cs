using MediatR;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Commands.SecurityScoreSnapshotCommand;

public class CreateSecurityScoreSnapshotCommand: IRequest<EntityResponse<bool>>
{
    public DateTime SnapshotDate { get; set; }
    public Guid CustomerId { get; set; }
    public Guid SubscriptionId { get; set; }

    public CreateSecurityScoreSnapshotCommand(DateTime snapshotDate, Guid customerId, Guid subscriptionId)
    {
        SnapshotDate = snapshotDate;
        CustomerId = customerId;
        SubscriptionId = subscriptionId;
    }
}