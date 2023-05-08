using ScoreCard.Domain.Entities;
using ScoreCard.Domain.Seed;

namespace ScoreCard.Domain.Interfaces;

public interface IControlRecommendationIdRepository: IRepository
{
    ControlRecommendationId Add(ControlRecommendationId controlRecommendationId);
    Task<List<ControlRecommendationId>> GetAllAsync();
    Task<ControlRecommendationId> GetByIdAsync(Guid Id);
    ControlRecommendationId Update(ControlRecommendationId controlRecommendationId);
    void Delete(ControlRecommendationId controlRecommendationId);
}