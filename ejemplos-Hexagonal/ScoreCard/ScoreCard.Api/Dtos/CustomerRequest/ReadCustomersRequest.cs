using ScoreCard.Application.Queries.CustomerQueries;

namespace ScoreCard.Api.Dtos.CustomerRequest;

public class ReadCustomersRequest
{
    public ReadCustomersQuery ToApplicationRequest()
    {
        return new ReadCustomersQuery();
    }    
}