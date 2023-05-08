using ScoreCard.Application.Queries.QueriesAZR;

namespace ScoreCard.Worker.Dtos;

public class ReadSecurityScoreControlWorkerRequest
{

    public ReadSecurityScoreControlAZRQuery ToApplicationRequest(string subscriptionId, string tenantId,
        string applicationId, string clientSecret)
    {
        return new ReadSecurityScoreControlAZRQuery(subscriptionId, tenantId, applicationId, clientSecret);
    }
}