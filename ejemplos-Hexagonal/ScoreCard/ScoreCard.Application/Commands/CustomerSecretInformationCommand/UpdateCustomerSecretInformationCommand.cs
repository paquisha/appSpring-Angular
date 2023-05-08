using MediatR;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Commands.CustomerSecretInformationCommand;

public class UpdateCustomerSecretInformationCommand: IRequest<EntityResponse<bool>>
{
    public Guid Id { get; set; }
    public string? TenantId { get; set; }
    public string? ClientSecret { get; set; }
    public string? ApplicationId { get; set; }
    public Guid CustomerId { get; set; }

    public UpdateCustomerSecretInformationCommand(Guid id, string? tenantId, string? clientSecret,
        string? applicationId, Guid customerId)
    {
        Id = id;
        TenantId = tenantId;
        ClientSecret = clientSecret;
        ApplicationId = applicationId;
        CustomerId = customerId;
    }
}