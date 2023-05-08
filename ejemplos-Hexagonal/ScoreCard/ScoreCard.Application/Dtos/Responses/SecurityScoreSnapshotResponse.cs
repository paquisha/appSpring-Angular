namespace ScoreCard.Application.Dtos.Responses;

public class SecurityScoreSnapshotResponse
{
    public Guid Id { get; set; }
    public DateTime SnapshotDate { get; set; }
    public Guid CustomerId { get; set; }
    public Guid SubscriptionId { get; set; }

    public SecurityScoreSnapshotResponse(Guid id, DateTime snapshotDate, Guid customerId, Guid subscriptionId)
    {
        Id = id;
        SnapshotDate = snapshotDate;
        CustomerId = customerId;
        SubscriptionId = subscriptionId;
    }
}