using ScoreCard.Domain.Entities;
using ScoreCard.Domain.Seed;

namespace ScoreCard.Domain.Interfaces;

public interface ISecureScoreRepository: IRepository
{
    SecureScore Add(SecureScore secureScore);
    Task<List<SecureScore>> GetAllAsync();
    Task<SecureScore> GetByIdAsync(Guid Id);
    SecureScore Update(SecureScore secureScore);
    void Delete(SecureScore secureScore);
}