using ScoreCard.Application.Queries.CustomerSecretInformationQueries;

namespace ScoreCard.Api.Dtos.CustomerSecretInformationRequest;

public class ReadCustomersSecretInformationRequest
{
    public ReadCustomersSecretInformationQuery ToApplicationRequest()
    {
        return new ReadCustomersSecretInformationQuery();
    }
}