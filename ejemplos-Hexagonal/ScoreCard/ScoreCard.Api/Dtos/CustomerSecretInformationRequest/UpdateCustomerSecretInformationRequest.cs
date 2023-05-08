using ScoreCard.Application.Commands.CustomerSecretInformationCommand;

namespace ScoreCard.Api.Dtos.CustomerSecretInformationRequest;

public class UpdateCustomerSecretInformationRequest
{
    public string? TenantId { get; set; }
    public string? ClientSecret { get; set; }
    public string? ApplicationId { get; set; }
    public Guid CustomerId { get; set; }
    

    public UpdateCustomerSecretInformationRequest(string tenantId, string clientSecret, string applicationId, Guid customerId)
    {
        TenantId = tenantId;
        ClientSecret = clientSecret;
        ApplicationId = applicationId;
        CustomerId = customerId;
    }

    public UpdateCustomerSecretInformationCommand ToApplicationRequest(Guid id)
    {
        return new UpdateCustomerSecretInformationCommand(id, TenantId, ClientSecret, ApplicationId, CustomerId);
    }
}