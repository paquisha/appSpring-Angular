using ScoreCard.Application.Queries.QueriesAZR;

namespace ScoreCard.Worker.Dtos;

public class ReadControlRecommendationIdRequest
{
    public ReadControlRecommendationIdAZRQuery ToApplicationRequest(string subscriptionId, string tenatId, string applicationId, string clientSecret)
    {
        return new ReadControlRecommendationIdAZRQuery(subscriptionId, tenatId, applicationId, clientSecret);
    }
}