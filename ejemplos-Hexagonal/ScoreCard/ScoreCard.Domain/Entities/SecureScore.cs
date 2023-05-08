using ScoreCard.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCard.Domain.Entities
{
    public class SecureScore : BaseEntity
    {
        public string? Tenantid { get; set; }
        public string? SubscriptionId { get; set; }
        public decimal PercentageScore { get; set; }
        public decimal CurrentScore { get; set; }
        public int MaxScore { get; set; }
        public int Weight { get; set; }
        public Guid SecurityScoreSnapshotId { get; set; }

        public SecureScore()
        {
            Id = Guid.NewGuid();
        }

        public SecureScore(string? tenantid, string? subscriptionId, decimal percentageScore, decimal currentScore,
            int maxScore, int weight, Guid securityScoreSnapshotId): this()
        {
            Tenantid = tenantid;
            SubscriptionId = subscriptionId;
            PercentageScore = percentageScore;
            CurrentScore = currentScore;
            MaxScore = maxScore;
            Weight = weight;
            SecurityScoreSnapshotId = securityScoreSnapshotId;
        }
    }
}