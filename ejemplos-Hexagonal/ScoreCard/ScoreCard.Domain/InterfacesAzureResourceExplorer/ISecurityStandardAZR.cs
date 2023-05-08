using ScoreCard.Domain.EntitiesAzureResourceExplorer;

namespace ScoreCard.Domain.InterfacesAzureResourceExplorer;

public interface ISecurityStandardAZR
{
    Task<List<SecurityStandardAZR>>  GetAsync(string subscriptionId, string tenantId, string applicationId,
        string clientSecret);
}