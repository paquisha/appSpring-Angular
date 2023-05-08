using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCard.AzureResourceExplorer.Dtos.Responses
{
    public class SecurityStandardResponse
    {
        public string? TenantId { get; set; }
        public string? SubscriptionId { get; set; }
        public string? ComplianceStandard { get; set; }
        public string? State { get; set; }
        public int PassedControl { get; set; }
        public int FailControl { get; set; }
        public int UnsupportedControl { get; set; }
    }
}
