using MediatR;
using Microsoft.Extensions.Logging;
using ScoreCard.Application.Dtos.Responses;
using ScoreCard.Domain.Interfaces;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Queries.SecurityScoreSnapshotQueries;

public class ReadSecurityScoreSnapshotsQueryHandler : IRequestHandler<ReadSecurityScoreSnapshotsQuery,
    EntityResponse<List<SecurityScoreSnapshotResponse>>>
{
    private readonly ILogger<ReadSecurityScoreSnapshotsQueryHandler> _logger;
    private readonly ISecutiryScoreSnapshotRepository _secutiryScoreSnapshotRepository;


    public ReadSecurityScoreSnapshotsQueryHandler(ILogger<ReadSecurityScoreSnapshotsQueryHandler> logger,
        ISecutiryScoreSnapshotRepository secutiryScoreSnapshotRepository)
    {
        _logger = logger;
        _secutiryScoreSnapshotRepository = secutiryScoreSnapshotRepository;
    }

    public async Task<EntityResponse<List<SecurityScoreSnapshotResponse>>> Handle(
        ReadSecurityScoreSnapshotsQuery request,
        CancellationToken cancellationToken)
    {
        var customers = await _secutiryScoreSnapshotRepository.GetAllAsync();
        _logger.Log(LogLevel.Information, "Get Customers", customers);
        if (customers.Count == 0)
        {
            return EntityResponse<List<SecurityScoreSnapshotResponse>>.Error("Doesn't exist customers");
        }

        return EntityResponse.Success(customers.Select(x =>
            new SecurityScoreSnapshotResponse(x.Id, x.SnapshotDate, x.CustomerId, x.SubscriptionId)).ToList());
    }
}