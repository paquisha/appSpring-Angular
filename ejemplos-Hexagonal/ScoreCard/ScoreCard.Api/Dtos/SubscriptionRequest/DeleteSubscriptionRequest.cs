using ScoreCard.Application.Commands.Subscription;

namespace ScoreCard.Api.Dtos.SubscriptionRequest;

public class DeleteSubscriptionRequest
{
    public DeleteSubscriptionCommand ToApplicationRequest(Guid id)
    {
        return new DeleteSubscriptionCommand(id);
    }
}