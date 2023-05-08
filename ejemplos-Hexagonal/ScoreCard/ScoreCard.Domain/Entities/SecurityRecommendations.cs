using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCard.Domain.Entities
{
    public class SecurityRecommendations
    {
        public string assessmentKey { get; set; }
        public int resourceCount { get; set; }
        public List<string> enviroments { get; set; }
        public string displayName { get; set; }
        public string maturityLevel { get; set; }
        public List<string> initiatives { get; set; }
        public string severity { get; set; }
        public string severityNumber { get; set; }
        public string completionStatus { get; set; }
        public int completionStatusNumber { get; set; }

    }
}
