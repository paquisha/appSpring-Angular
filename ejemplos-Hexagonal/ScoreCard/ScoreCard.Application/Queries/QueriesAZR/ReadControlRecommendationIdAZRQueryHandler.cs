using MediatR;
using ScoreCard.Application.Dtos.Responses;
using ScoreCard.Application.Dtos.Responses.ResponseAZR;
using ScoreCard.Application.Queries.CustomerQueries;
using ScoreCard.Domain.InterfacesAzureResourceExplorer;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Queries.QueriesAZR;

public class ReadControlRecommendationIdAZRQueryHandle : IRequestHandler<ReadControlRecommendationIdAZRQuery,
    EntityResponse<List<ControlRecommendationIdAZRResponse>>>
{
    private readonly IControlRecommendationAZR _controlRecommendationAzr;

    public ReadControlRecommendationIdAZRQueryHandle(IControlRecommendationAZR controlRecommendationAzr)
    {
        _controlRecommendationAzr = controlRecommendationAzr;
    }

    public async Task<EntityResponse<List<ControlRecommendationIdAZRResponse>>> Handle(
        ReadControlRecommendationIdAZRQuery query,
        CancellationToken cancellationToken)
    {
        var controlRecommendationIdAzr = await _controlRecommendationAzr
            .GetAsync(query.SubscriptionId, query.TenatId,
            query.ApplicationId, query.ClientSecret);
        return  EntityResponse.Success(controlRecommendationIdAzr.Select(x => new ControlRecommendationIdAZRResponse(x.ControlRemediationId)).ToList());
          }
}