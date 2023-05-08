using MediatR;
using ScoreCard.Application.Dtos.Responses.ResponseAZR;
using ScoreCard.Domain.InterfacesAzureResourceExplorer;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Queries.QueriesAZR;

public class ReadSecurityStandardAZRQueryHandler : IRequestHandler<ReadSecurityStandardAZRQuery,
    EntityResponse<List<SecurityStandardAZRResponse>>>
{
    private readonly ISecurityStandardAZR _securityStandard;

    public ReadSecurityStandardAZRQueryHandler(ISecurityStandardAZR securityStandardAzr)
    {
        _securityStandard = securityStandardAzr;
    }

    public async Task<EntityResponse<List<SecurityStandardAZRResponse>>> Handle(
        ReadSecurityStandardAZRQuery query,
        CancellationToken cancellationToken)
    {
        var securityStandardAzr = await _securityStandard.GetAsync(query.SubscriptionId, query.TenatId,
            query.ApplicationId, query.ClientSecret);
        return EntityResponse.Success(securityStandardAzr.Select(x => new SecurityStandardAZRResponse(x.TenantId, x.SubscriptionId, x.ComplianceStandard,
            x.State, x.PassedControls, x.FailedControls, x.UnsupportedControls)).ToList());
    }
}