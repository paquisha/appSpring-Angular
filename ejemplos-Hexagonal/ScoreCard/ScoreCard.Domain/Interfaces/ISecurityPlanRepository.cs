using ScoreCard.Domain.Entities;
using ScoreCard.Domain.Seed;

namespace ScoreCard.Domain.Interfaces;

public interface ISecurityPlanRepository: IRepository
{
    SecurityPlan Add(SecurityPlan securityPlan);
    Task<List<SecurityPlan>> GetAllAsync();
    Task<SecurityPlan> GetByIdAsync(Guid Id);
    SecurityPlan Update(SecurityPlan securityPlan);
    void Delete(SecurityPlan securityPlan);
}