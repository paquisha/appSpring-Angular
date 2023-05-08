using MediatR;
using Microsoft.Extensions.Logging;
using ScoreCard.Application.Dtos.Responses;
using ScoreCard.Domain.Interfaces;

namespace ScoreCard.Application.Queries.SecurityScoreSnapshotQueries;

public class ReadSecurityScoreSnapshotQueryHandler : IRequestHandler<ReadSecurityScoreSnapshotQuery, SecurityScoreSnapshotResponse>
{
    private readonly ILogger<ReadSecurityScoreSnapshotQuery> _logger;
    private readonly ISecutiryScoreSnapshotRepository _securityScoreSnapshotRepository;
    private readonly IMediator _mediator;

    public ReadSecurityScoreSnapshotQueryHandler(ILogger<ReadSecurityScoreSnapshotQuery> logger,
        ISecutiryScoreSnapshotRepository securityScoreSnapshotRepository, IMediator mediator)
    {
        _logger = logger;
        _securityScoreSnapshotRepository = securityScoreSnapshotRepository;
        _mediator = mediator;
    }

    public async Task<SecurityScoreSnapshotResponse> Handle(ReadSecurityScoreSnapshotQuery query,
        CancellationToken cancellationToken)
    {
        /////////TODO
        var securityScoreSnapshot = await _securityScoreSnapshotRepository.GetByIdAsync(query.Id);
        return new SecurityScoreSnapshotResponse(securityScoreSnapshot.Id, securityScoreSnapshot.SnapshotDate, securityScoreSnapshot.CustomerId, securityScoreSnapshot.SubscriptionId);

    }
}