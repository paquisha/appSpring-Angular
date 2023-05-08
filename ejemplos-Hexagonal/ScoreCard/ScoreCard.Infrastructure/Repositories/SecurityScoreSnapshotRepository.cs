using Microsoft.EntityFrameworkCore;
using ScoreCard.Domain.Entities;
using ScoreCard.Domain.Interfaces;
using ScoreCard.Domain.Seed;

namespace ScoreCard.Infrastructure.Repositories;

public class SecurityScoreSnapshotRepository : ISecutiryScoreSnapshotRepository
{
    private readonly ScoreCardDbContext _scoreCardDbContext;

    public SecurityScoreSnapshotRepository(ScoreCardDbContext scoreCardDbContext)
    {
        _scoreCardDbContext = scoreCardDbContext;
    }

    public IUnitOfWork UnitOfWork => _scoreCardDbContext;

    public SecurityScoreSnapshot Add(SecurityScoreSnapshot securityScoreSnapshot)
    {
        return _scoreCardDbContext.SecurityScoreSnapshots.Add(securityScoreSnapshot).Entity;
    }

    public async Task<List<SecurityScoreSnapshot>> GetAllAsync()
    {
        return await _scoreCardDbContext.SecurityScoreSnapshots.ToListAsync();
    }

    public async Task<SecurityScoreSnapshot> GetByIdAsync(Guid Id)
    {
        return (await _scoreCardDbContext.SecurityScoreSnapshots.FirstOrDefaultAsync(x => x.Id == Id))!;
    }

    public SecurityScoreSnapshot Update(SecurityScoreSnapshot securityScoreSnapshot)
    {
        return _scoreCardDbContext.SecurityScoreSnapshots.Update(securityScoreSnapshot).Entity;
    }

    public void Delete(SecurityScoreSnapshot securityScoreSnapshot)
    {
        _scoreCardDbContext.SecurityScoreSnapshots.Remove(securityScoreSnapshot);
    }
}