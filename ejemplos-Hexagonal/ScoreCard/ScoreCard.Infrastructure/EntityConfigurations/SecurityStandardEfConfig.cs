using Microsoft.EntityFrameworkCore;
using ScoreCard.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ScoreCard.Infrastructure.EntityConfigurations;

public class SecurityStandardEfConfig : IEntityTypeConfiguration<SecurityStandard>
{
    public void Configure(EntityTypeBuilder<SecurityStandard> builder)
    {
        builder.ToTable(nameof(SecurityStandard));
        builder.HasKey(t => t.Id);
        builder.Ignore(t => t.DomainEvents);
        builder.Property(t => t.TenantId)
            .HasMaxLength(255);
        builder.Property(t => t.SubscriptionId)
            .HasMaxLength(255);
        builder.Property(t => t.ComplianceStandard)
            .HasMaxLength(255);
        builder.Property(t => t.State)
            .HasMaxLength(255);
        builder.Property(t => t.PassedControl)
            .IsRequired();
        builder.Property(t => t.FailControl)
            .IsRequired();
        builder.Property(t => t.UnsupportedControl)
            .IsRequired();
        builder.Property(t => t.SecurityScoreSnapshotId)
            .IsRequired();
        
    }
}