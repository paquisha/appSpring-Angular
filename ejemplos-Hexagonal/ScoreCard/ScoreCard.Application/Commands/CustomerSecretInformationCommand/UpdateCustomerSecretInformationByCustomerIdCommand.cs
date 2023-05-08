using MediatR;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Commands.CustomerSecretInformationCommand;

public class UpdateCustomerSecretInformationByCustomerIdCommand : IRequest<EntityResponse<bool>>
{
    public string? TenantId { get; set; }
    public string? ClientSecret { get; set; }
    public string? ApplicationId { get; set; }
    public Guid CustomerId { get; set; }

    public UpdateCustomerSecretInformationByCustomerIdCommand(string? tenantId, string? clientSecret,
        string? applicationId, Guid customerId)
    {
        TenantId = tenantId;
        ClientSecret = clientSecret;
        ApplicationId = applicationId;
        CustomerId = customerId;
    }
}