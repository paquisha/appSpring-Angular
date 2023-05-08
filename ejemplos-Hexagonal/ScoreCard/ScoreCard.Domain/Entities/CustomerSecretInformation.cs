using ScoreCard.Domain.Seed;

namespace ScoreCard.Domain.Entities;

public class CustomerSecretInformation : BaseEntity
{
    public string? TenantId { get; set; }
    public string? ClientSecret { get; set; }
    public string? ApplicationId { get; set; }
    public Guid CustomerId { get; set; }

    protected CustomerSecretInformation()
    {
        Id = Guid.NewGuid();
    }

    public CustomerSecretInformation(string tenantId, string clientSecret, string applicationId, Guid customerId)
    {
        TenantId = tenantId;
        ClientSecret = clientSecret;
        ApplicationId = applicationId;
        CustomerId = customerId;
    }
}