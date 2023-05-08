using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCard.Application.Dtos.Responses.ResponseAZR
{
    public class SecurityRecommendationsAZRResponse
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

        public SecurityRecommendationsAZRResponse(string assessmentKey, int resourceCount, List<string> enviroments, string displayName, string maturityLevel, List<string> initiatives, string severity, string severityNumber, string completionStatus, int completionStatusNumber)
        {
            AssessmentKey = assessmentKey;
            ResourceCount = resourceCount;
            Enviroments = enviroments;
            DisplayName = displayName;
            MaturityLevel = maturityLevel;
            Initiatives = initiatives;
            Severity = severity;
            SeverityNumber = severityNumber;
            CompletionStatus = completionStatus;
            CompletionStatusNumber = completionStatusNumber;
        }
    }
}
