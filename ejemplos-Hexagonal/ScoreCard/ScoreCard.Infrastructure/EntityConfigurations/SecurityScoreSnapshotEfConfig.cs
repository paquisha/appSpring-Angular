using Microsoft.EntityFrameworkCore;
using ScoreCard.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ScoreCard.Infrastructure.EntityConfigurations;

public class SecurityScoreSnapshotEfConfig : IEntityTypeConfiguration<SecurityScoreSnapshot>
{
    public void Configure(EntityTypeBuilder<SecurityScoreSnapshot> builder)
    {
        builder.ToTable(nameof(SecurityScoreSnapshot));

        builder.HasKey(t => t.Id);
        builder.Ignore(t => t.DomainEvents);

        builder.Property(t => t.SnapshotDate)
            .IsRequired();
        builder.Property(t => t.CustomerId)
            .IsRequired();
        builder.Property(t => t.SubscriptionId)
            .IsRequired();
        builder.Metadata.FindNavigation(nameof(SecurityScoreSnapshot.SecurityPlans))
            .SetPropertyAccessMode(PropertyAccessMode.Field);
        builder.Metadata.FindNavigation(nameof(SecurityScoreSnapshot.SecurityStandards))
            .SetPropertyAccessMode(PropertyAccessMode.Field);
        builder.Metadata.FindNavigation(nameof(SecurityScoreSnapshot.SecureScores))
            .SetPropertyAccessMode(PropertyAccessMode.Field);
        builder.Metadata.FindNavigation(nameof(SecurityScoreSnapshot.SecurityScoreControls))
            .SetPropertyAccessMode(PropertyAccessMode.Field);
        builder.Metadata.FindNavigation(nameof(SecurityScoreSnapshot.ControlRecommendationIds))
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
