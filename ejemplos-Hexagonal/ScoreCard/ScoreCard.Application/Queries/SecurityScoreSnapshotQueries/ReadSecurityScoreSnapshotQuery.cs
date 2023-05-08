using MediatR;
using ScoreCard.Application.Dtos.Responses;

namespace ScoreCard.Application.Queries.SecurityScoreSnapshotQueries;

public class ReadSecurityScoreSnapshotQuery : IRequest<SecurityScoreSnapshotResponse>
{
    public Guid Id { get; set; }

    public ReadSecurityScoreSnapshotQuery(Guid id)
    {
        Id = id;
    }
}