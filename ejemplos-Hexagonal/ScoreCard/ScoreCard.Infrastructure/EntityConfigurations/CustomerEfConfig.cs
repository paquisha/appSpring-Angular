using Microsoft.EntityFrameworkCore;
using ScoreCard.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ScoreCard.Infrastructure.EntityConfigurations;

public class CustomerEfConfig : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable(nameof(Customer));
        
        builder.HasKey(t => t.Id);
        
        builder.Ignore(t => t.DomainEvents);
        
        builder.Property(t => t.Name)
            .HasMaxLength(255)
            .IsRequired();
        
        builder.Property(t => t.IsActive)
            .IsRequired();

        builder.HasOne(x => x.CustomerSecretInformation)
            .WithOne()
            .HasForeignKey<CustomerSecretInformation>(t => t.CustomerId);
        builder.Metadata.FindNavigation(nameof(Customer.Subscriptions))
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}