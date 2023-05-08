using Azure.Identity;
using Azure.ResourceManager.ResourceGraph.Models;
using Azure.ResourceManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.ResourceManager.ResourceGraph;

namespace ScoreCard.AzureResourceExplorer
{
    public class AzResourceExplorer
    {
        ClientSecretCredential _clientSecretCredential;
        public AzResourceExplorer( string tenantId, string clientId, string clientSecret)
        {
            _clientSecretCredential = new ClientSecretCredential(tenantId, clientId, clientSecret);
        }
        public ResourceQueryResult? GetQueryContent ( string query ) 
        {
            var client = new ArmClient(_clientSecretCredential);
            var tenant = client.GetTenants().First();
            var queryContent = new ResourceQueryContent(query);
            var response = tenant.GetResources(queryContent);
            return response.Value;
        }
    }
}
