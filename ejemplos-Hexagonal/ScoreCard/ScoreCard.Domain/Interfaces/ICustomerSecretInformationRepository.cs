using ScoreCard.Domain.Entities;
using ScoreCard.Domain.Seed;

namespace ScoreCard.Domain.Interfaces;

public interface ICustomerSecretInformationRepository: IRepository
{
    CustomerSecretInformation Add(CustomerSecretInformation customerSecretInformation);
    Task<List<CustomerSecretInformation>> GetAllAsync();
    Task<CustomerSecretInformation> GetByIdAsync(Guid id);
    CustomerSecretInformation Update(CustomerSecretInformation customerSecretInformation);
    CustomerSecretInformation UpdateByCustomerId(CustomerSecretInformation customerSecretInformation);
    void Delete(CustomerSecretInformation customerSecretInformation);
    Task<CustomerSecretInformation> GetByCustomerIdAsync(Guid id);
    Task<List<CustomerSecretInformation>> GetByCustomerIds(List<Guid> ids);
    
    
}