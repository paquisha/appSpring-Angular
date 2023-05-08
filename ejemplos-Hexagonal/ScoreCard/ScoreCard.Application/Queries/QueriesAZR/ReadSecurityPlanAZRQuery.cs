using MediatR;
using ScoreCard.Application.Dtos.Responses.ResponseAZR;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Queries.QueriesAZR;

public class ReadSecurityPlanAZRQuery: IRequest<EntityResponse<List<SecurityPlanAZRResponse>>>
{
    public string SubscriptionId { get; set; }
    public string TenatId { get; set; }
    public string  ApplicationId{ get; set; }
    
    public string ClientSecret { get; set; }

    public ReadSecurityPlanAZRQuery(string subscriptionId, string tenatId, string applicationId, string clientSecret)
    {
        SubscriptionId = subscriptionId;
        TenatId = tenatId;
        ApplicationId = applicationId;
        ClientSecret = clientSecret;
    }
}