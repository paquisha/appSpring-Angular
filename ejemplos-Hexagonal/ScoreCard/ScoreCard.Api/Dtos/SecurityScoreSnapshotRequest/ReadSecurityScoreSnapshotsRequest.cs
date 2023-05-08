using ScoreCard.Application.Queries.SecurityScoreSnapshotQueries;

namespace ScoreCard.Api.Dtos.SecurityScoreSnapshotRequest;

public class ReadSecurityScoreSnapshotsRequest
{
    public ReadSecurityScoreSnapshotsQuery ToApplicationRequest()
    {
        return new ReadSecurityScoreSnapshotsQuery();
    }
}