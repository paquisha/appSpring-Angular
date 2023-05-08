using ScoreCard.Domain.EntitiesAzureResourceExplorer;

namespace ScoreCard.Domain.InterfacesAzureResourceExplorer;

public interface ISecurityPlanAZR
{
    Task<List<SecurityPlanAZR>> GetAsync(string subscriptionId, string tenantId, string applicationId,
        string clientSecret);
}