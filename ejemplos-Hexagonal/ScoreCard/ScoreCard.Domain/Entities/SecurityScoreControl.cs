using ScoreCard.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCard.Domain.Entities
{
    public class SecurityScoreControl : BaseEntity
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
        public Guid SecurityScoreSnapshotId { get; set; }

        protected SecurityScoreControl()
        {
            Id = Guid.NewGuid();
        }

        public SecurityScoreControl(string? tenantId, string? subscriptionId, string? controlName, string? controlId,
            int unhealthyResourceCount, int healthyResourceCount, int notAppliclableResourceCount,
            decimal percentageScore, decimal currentScore, int maxScore, int weight, string? controlType,
            Guid securityScoreSnapshotId): this()
        {
            TenantId = tenantId;
            SubscriptionId = subscriptionId;
            ControlName = controlName;
            ControlId = controlId;
            UnhealthyResourceCount = unhealthyResourceCount;
            HealthyResourceCount = healthyResourceCount;
            NotAppliclableResourceCount = notAppliclableResourceCount;
            PercentageScore = percentageScore;
            CurrentScore = currentScore;
            MaxScore = maxScore;
            Weight = weight;
            ControlType = controlType;
            SecurityScoreSnapshotId = securityScoreSnapshotId;
        }
    }
}