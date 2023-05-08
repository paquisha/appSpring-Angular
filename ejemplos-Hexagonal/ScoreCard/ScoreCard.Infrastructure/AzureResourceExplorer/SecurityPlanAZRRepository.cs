using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.ResourceGraph;
using Azure.ResourceManager.ResourceGraph.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ScoreCard.Domain.EntitiesAzureResourceExplorer;
using ScoreCard.Domain.InterfacesAzureResourceExplorer;

namespace ScoreCard.Infrastructure.AzureResourceExplorer;

public class SecurityPlanAZRRepository: ISecurityPlanAZR
{
    private readonly ILogger<SecurityPlanAZRRepository> _logger;

    public SecurityPlanAZRRepository(ILogger<SecurityPlanAZRRepository> logger)
    {
        _logger = logger;
    }
    
    public async Task<List<SecurityPlanAZR>> GetAsync(string subscriptionId, string tenantId, string applicationId,
        string clientSecret)
    {
        try
        {
            var client = new ArmClient(new ClientSecretCredential(tenantId, applicationId, clientSecret));
            string strQuery = $"SecurityResources | where type==\"microsoft.security/pricings\" | where subscriptionId==\"{subscriptionId}\" | project Subscription=subscriptionId,Azure_Defender_plan=name,Status=properties.pricingTier";
                SecurityPlanAZR securityPlan = new SecurityPlanAZR();
            var tenant = client.GetTenants().First();

            var queryContent = new ResourceQueryContent(strQuery);
            var response = tenant.GetResources(queryContent);
            var result = response.Value;
            var data = response.Value.Data.ToString();
            var listSecurityPlan = JsonConvert.DeserializeObject<List<SecurityPlanAZR>>(data);
        
            return  listSecurityPlan;
        }
        catch (Exception e)
        {
           _logger.LogInformation(e,"Security");
            throw;
        }
        
    }
}