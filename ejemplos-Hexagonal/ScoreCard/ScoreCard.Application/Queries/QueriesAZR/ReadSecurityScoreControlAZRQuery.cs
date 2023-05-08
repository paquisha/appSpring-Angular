using MediatR;
using ScoreCard.Application.Dtos.Responses.ResponseAZR;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Queries.QueriesAZR;

public class ReadSecurityScoreControlAZRQuery : IRequest<EntityResponse<List<SecurityScoreControlAzrResponse>>>
{
    public string SubscriptionId { get; set; }
    public string TenatId { get; set; }
    public string  ApplicationId{ get; set; }
    
    public string ClientSecret { get; set; }

    public ReadSecurityScoreControlAZRQuery(string subscriptionId, string tenatId, string applicationId, string clientSecret)
    {
        SubscriptionId = subscriptionId;
        TenatId = tenatId;
        ApplicationId = applicationId;
        ClientSecret = clientSecret;
    }
}