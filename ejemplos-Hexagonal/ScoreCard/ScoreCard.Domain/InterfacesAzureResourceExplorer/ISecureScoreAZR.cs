using ScoreCard.Domain.EntitiesAzureResourceExplorer;

namespace ScoreCard.Domain.InterfacesAzureResourceExplorer;

public interface ISecureScoreAZR
{
    Task<List<SecureScoreAZR>> GetAsync(string subscriptionId, string tenantId, string applicationId,
        string clientSecret);
}