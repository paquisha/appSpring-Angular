using ScoreCard.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ScoreCard.Domain.Entities
{
    public class SecurityScoreSnapshot : BaseEntity
    {

        public DateTime SnapshotDate { get; set; }
        public Guid CustomerId { get; set; }
        public Guid SubscriptionId { get; set; }

        private readonly List<ControlRecommendationId> _controlRecommendationIds;
        public IReadOnlyCollection<ControlRecommendationId> ControlRecommendationIds => _controlRecommendationIds;
        
        private readonly List<SecurityScoreControl> _securityScoreControls;
        public IReadOnlyCollection<SecurityScoreControl> SecurityScoreControls => _securityScoreControls;
        
        private readonly List<SecureScore> _secureScores;
        public IReadOnlyCollection<SecureScore> SecureScores => _secureScores;
        
        private readonly List<SecurityPlan> _securityPlans;
        public IReadOnlyCollection<SecurityPlan> SecurityPlans => _securityPlans;
        
        private readonly List<SecurityStandard> _securityStandards;
        public IReadOnlyCollection<SecurityStandard> SecurityStandards => _securityStandards;

        protected SecurityScoreSnapshot()
        {
            Id = Guid.NewGuid();
            _controlRecommendationIds = new List<ControlRecommendationId>();
            _securityScoreControls = new List<SecurityScoreControl>();
            _secureScores = new List<SecureScore>();
            _securityPlans = new List<SecurityPlan>();
            _securityStandards = new List<SecurityStandard>();
        }

        public SecurityScoreSnapshot(DateTime snapshotDate, Guid customerId, Guid subscriptionId) : this() 
        {
            SnapshotDate = snapshotDate;
            CustomerId = customerId;
            SubscriptionId = subscriptionId;
        }

        public void AddSecurityScore(string? tenantid, string? subscriptionId, decimal percentageScore, decimal currentScore,
            int maxScore, int weight)
        {
            var securityScore =
                new SecureScore(tenantid, subscriptionId, percentageScore, currentScore, maxScore, weight, Id);
            _secureScores.Add(securityScore);
        }
        
        public void AddSecurityPlan(string? subscriptionId, string? azureDefenderPlan, string? status)
        {
            var securityPlan =
                new SecurityPlan(subscriptionId, azureDefenderPlan, status, Id);
            _securityPlans.Add(securityPlan);
        }

        public void AddSecurityStandard(string? tenantId, string? subscriptionId, string? complianceStandard, string? state,
            int passedControl, int failControl, int unsupportedControl)
        {
            var securityStandard = new SecurityStandard(tenantId, subscriptionId, complianceStandard, state,
                passedControl, failControl, unsupportedControl, Id);
            _securityStandards.Add(securityStandard);
        }

        public void AddControlRecommendationId(string? controlRemediationId)
        {
            var controlRecommendationId = new ControlRecommendationId(controlRemediationId, Id);
            _controlRecommendationIds.Add(controlRecommendationId);
        }

        public void AddSecurityScoreControl(string? tenantId, string? subscriptionId, string? controlName, string? controlId,
            int unhealthyResourceCount, int healthyResourceCount, int notAppliclableResourceCount,
            decimal percentageScore, decimal currentScore, int maxScore, int weight, string? controlType)
        {
            var securityScoreControl = new SecurityScoreControl(tenantId, subscriptionId, controlName, controlId, unhealthyResourceCount,
                notAppliclableResourceCount, notAppliclableResourceCount, percentageScore, currentScore, maxScore, weight,
                controlType, Id);
            _securityScoreControls.Add(securityScoreControl);
        }
    }
}
