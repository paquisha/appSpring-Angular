using ScoreCard.Application.Queries.CustomerQueries;

namespace ScoreCard.Api.Dtos.CustomerRequest
{
    public class ReadCustomerRequest
    {
        public ReadCustomerQuery ToApplicationRequest(Guid id)
        {
            return new ReadCustomerQuery(id);
        }
    }
}
