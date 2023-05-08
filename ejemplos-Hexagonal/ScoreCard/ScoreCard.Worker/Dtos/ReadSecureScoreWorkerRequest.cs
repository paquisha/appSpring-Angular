using ScoreCard.Application.Queries.QueriesAZR;

namespace ScoreCard.Worker.Dtos;

public class ReadSecureScoreWorkerRequest
{
    public ReadSecureScoreAZRQuery ToApplicationRequest(string subscriptionId, string tenatId, string applicationId, string clientSecret)
    {
        return new ReadSecureScoreAZRQuery(subscriptionId, tenatId, applicationId, clientSecret);
    }
}