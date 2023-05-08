using ScoreCard.Domain.Entities;
using ScoreCard.Domain.EntitiesAzureResourceExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCard.Domain.InterfacesAzureResourceExplorer
{
    public interface ISecurityRecommendationsAZR
    {
        Task<List<SecurityRecommendationsAZR>> GetAsync(string subscriptionId, string tenantId, string applicationId, string clientSecret);
    }
}
