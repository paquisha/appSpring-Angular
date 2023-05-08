using MediatR;
using ScoreCard.Application.Dtos.Responses.ResponseAZR;
using ScoreCard.Domain.EntitiesAzureResourceExplorer;
using ScoreCard.Domain.InterfacesAzureResourceExplorer;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Queries.QueriesAZR;

public class ReadSecurityPlanAZRQueryHandler : IRequestHandler<ReadSecurityPlanAZRQuery,
    EntityResponse<List<SecurityPlanAZRResponse>>>
{
    private readonly ISecurityPlanAZR _securityPlanAzr;

    public ReadSecurityPlanAZRQueryHandler(ISecurityPlanAZR securityPlanAzr)
    {
        _securityPlanAzr = securityPlanAzr;
    }

    public async Task<EntityResponse<List<SecurityPlanAZRResponse>>> Handle(ReadSecurityPlanAZRQuery query,
        CancellationToken cancellationToken)
    {
        var securityPlanAzr = await _securityPlanAzr.GetAsync(query.SubscriptionId, query.TenatId,
            query.ApplicationId, query.ClientSecret);
        return EntityResponse.Success(securityPlanAzr.Select(x => new SecurityPlanAZRResponse(x.Subscription, x.Azure_Defender_Plan, x.Status)).ToList());
    }
}