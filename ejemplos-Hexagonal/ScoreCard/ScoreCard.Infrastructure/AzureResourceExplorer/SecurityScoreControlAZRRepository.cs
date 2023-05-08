

using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.ResourceGraph;
using Azure.ResourceManager.ResourceGraph.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ScoreCard.Domain.EntitiesAzureResourceExplorer;
using ScoreCard.Domain.InterfacesAzureResourceExplorer;

namespace ScoreCard.Infrastructure.AzureResourceExplorer;

public class SecurityScoreControlAZRRepository : ISecurityScoreControlAZR
{
    private readonly ILogger<SecurityScoreControlAZRRepository> _logger;

    public SecurityScoreControlAZRRepository(ILogger<SecurityScoreControlAZRRepository> logger)
    {
        _logger = logger;
    }
    
    public async Task<List<SecurityScoreControlAZR>> GetAsync(string subscriptionId, string tenantId, string applicationId,
        string clientSecret)
    {
        try
        {
            var client = new ArmClient(new ClientSecretCredential(tenantId, applicationId, clientSecret));
            string strQuery = $"SecurityResources | where type == \"microsoft.security/securescores/securescorecontrols\" | where subscriptionId==\"{subscriptionId}\"| extend controlName=properties.displayName,controlId=properties.definition.name,notApplicableResourceCount=properties.notApplicableResourceCount,unhealthyResourceCount=properties.unhealthyResourceCount,healthyResourceCount=properties.healthyResourceCount,percentageScore=properties.score.percentage,currentScore=properties.score.current,maxScore=properties.definition.properties.maxScore,weight=properties.weight,controlType=properties.definition.properties.source.sourceType,controlRecommendationIds=properties.definition.properties.assessmentDefinitions| project tenantId, subscriptionId, controlName, controlId, unhealthyResourceCount, healthyResourceCount, notApplicableResourceCount, percentageScore, currentScore, maxScore, weight, controlType, controlRecommendationIds";
            SecurityScoreControlAZR securityScoreControl = new SecurityScoreControlAZR();
            var tenant = client.GetTenants().First();

            var queryContent = new ResourceQueryContent(strQuery);
            var response = tenant.GetResources(queryContent);
            var result = response.Value;
            var data = response.Value.Data.ToString(); 
            var listSecurityScoreControl = JsonConvert.DeserializeObject<List<SecurityScoreControlAZR>>(data);

            return  listSecurityScoreControl;
            
        }
        catch (Exception e)
        {
           _logger.LogInformation(e,"Security");
            throw;
        }
        
    }

   
        
   
}