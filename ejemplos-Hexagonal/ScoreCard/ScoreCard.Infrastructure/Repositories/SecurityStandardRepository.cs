using Microsoft.EntityFrameworkCore;
using ScoreCard.Domain.Entities;
using ScoreCard.Domain.Interfaces;
using ScoreCard.Domain.Seed;

namespace ScoreCard.Infrastructure.Repositories;

public class SecurityStandardRepository: ISecurityStandardRepository
{
    private readonly ScoreCardDbContext _scoreCardDbContext;

    public SecurityStandardRepository(ScoreCardDbContext scoreCardDbContext)
    {
        _scoreCardDbContext = scoreCardDbContext;
    }

    public IUnitOfWork UnitOfWork => _scoreCardDbContext;

    public SecurityStandard Add(SecurityStandard securityStandard)
    {
        return _scoreCardDbContext.SecurityStandards.Add(securityStandard).Entity;

    }

    public async Task<List<SecurityStandard>> GetAllAsync()
    {
        return await _scoreCardDbContext.SecurityStandards.ToListAsync();

    }

    public async Task<SecurityStandard> GetByIdAsync(Guid Id)
    {
        return (await _scoreCardDbContext.SecurityStandards.FirstOrDefaultAsync(x => x.Id == Id))!;

    }

    public SecurityStandard Update(SecurityStandard securityStandard)
    {
        return _scoreCardDbContext.SecurityStandards.Update(securityStandard).Entity;

    }

    public void Delete(SecurityStandard securityStandard)
    {
        _scoreCardDbContext.SecurityStandards.Remove(securityStandard);
    }
}