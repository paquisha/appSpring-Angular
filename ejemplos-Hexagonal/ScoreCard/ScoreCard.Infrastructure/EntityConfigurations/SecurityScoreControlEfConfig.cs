using Microsoft.EntityFrameworkCore;
using ScoreCard.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ScoreCard.Infrastructure.EntityConfigurations;

public class SecurityScoreControlEfConfig : IEntityTypeConfiguration<SecurityScoreControl>
{
    public void Configure(EntityTypeBuilder<SecurityScoreControl> builder)
    {
        builder.ToTable(nameof(SecurityScoreControl));

        builder.HasKey(t => t.Id);
        builder.Ignore(t => t.DomainEvents);
        builder.Property(t => t.TenantId)
            .HasMaxLength(255);
        builder.Property(t => t.SubscriptionId)
            .HasMaxLength(255);
        builder.Property(t => t.ControlName)
            .HasMaxLength(255);
        builder.Property(t => t.ControlId)
            .HasMaxLength(255);
        builder.Property(t => t.UnhealthyResourceCount)
            .IsRequired();
        builder.Property(t => t.HealthyResourceCount)
            .IsRequired();
        builder.Property(t => t.PercentageScore)
            .IsRequired();
        builder.Property(t => t.CurrentScore)
            .IsRequired();
        builder.Property(t => t.MaxScore)
            .IsRequired();
        builder.Property(t => t.Weight)
            .IsRequired();
        builder.Property(t => t.ControlType)
            .HasMaxLength(255);
        builder.Property(t => t.SecurityScoreSnapshotId)
            .IsRequired();


    }
}
