using ScoreCard.Application.Commands.CustomerSecretInformationCommand;

namespace ScoreCard.Api.Dtos.CustomerSecretInformationRequest;

public class CreateCustomerSecretInformationRequest
{
    public string? TenantId { get; set; }
    public string? ClientSecret { get; set; }
    public string? ApplicationId { get; set; }
    public Guid CustomerId { get; set; }

    public CreateCustomerSecretInformationRequest(string? tenantId, string? clientSecret, string? applicationId,
        Guid customerId)
    {
        TenantId = tenantId;
        ClientSecret = clientSecret;
        ApplicationId = applicationId;
        CustomerId = customerId;
    }
    public CreateCustomerSecretInformationCommand ToApplicationRequest()
    {
        return new CreateCustomerSecretInformationCommand(TenantId, ClientSecret,ApplicationId, CustomerId);
    }
}