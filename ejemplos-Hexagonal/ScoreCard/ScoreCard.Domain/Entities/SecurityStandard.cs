using ScoreCard.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCard.Domain.Entities
{
    public class SecurityStandard : BaseEntity
    {
        public string? TenantId { get; set; }
        public string? SubscriptionId { get; set; }
        public string? ComplianceStandard { get; set; }
        public string? State { get; set; }
        public int PassedControl { get; set; }
        public int FailControl { get; set; }
        public int UnsupportedControl { get; set; }
        public Guid SecurityScoreSnapshotId { get; set; }

        SecurityStandard()
        {
            Id = Guid.NewGuid();
        }

        public SecurityStandard(string? tenantId, string? subscriptionId, string? complianceStandard, string? state,
            int passedControl, int failControl, int unsupportedControl, Guid securityScoreSnapshotId): this()
        {
            TenantId = tenantId;
            SubscriptionId = subscriptionId;
            ComplianceStandard = complianceStandard;
            State = state;
            PassedControl = passedControl;
            FailControl = failControl;
            UnsupportedControl = unsupportedControl;
            SecurityScoreSnapshotId = securityScoreSnapshotId;
        }
    }
}