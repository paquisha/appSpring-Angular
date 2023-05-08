namespace ScoreCard.Application.Dtos.Responses;

public class CustomerSecretInformationResponse
{
    public Guid Id { get; set; }
    public string? TenantId { get; set; }
    public string? ClientSecret { get; set; }
    public string? ApplicationId { get; set; }
    public Guid CustomerId { get; set; }

    public CustomerSecretInformationResponse(Guid id, string? tenantId, string? clientSecret, string? applicationId,
        Guid customerId)
    {
        Id = id;
        TenantId = tenantId;
        ClientSecret = clientSecret;
        ApplicationId = applicationId;
        CustomerId = customerId;
    }
}