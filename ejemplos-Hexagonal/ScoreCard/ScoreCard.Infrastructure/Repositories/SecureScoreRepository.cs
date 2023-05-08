using Microsoft.EntityFrameworkCore;
using ScoreCard.Domain.Entities;
using ScoreCard.Domain.Interfaces;
using ScoreCard.Domain.Seed;

namespace ScoreCard.Infrastructure.Repositories;

public class SecureScoreRepository : ISecureScoreRepository
{
    private readonly ScoreCardDbContext _scoreCardDbContext;

    public SecureScoreRepository(ScoreCardDbContext scoreCardDbContext)
    {
        _scoreCardDbContext = scoreCardDbContext;
    }

    public IUnitOfWork UnitOfWork => _scoreCardDbContext;
    public SecureScore Add(SecureScore secureScore)
    {
        return _scoreCardDbContext.SecureScores.Add(secureScore).Entity;
    }

    public async Task<List<SecureScore>> GetAllAsync()
    {
        return await _scoreCardDbContext.SecureScores.ToListAsync();
    }

    public async Task<SecureScore> GetByIdAsync(Guid Id)
    {
        return (await _scoreCardDbContext.SecureScores.FirstOrDefaultAsync(x => x.Id == Id))!;
    }
    
    public SecureScore Update(SecureScore secureScore)
    {
        return _scoreCardDbContext.SecureScores.Update(secureScore).Entity;
    }

    public void Delete(SecureScore secureScore)
    {
        _scoreCardDbContext.Remove(secureScore);
    }
}