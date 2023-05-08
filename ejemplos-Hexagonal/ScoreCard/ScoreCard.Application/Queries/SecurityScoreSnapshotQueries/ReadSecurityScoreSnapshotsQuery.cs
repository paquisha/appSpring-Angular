using MediatR;
using ScoreCard.Application.Dtos.Responses;
using ScoreCard.Domain.Models;

namespace ScoreCard.Application.Queries.SecurityScoreSnapshotQueries;

public class ReadSecurityScoreSnapshotsQuery : IRequest<EntityResponse<List<SecurityScoreSnapshotResponse>>>
{
    
}