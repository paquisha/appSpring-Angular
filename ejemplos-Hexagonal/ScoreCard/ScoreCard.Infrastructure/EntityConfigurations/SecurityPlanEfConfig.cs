using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScoreCard.Domain.Entities;

namespace ScoreCard.Infrastructure.EntityConfigurations;

public class SecurityPlanEfConfig : IEntityTypeConfiguration<SecurityPlan>
{
    public void Configure(EntityTypeBuilder<SecurityPlan> builder)
    {
        builder.ToTable(nameof(SecurityPlan));

        builder.HasKey(t => t.Id);
        builder.Ignore(t => t.DomainEvents);
        builder.Property(t => t.SubscriptionId)
            .HasMaxLength(255);
        builder.Property(t => t.AzureDefenderPlan)
            .HasMaxLength(255);
        builder.Property(t => t.Status)
            .HasMaxLength(255);
        builder.Property(t => t.SecurityScoreSnapshotId)
            .IsRequired();


    }
}