using ScoreCard.Application.Queries.SubscriptionQueries;

namespace ScoreCard.Worker.Dtos;

public class ReadSubscriptionWorkerRequest
{
    public ReadSubscriptionCustomerIdQuery ToApplicationRequest(Guid customerId)
    {
        return new ReadSubscriptionCustomerIdQuery(customerId);
    }
}