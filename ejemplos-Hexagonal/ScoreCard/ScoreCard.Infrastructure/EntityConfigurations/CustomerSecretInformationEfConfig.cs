using Microsoft.EntityFrameworkCore;
using ScoreCard.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ScoreCard.Infrastructure.EntityConfigurations;

public class CustomerSecretInformationEfConfig : IEntityTypeConfiguration<CustomerSecretInformation>
{
    public void Configure(EntityTypeBuilder<CustomerSecretInformation> builder)
    {
        builder.ToTable(nameof(CustomerSecretInformation));

        builder.HasKey(t => t.Id);
        builder.Ignore(t => t.DomainEvents);
        builder.Property(t => t.TenantId)
            .HasMaxLength(255);
        builder.Property(t => t.ClientSecret)
            .HasMaxLength(255);
        builder.Property(t => t.ApplicationId)
            .HasMaxLength(255);
        builder.Property(t => t.CustomerId)
            .IsRequired();
    }
}
