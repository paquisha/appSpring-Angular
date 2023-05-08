using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.ResourceGraph;
using Azure.ResourceManager.ResourceGraph.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ScoreCard.Domain.EntitiesAzureResourceExplorer;
using ScoreCard.Domain.InterfacesAzureResourceExplorer;

namespace ScoreCard.Infrastructure.AzureResourceExplorer;

public class SecureScoreAZRRepository : ISecureScoreAZR
{
    private readonly ILogger<SecureScoreAZRRepository> _logger;

    public SecureScoreAZRRepository(ILogger<SecureScoreAZRRepository> logger)
    {
        _logger = logger;
    }

    public async Task<List<SecureScoreAZR>> GetAsync(string subscriptionId, string tenantId, string applicationId,
        string clientSecret)
    {

        try
        {
            var client = new ArmClient(new ClientSecretCredential(tenantId, applicationId, clientSecret));
            string strQuery =$"SecurityResources | wheretype == \"microsoft.security/securescores\" |extend percentageScore=properties.score.percentage,currentScore=properties.score.current,maxScore=properties.score.max,weight=properties.weight | project tenantId,subscriptionId,percentageScore,currentScore,maxScore,weight";
            SecureScoreAZR secureScoreAzr = new SecureScoreAZR();
            var tenant = client.GetTenants().First();

            var queryContent = new ResourceQueryContent(strQuery);
            var response = tenant.GetResources(queryContent);
            var result = response.Value;
            var data = response.Value.Data.ToString();
            var listSecureScore = JsonConvert.DeserializeObject<List<SecureScoreAZR>>(data);
            //secureScoreAzr = listSecureScore.FirstOrDefault();

            return listSecureScore;
        }
        catch (Exception e)
        {
            _logger.LogInformation(e, "Security");
            throw;
        }

    }
}
   