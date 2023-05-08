using ScoreCard.Application.Queries.SubscriptionQueries;

namespace ScoreCard.Api.Dtos.SubscriptionRequest;

public class ReadSubscriptionsByCustomerRequest
{
    public ReadSubscriptionCustomerIdQuery ToApplicationRequest(Guid id)
    {
        return new ReadSubscriptionCustomerIdQuery(id);
    }
}