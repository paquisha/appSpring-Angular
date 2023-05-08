using Microsoft.EntityFrameworkCore;
using ScoreCard.Domain.Entities;
using ScoreCard.Domain.Interfaces;
using ScoreCard.Domain.Seed;

namespace ScoreCard.Infrastructure.Repositories;

public class ControlRecommendationIdRepository : IControlRecommendationIdRepository
{
    private readonly ScoreCardDbContext _scoreCardDbContext;

    public ControlRecommendationIdRepository(ScoreCardDbContext scoreCardDbContext)
    {
        _scoreCardDbContext = scoreCardDbContext;
    }

    public IUnitOfWork UnitOfWork => _scoreCardDbContext;
    public ControlRecommendationId Add(ControlRecommendationId controlRecommendationId)
    {
        return _scoreCardDbContext.ControlRecommendationIds.Add(controlRecommendationId).Entity;
    }

    public async Task<List<ControlRecommendationId>> GetAllAsync()
    {
        return await _scoreCardDbContext.ControlRecommendationIds.ToListAsync();
    }

    public async Task<ControlRecommendationId> GetByIdAsync(Guid Id)
    {
        return (await _scoreCardDbContext.ControlRecommendationIds.FirstOrDefaultAsync(x => x.Id == Id));
    }

    public ControlRecommendationId Update(ControlRecommendationId controlRecommendationId)
    {
        return _scoreCardDbContext.ControlRecommendationIds.Update(controlRecommendationId).Entity;
    }

    public void Delete(ControlRecommendationId controlRecommendationId)
    {
        _scoreCardDbContext.ControlRecommendationIds.Remove(controlRecommendationId);
    }
}
