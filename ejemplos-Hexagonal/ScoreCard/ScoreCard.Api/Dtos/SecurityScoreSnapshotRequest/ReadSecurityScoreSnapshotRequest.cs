using ScoreCard.Application.Queries.SecurityScoreSnapshotQueries;

namespace ScoreCard.Api.Dtos.SecurityScoreSnapshotRequest;

public class ReadSecurityScoreSnapshotRequest
{
    public ReadSecurityScoreSnapshotQuery ToApplicationRequest(Guid id)
    {
        return new ReadSecurityScoreSnapshotQuery(id);
    }
}