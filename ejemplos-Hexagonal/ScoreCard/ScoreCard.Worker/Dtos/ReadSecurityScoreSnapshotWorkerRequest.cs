using ScoreCard.Application.Queries.SecurityScoreSnapshotQueries;

namespace ScoreCard.Worker.Dtos;

public class ReadSecurityScoreSnapshotWorkerRequest
{
    public ReadSecurityScoreSnapshotsQuery ToApplicationRequest()
    {
        return new ReadSecurityScoreSnapshotsQuery();
    }
}