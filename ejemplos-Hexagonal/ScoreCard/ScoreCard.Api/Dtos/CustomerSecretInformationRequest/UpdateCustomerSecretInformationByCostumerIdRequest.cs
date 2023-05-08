using ScoreCard.Application.Commands.CustomerSecretInformationCommand;

namespace ScoreCard.Api.Dtos.CustomerSecretInformationRequest;

public class UpdateCustomerSecretInformationByCostumerIdRequest
{
    public string? TenantId { get; set; }
    public string? ClientSecret { get; set; }
    public string? ApplicationId { get; set; }

    public UpdateCustomerSecretInformationByCostumerIdRequest(string tenantId, string clientSecret,
        string applicationId)
    {
        TenantId = tenantId;
        ClientSecret = clientSecret;
        ApplicationId = applicationId;
    }

    public UpdateCustomerSecretInformationByCustomerIdCommand ToApplicationRequest(Guid customerId)
    {
        return new UpdateCustomerSecretInformationByCustomerIdCommand(TenantId, ClientSecret, ApplicationId,
            customerId);
    }
}