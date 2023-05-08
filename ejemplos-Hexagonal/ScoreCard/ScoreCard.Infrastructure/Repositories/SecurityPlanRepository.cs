using Microsoft.EntityFrameworkCore;
using ScoreCard.Domain.Entities;
using ScoreCard.Domain.Interfaces;
using ScoreCard.Domain.Seed;

namespace ScoreCard.Infrastructure.Repositories;

public class SecurityPlanRepository : ISecurityPlanRepository
{
    private readonly ScoreCardDbContext _scoreCardDbContext;

    public SecurityPlanRepository(ScoreCardDbContext scoreCardDbContext)
    {
        _scoreCardDbContext = scoreCardDbContext;
    }

    public IUnitOfWork UnitOfWork => _scoreCardDbContext;
    public SecurityPlan Add(SecurityPlan securityPlan)
    {
        return _scoreCardDbContext.SecurityPlans.Add(securityPlan).Entity;
    }

    public async Task<List<SecurityPlan>> GetAllAsync()
    {
        return await _scoreCardDbContext.SecurityPlans.ToListAsync();
    }

    public async Task<SecurityPlan> GetByIdAsync(Guid Id)
    {
        return (await _scoreCardDbContext.SecurityPlans.FirstOrDefaultAsync(x => x.Id == Id))!;
    }
    
    public SecurityPlan Update(SecurityPlan securityPlan)
    {
        return _scoreCardDbContext.SecurityPlans.Update(securityPlan).Entity;
    }

    public void Delete(SecurityPlan securityPlan)
    {
        _scoreCardDbContext.Remove(securityPlan);
    }
}