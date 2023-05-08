using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.ResourceGraph;
using Azure.ResourceManager.ResourceGraph.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ScoreCard.Domain.EntitiesAzureResourceExplorer;
using ScoreCard.Domain.InterfacesAzureResourceExplorer;
using ScoreCard.Domain.Seed;

namespace ScoreCard.Infrastructure.AzureResourceExplorer;

public class ControlRecommendationAZRRepository : IControlRecommendationAZR

{
    private readonly ILogger<ControlRecommendationAZRRepository> _logger;
   

    public ControlRecommendationAZRRepository(ILogger<ControlRecommendationAZRRepository> logger)
    {
        _logger = logger;
       
    }

    public async Task<List<ControlRecommendationIdAZR>> GetAsync(string subscriptionId, string tenantId, string applicationId,
        string clientSecret)
    {
        try
        {
            List<ControlRecommendationIdAZR> controlRecommendationIdAzrs = new List<ControlRecommendationIdAZR>();
            var client = new ArmClient(new ClientSecretCredential(tenantId, applicationId, clientSecret));
            string strQuery = $"SecurityResources | where type == \"microsoft.security/assessments\" | where subscriptionId==\"{subscriptionId}\"| extend recommendationId=name|   extend maturityLevel = case(isnull(properties.metadata.preview), \"GA\",tobool(properties.metadata.preview), \"Preview\",\"GA\"), dynamic(null)| project tenantId, subscriptionId, resourceId,recommendationName, recommendationId, recommendationState, recommendationSeverity, description, remediationDescription,assessmentType, policyDefinitionId, implementationEffort, userImpact, category, threats, source, portalLink, maturityLevel";
            ControlRecommendationIdAZR controlRecommendationId = new ControlRecommendationIdAZR();
            var tenant = client.GetTenants().First();

            var queryContent = new ResourceQueryContent(strQuery);
            var response = tenant.GetResources(queryContent);
            var result = response.Value;
            var data = response.Value.Data.ToString();
            
            controlRecommendationIdAzrs = JsonConvert.DeserializeObject<List<ControlRecommendationIdAZR>>(data);

            //ConstanteCRId.CONTROL_RECOMMENDATION_ID = controlRecommendationIdAzrs[0].ControlRemediationId;

            return controlRecommendationIdAzrs;
        }
        catch (Exception e)
        {
           _logger.LogInformation(e,"Security");
            throw;
        }
        
    }
}