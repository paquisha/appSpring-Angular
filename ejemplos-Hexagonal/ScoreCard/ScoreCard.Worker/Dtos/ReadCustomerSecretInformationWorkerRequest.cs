using ScoreCard.Application.Queries.CustomerSecretInformationQueries;

namespace ScoreCard.Worker.Dtos;

public class ReadCustomerSecretInformationWorkerRequest
{
   public ReadCustomerSecretInformationByIdQuery ToApplicationRequest(Guid CustomerId)
      {
          return new ReadCustomerSecretInformationByIdQuery(CustomerId);
      }
}