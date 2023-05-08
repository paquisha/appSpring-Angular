using ScoreCard.Application.Queries.QueriesAZR;

namespace ScoreCard.Worker.Dtos;

public class ReadSecurityStandarWorkerRequest
{
    public ReadSecurityStandardAZRQuery ToApplicationRequest(string subscriptionId, string tenatId, string applicationId, string clientSecret)
    {
        return new ReadSecurityStandardAZRQuery(subscriptionId, tenatId, applicationId, clientSecret);
    }
}