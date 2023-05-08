using ScoreCard.Application.Queries.SubscriptionQueries;

namespace ScoreCard.Api.Dtos.SubscriptionRequest;

public class ReadSubscriptionsRequest
{
   public ReadSubscriptionsQuery ToApplicationRequest()
    {
        return new ReadSubscriptionsQuery();
    }

}