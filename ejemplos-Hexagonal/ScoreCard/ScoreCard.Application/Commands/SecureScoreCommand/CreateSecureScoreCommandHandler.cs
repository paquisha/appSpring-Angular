using MediatR;
using Microsoft.Extensions.Logging;
using ScoreCard.Domain.Entities;
using ScoreCard.Domain.Interfaces;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Commands.SecureScoreCommand;

public class CreateSecureScoreCommandHandler : IRequestHandler<CreateSecureScoreCommand,
    EntityResponse<bool>>
{
    private readonly ILogger<CreateSecureScoreCommandHandler> _logger;
    private readonly ISecureScoreRepository _secureScore;
    private readonly IMediator _mediator;

    public CreateSecureScoreCommandHandler(ILogger<CreateSecureScoreCommandHandler>
        logger, ISecureScoreRepository secureScore, IMediator mediator)
    {
        _logger = logger;
        _secureScore = secureScore;
        _mediator = mediator;
    }

    public async Task<EntityResponse<bool>> Handle(CreateSecureScoreCommand command,
        CancellationToken cancellationToken)

    {
        var secureScore = new SecureScore(command.Tenantid, command.SubscriptionId, command.PercentageScore,
            command.CurrentScore, command.MaxScore, command.Weight, command.SecurityScoreSnapshotId);
        _secureScore.Add(secureScore);
        await _secureScore.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        return EntityResponse.Success(true);
    }
}