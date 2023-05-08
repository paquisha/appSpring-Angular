using MediatR;
using ScoreCard.Application.Dtos.Responses.ResponseAZR;
using ScoreCard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCard.Application.Queries.QueriesAZR
{
    public class ReadSecurityRecommendationAZRQuery: IRequest<EntityResponse<List<SecurityRecommendationsAZRResponse>>>
    {
        public string SubscriptionId { get; set; }
        public string TenatId { get; set; }
        public string ApplicationId { get; set; }
        public string ClientSecret { get; set; }

        public ReadSecurityRecommendationAZRQuery(string subscriptionId, string tenatId, string applicationId, string clientSecret)
        {
            SubscriptionId = subscriptionId;
            TenatId = tenatId;
            ApplicationId = applicationId;
            ClientSecret = clientSecret;
        }
    }
}
