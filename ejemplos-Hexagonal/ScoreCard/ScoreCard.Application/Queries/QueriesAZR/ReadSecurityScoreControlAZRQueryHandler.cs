using MediatR;
using Microsoft.Extensions.Logging;
using ScoreCard.Application.Dtos.Responses.ResponseAZR;
using ScoreCard.Domain.EntitiesAzureResourceExplorer;
using ScoreCard.Domain.InterfacesAzureResourceExplorer;
using ScoreCard.Domain.Models;
using ScoreCard.Domain.Specifications;


namespace ScoreCard.Application.Queries.QueriesAZR;

public class ReadSecurityScoreControlAZRQueryHandler : IRequestHandler<ReadSecurityScoreControlAZRQuery,
        EntityResponse<List<SecurityScoreControlAzrResponse>>>
{
    private readonly ISecurityScoreControlAZR _securityScoreControlAzr;

    public ReadSecurityScoreControlAZRQueryHandler(ISecurityScoreControlAZR securityScoreControlAzr)
    {
        _securityScoreControlAzr = securityScoreControlAzr;
    }

    public async Task<EntityResponse<List<SecurityScoreControlAzrResponse>>> Handle(ReadSecurityScoreControlAZRQuery query,
        CancellationToken cancellationToken)
    {
        var securityScoreControl = await _securityScoreControlAzr.GetAsync(query.SubscriptionId, query.TenatId,
            query.ApplicationId, query.ClientSecret);
        
        return EntityResponse.Success(securityScoreControl.Select(x => new SecurityScoreControlAzrResponse(x.TenantId,
            x.SubscriptionId, x.ControlName,
            x.ControlId, x.UnhealthyResourceCount, x.HealthyResourceCount, x.NotAppliclableResourceCount,
            x.PercentageScore, x.CurrentScore, x.MaxScore, x.Weight, x.ControlType)).ToList());
    }
}

