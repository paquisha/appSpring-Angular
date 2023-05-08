using ScoreCard.Application.Queries.QueriesAZR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCard.Worker.Dtos
{
    public class ReadSecurityRecommendationRequest
    {
        public ReadSecurityRecommendationAZRQuery ToApplicationRequest(string subscriptionId, string tenatId, string applicationId, string clientSecret)
        {
            return new ReadSecurityRecommendationAZRQuery(subscriptionId, tenatId, applicationId, clientSecret);
        }
    }
}
