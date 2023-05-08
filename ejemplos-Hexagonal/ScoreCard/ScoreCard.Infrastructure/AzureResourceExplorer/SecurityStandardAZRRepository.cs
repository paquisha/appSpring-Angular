using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.ResourceGraph;
using Azure.ResourceManager.ResourceGraph.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ScoreCard.Domain.EntitiesAzureResourceExplorer;
using ScoreCard.Domain.InterfacesAzureResourceExplorer;

namespace ScoreCard.Infrastructure.AzureResourceExplorer;

public class SecurityStandardAZRRepository : ISecurityStandardAZR
{
    private readonly ILogger<SecurityStandardAZRRepository> _logger;

    public SecurityStandardAZRRepository(ILogger<SecurityStandardAZRRepository> logger)
    {
        _logger = logger;
    }

    public async Task<List<SecurityStandardAZR>> GetAsync(string subscriptionId, string tenantId, string applicationId, string clientSecret)
    {
        try
        {
            var client = new ArmClient(new ClientSecretCredential(tenantId, applicationId, clientSecret));
            string strQuery =
                $"SecurityResources | where type==\"microsoft.security/regulatorycompliancestandards\" | where subscriptionId==\"{subscriptionId}\"| extend complianceStandard=name,state=properties.state,passedControls=properties.passedControls,failedControls=properties.failedControls,skippedControls=properties.skippedControls,unsupportedControls=properties.unsupportedControls|project tenantId,subscriptionId,complianceStandard,state,passedControls,failedControls,skippedControls,unsupportedControls";
            SecurityStandardAZR securityStandard = new SecurityStandardAZR();
            var tenant = client.GetTenants().First();

            var queryContent = new ResourceQueryContent(strQuery);
            var response = tenant.GetResources(queryContent);
            var result = response.Value;
            var data = response.Value.Data.ToString();
            var listSecurityStandar = JsonConvert.DeserializeObject<List<SecurityStandardAZR>>(data);

            return listSecurityStandar;
        }
        catch (Exception e)
        {
            _logger.LogInformation(e, "Security");
            throw;
        }

    }
    
    
}