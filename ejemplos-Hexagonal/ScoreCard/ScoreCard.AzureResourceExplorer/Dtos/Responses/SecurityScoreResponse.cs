using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCard.AzureResourceExplorer.Dtos.Responses
{
    public class SecurityScoreResponse
    {
        public string? TenantId { get; set; }
        public string? TenantName { get; set;}
        public decimal PercentageScore { get; set; }
        public decimal CurrentScore { get; set; }
        public int MaxScore { get; set; }
        public int Weight { get; set; }
    }
}
