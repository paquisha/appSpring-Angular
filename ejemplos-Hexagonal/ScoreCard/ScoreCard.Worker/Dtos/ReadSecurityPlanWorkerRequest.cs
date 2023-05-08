using ScoreCard.Application.Queries.QueriesAZR;

namespace ScoreCard.Worker.Dtos;

public class ReadSecurityPlanWorkerRequest
{
    public ReadSecurityPlanAZRQuery ToApplicationRequest(string subscriptionId, string tenatId, string applicationId, string clientSecret)
    {
        return new ReadSecurityPlanAZRQuery(subscriptionId, tenatId, applicationId, clientSecret);
    }
}