using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScoreCard.Domain.Entities;

namespace ScoreCard.Infrastructure.EntityConfigurations;

public class SecureScoreEfConfig: IEntityTypeConfiguration<SecureScore>
{
    public void Configure(EntityTypeBuilder<SecureScore> builder)
    {
        builder.ToTable(nameof(SecureScore));

        builder.HasKey(t => t.Id);
        builder.Ignore(t => t.DomainEvents);
        builder.Property(t => t.Tenantid)
            .HasMaxLength(255);
        builder.Property(t => t.SubscriptionId)
            .HasMaxLength(255);
        builder.Property(t => t.PercentageScore)
            .HasMaxLength(255);
        builder.Property(t => t.CurrentScore)
            .IsRequired();
        builder.Property(t => t.MaxScore)
            .IsRequired();
        builder.Property(t => t.Weight)
            .IsRequired();
        builder.Property(t => t.SecurityScoreSnapshotId)
            .IsRequired();


    }
}