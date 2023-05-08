using ScoreCard.Domain.Entities;
using ScoreCard.Domain.Seed;

namespace ScoreCard.Domain.Interfaces;

public interface ISecurityStandardRepository: IRepository
{
    SecurityStandard Add(SecurityStandard securityStandard);
    Task<List<SecurityStandard>> GetAllAsync();
    Task<SecurityStandard> GetByIdAsync(Guid Id);
    SecurityStandard Update(SecurityStandard securityStandard);
    void Delete(SecurityStandard securityStandard);
}