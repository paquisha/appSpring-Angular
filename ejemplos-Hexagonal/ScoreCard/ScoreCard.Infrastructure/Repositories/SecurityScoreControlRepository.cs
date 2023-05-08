using Microsoft.EntityFrameworkCore;
using ScoreCard.Domain.Entities;
using ScoreCard.Domain.Interfaces;
using ScoreCard.Domain.Seed;

namespace ScoreCard.Infrastructure.Repositories;

public class SecurityScoreControlRepository : ISecurityScoreControlRepository
{
    
    private readonly ScoreCardDbContext _scoreCardDbContext;

    public SecurityScoreControlRepository(ScoreCardDbContext scoreCardDbContext)
    {
        _scoreCardDbContext = scoreCardDbContext;
    }

    public IUnitOfWork UnitOfWork => _scoreCardDbContext;

    public SecurityScoreControl Add(SecurityScoreControl securityScoreControl)
    {
        return _scoreCardDbContext.SecurityScoreControls.Add(securityScoreControl).Entity;
    }

    public async Task<List<SecurityScoreControl>> GetAllAsync()
    {
        return await _scoreCardDbContext.SecurityScoreControls.ToListAsync();
    }

    public async Task<SecurityScoreControl> GetByIdAsync(Guid Id)
    {
        return (await _scoreCardDbContext.SecurityScoreControls.FirstOrDefaultAsync(x => x.Id == Id))!;
    }
    
    public SecurityScoreControl Update(SecurityScoreControl securityScoreControl)
    {
        return _scoreCardDbContext.SecurityScoreControls.Update(securityScoreControl).Entity;
    }

    public void Delete(SecurityScoreControl securityScoreControl)
    {
        _scoreCardDbContext.SecurityScoreControls.Remove(securityScoreControl);
    }
}