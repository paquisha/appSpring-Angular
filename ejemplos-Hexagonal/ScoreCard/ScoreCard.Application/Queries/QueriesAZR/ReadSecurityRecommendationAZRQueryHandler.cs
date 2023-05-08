using MediatR;
using ScoreCard.Application.Dtos.Responses.ResponseAZR;
using ScoreCard.Domain.InterfacesAzureResourceExplorer;
using ScoreCard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCard.Application.Queries.QueriesAZR
{
    public class ReadSecurityRecommendationAZRQueryHandler : IRequestHandler<ReadSecurityRecommendationAZRQuery, EntityResponse<List<SecurityRecommendationsAZRResponse>>>
    {
        private readonly ISecurityRecommendationsAZR _securityRecommendationsAZR;

        public ReadSecurityRecommendationAZRQueryHandler(ISecurityRecommendationsAZR securityRecommendationsAZR)
        {
            _securityRecommendationsAZR = securityRecommendationsAZR;
        }

        public async Task<EntityResponse<List<SecurityRecommendationsAZRResponse>>> Handle(ReadSecurityRecommendationAZRQuery query, CancellationToken cancellationToken)
        {
            var securityRecommendation = await _securityRecommendationsAZR.GetAsync(query.SubscriptionId, query.TenatId,
                query.ApplicationId, query.ClientSecret);
            return EntityResponse.Success(securityRecommendation.Select(x => new SecurityRecommendationsAZRResponse(x.AssessmentKey, x.ResourceCount, x.Enviroments, x.DisplayName, x.MaturityLevel, x.Initiatives, x.Severity, x.SeverityNumber, x.CompletionStatus, x.CompletionStatusNumber)).ToList());
        }

    }
}
