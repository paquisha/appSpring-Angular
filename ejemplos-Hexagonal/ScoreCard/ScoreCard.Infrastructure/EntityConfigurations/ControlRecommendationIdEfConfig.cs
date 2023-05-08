using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScoreCard.Domain.Entities;

namespace ScoreCard.Infrastructure.EntityConfigurations;

public class ControlRecommendationIdEfConfig: IEntityTypeConfiguration<ControlRecommendationId>
{
    public void Configure(EntityTypeBuilder<ControlRecommendationId> builder)
    {
        builder.ToTable(nameof(ControlRecommendationId));
        builder.HasKey(t => t.Id);
        builder.Ignore(t => t.DomainEvents);
        builder.Property(t => t.ControlRemediationId)
            .HasMaxLength(255);
        builder.Property(t => t.SecurityScoreSnapshotId)
            .IsRequired();
        
    }
}