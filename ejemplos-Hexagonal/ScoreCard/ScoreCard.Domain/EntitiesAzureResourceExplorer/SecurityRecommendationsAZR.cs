using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCard.Domain.EntitiesAzureResourceExplorer
{
    public class SecurityRecommendationsAZR
    {
        public string? AssessmentKey { get; set; }
        public int ResourceCount { get; set; }
        public List<string>? Enviroments { get; set; }
        public string? DisplayName { get; set; }
        public string? MaturityLevel { get; set; }
        public List<string>? Initiatives { get; set; }
        public string? Severity { get; set; }
        public string? SeverityNumber { get; set; }
        public string? CompletionStatus { get; set; }
        public int CompletionStatusNumber { get; set; }

    }
}
