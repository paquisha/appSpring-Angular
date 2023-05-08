using ScoreCard.Application.Queries.CustomerQueries;

namespace ScoreCard.Worker.Dtos;

public class ReadCustomerWorkerRequest
{
    public ReadCustomersByIdsQuery ToApplicationRequest()
    {
        return new ReadCustomersByIdsQuery();
    }

}