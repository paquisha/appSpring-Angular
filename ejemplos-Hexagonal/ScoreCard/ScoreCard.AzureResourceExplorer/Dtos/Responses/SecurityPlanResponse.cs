using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCard.AzureResourceExplorer.Dtos.Responses
{
    public class SecurityPlanResponse
    {
        public string? SubscriptionId { get; set; }
        public string? AzureDefenderPlan { get; set; }
        public string? Status { get; set; }
    }
}
