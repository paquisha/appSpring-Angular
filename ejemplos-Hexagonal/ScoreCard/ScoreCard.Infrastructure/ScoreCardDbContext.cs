using MediatR;
using Microsoft.EntityFrameworkCore;
using ScoreCard.Domain.Entities;
using ScoreCard.Domain.Seed;
using ScoreCard.Infrastructure.EntityConfigurations;

namespace ScoreCard.Infrastructure;

public class ScoreCardDbContext: DbContext, IUnitOfWork
{
    private readonly IMediator _mediator;
    
    public  DbSet<Customer> Customers { get; set; }
    public  DbSet<Subscription> Subscriptions { get; set; }
    public  DbSet<CustomerSecretInformation> CustomerSecretInformations { get; set; }
    public  DbSet<SecurityScoreSnapshot> SecurityScoreSnapshots { get; set; }
    public  DbSet<ControlRecommendationId> ControlRecommendationIds { get; set; }
    public  DbSet<SecurityScoreControl> SecurityScoreControls { get; set; }
    public  DbSet<SecureScore> SecureScores { get; set; }
    public  DbSet<SecurityPlan> SecurityPlans { get; set; }
    public  DbSet<SecurityStandard> SecurityStandards { get; set; }

    public ScoreCardDbContext(DbContextOptions<ScoreCardDbContext> options) : base(options)
    {
        
    }

    public ScoreCardDbContext(DbContextOptions<ScoreCardDbContext> options, IMediator mediator) : base(options)
    {
        _mediator = mediator;
    }
    
    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        var result = await base.SaveChangesAsync(cancellationToken);

        return true;
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerEfConfig());
        modelBuilder.ApplyConfiguration(new SubscriptionEfConfig());
        modelBuilder.ApplyConfiguration(new CustomerSecretInformationEfConfig());
        modelBuilder.ApplyConfiguration(new SecurityScoreSnapshotEfConfig());
        modelBuilder.ApplyConfiguration(new ControlRecommendationIdEfConfig());
        modelBuilder.ApplyConfiguration(new SecurityScoreControlEfConfig());
        modelBuilder.ApplyConfiguration(new SecureScoreEfConfig());
        modelBuilder.ApplyConfiguration(new SecurityPlanEfConfig());
        modelBuilder.ApplyConfiguration(new SecurityStandardEfConfig());
        
    }
    
    
    

}