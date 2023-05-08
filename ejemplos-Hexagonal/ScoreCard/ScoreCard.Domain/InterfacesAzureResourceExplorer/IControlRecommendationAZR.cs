using ScoreCard.Domain.EntitiesAzureResourceExplorer;

namespace ScoreCard.Domain.InterfacesAzureResourceExplorer;

public interface IControlRecommendationAZR
{
    Task<List<ControlRecommendationIdAZR>> GetAsync(string subscriptionId, string tenantId, string applicationId,
        string clientSecret);

    
}