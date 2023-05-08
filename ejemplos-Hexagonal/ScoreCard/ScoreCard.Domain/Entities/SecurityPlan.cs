using ScoreCard.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCard.Domain.Entities
{
    public class SecurityPlan : BaseEntity
    {
        public string? SubscriptionId { get; set; }
        public string? AzureDefenderPlan { get; set; }
        public string? Status { get; set; }
        public Guid SecurityScoreSnapshotId { get; set; }

        protected SecurityPlan()
        {
            Id = Guid.NewGuid();
        }

        public SecurityPlan(string? subscriptionId, string? azureDefenderPlan, string? status,
            Guid securityScoreSnapshotId) : this()
        {
            SubscriptionId = subscriptionId;
            AzureDefenderPlan = azureDefenderPlan;
            Status = status;
            SecurityScoreSnapshotId = securityScoreSnapshotId;
        }
    }
}