using ScoreCard.Application.Queries.CustomerSecretInformationQueries;

namespace ScoreCard.Api.Dtos.CustomerSecretInformationRequest;

public class ReadCustomerSecretInformationRequest
{
    public ReadCustomerSecretInformationQuery ToApplicationRequest(Guid id)
    {
        return new ReadCustomerSecretInformationQuery(id);
    }

}