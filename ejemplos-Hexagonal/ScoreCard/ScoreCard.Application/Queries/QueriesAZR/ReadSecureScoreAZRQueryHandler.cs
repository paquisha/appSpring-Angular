using MediatR;
using ScoreCard.Application.Dtos.Responses.ResponseAZR;
using ScoreCard.Domain.InterfacesAzureResourceExplorer;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Queries.QueriesAZR;

public class ReadSecureScoreAZRQueryHandler : IRequestHandler<ReadSecureScoreAZRQuery,
    EntityResponse<List<SecureScoreAZRResponse>>>
{
    private readonly ISecureScoreAZR _secureScoreAzr;

    public ReadSecureScoreAZRQueryHandler(ISecureScoreAZR secureScoreAzr)
    {
        _secureScoreAzr = secureScoreAzr;
    }

    public async Task<EntityResponse<List<SecureScoreAZRResponse>>> Handle(ReadSecureScoreAZRQuery query,
        CancellationToken cancellationToken)
    {
        var secureScore = await _secureScoreAzr.GetAsync(query.SubscriptionId, query.TenatId,
            query.ApplicationId, query.ClientSecret);
        return EntityResponse.Success(secureScore.Select(x => new SecureScoreAZRResponse(x.Tenantid, x.SubscriptionId, x.PercentageScore, x.CurrentScore,
            x.MaxScore, x.Weight)).ToList());
    }
}