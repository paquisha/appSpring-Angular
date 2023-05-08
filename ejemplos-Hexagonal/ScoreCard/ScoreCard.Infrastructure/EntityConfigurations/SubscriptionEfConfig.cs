using Microsoft.EntityFrameworkCore;
using ScoreCard.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ScoreCard.Infrastructure.EntityConfigurations;

public class SubscriptionEfConfig : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.ToTable(nameof(Subscription));

        builder.HasKey(t => t.Id);
        builder.Ignore(t => t.DomainEvents);

        builder.Property(t => t.Name)
            .HasMaxLength(255)
            .IsRequired();
        builder.Property(t => t.SubscriptionId)
            .HasMaxLength(255)
            .IsRequired();
        builder.Property(t => t.CustomerId)
            .IsRequired();
        builder.Metadata.FindNavigation(nameof(Subscription.SecurityScoreSnapshots))
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}