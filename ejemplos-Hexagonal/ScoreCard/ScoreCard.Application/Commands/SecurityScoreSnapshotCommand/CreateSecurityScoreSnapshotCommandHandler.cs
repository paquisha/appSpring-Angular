using MediatR;
using Microsoft.Extensions.Logging;
using ScoreCard.Domain.Entities;
using ScoreCard.Domain.Interfaces;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Commands.SecurityScoreSnapshotCommand;

public class CreateSecurityScoreSnapshotCommandHandler: IRequestHandler<CreateSecurityScoreSnapshotCommand,
    EntityResponse<bool>>
{
    private readonly ILogger<CreateSecurityScoreSnapshotCommandHandler> _logger;
    private readonly ISecutiryScoreSnapshotRepository _securityScoreSnapshot;
    private readonly IMediator _mediator;

    public CreateSecurityScoreSnapshotCommandHandler(ILogger<CreateSecurityScoreSnapshotCommandHandler> logger, ISecutiryScoreSnapshotRepository securityScoreSnapshot, IMediator mediator)
    {
        _logger = logger;
        _securityScoreSnapshot = securityScoreSnapshot;
        _mediator = mediator;
    }

    public async Task<EntityResponse<bool>> Handle(CreateSecurityScoreSnapshotCommand command,
        CancellationToken cancellationToken)

    {
        var securityScoreSnapshot = new SecurityScoreSnapshot(command.SnapshotDate, command.CustomerId, command.SubscriptionId);
        _securityScoreSnapshot.Add(securityScoreSnapshot);
        await _securityScoreSnapshot.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        return EntityResponse.Success(true);
    }
}
