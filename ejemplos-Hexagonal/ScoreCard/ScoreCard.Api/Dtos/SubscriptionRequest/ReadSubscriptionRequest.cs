using ScoreCard.Application.Queries.SubscriptionQueries;

namespace ScoreCard.Api.Dtos.SubscriptionRequest;

public class ReadSubscriptionRequest
{
    public ReadSubscriptionQuery ToApplicationRequest(Guid id)
    {
        return new ReadSubscriptionQuery(id);
    }
}