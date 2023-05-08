using ScoreCard.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ScoreCard.Domain.Entities
{
    public class ControlRecommendationId : BaseEntity
    {
        public string? ControlRemediationId { get; set; }
        public Guid SecurityScoreSnapshotId { get; set; }
        protected ControlRecommendationId()
        {
            Id = Guid.NewGuid();
        }

        public ControlRecommendationId(string? controlRemediationId, Guid securityScoreSnapshotId): this()
        {
            ControlRemediationId = controlRemediationId;
            SecurityScoreSnapshotId = securityScoreSnapshotId;  
        }
    }
}
