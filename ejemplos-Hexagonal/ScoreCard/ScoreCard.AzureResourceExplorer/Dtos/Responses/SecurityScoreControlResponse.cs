using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCard.AzureResourceExplorer.Dtos.Responses
{
    public class SecurityScoreControlResponse
    {
        public string? TenantId { get; set; }
        public string? SubscriptionId { get; set; }
        public string? ControlName { get; set; }
        public string? ControlId { get; set; }
        public int UnhealthyResourceCount { get; set; }
        public int HealthyResourceCount { get; set; }
        public int NotAppliclableResourceCount { get; set; }
        public decimal PercentageScore { get; set; }
        public decimal CurrentScore { get; set; }
        public int MaxScore { get; set; }
        public int Weight { get; set; }
        public string? ControlType { get; set; }
    }
}
