using ScoreCard.Domain.EntitiesAzureResourceExplorer;

namespace ScoreCard.Domain.InterfacesAzureResourceExplorer;

public interface ISecurityScoreControlAZR
{
    Task<List<SecurityScoreControlAZR>>  GetAsync(string subscriptionId, string tenantId, string applicationId,
        string clientSecret);
}