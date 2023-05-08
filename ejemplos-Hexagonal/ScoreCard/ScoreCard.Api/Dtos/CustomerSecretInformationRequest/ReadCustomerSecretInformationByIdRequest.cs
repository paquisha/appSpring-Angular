using ScoreCard.Application.Queries.CustomerSecretInformationQueries;

namespace ScoreCard.Api.Dtos.CustomerSecretInformationRequest;

public class ReadCustomerSecretInformationByIdRequest
{
    public ReadCustomerSecretInformationByIdQuery ToApplicationRequest(Guid customerId)
    {
        return new ReadCustomerSecretInformationByIdQuery(customerId);
    }
}