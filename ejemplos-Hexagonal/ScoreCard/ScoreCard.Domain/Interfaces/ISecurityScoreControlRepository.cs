using ScoreCard.Domain.Entities;
using ScoreCard.Domain.Seed;

namespace ScoreCard.Domain.Interfaces;

public interface ISecurityScoreControlRepository: IRepository
{
    SecurityScoreControl Add(SecurityScoreControl securityScoreControl);
    Task<List<SecurityScoreControl>> GetAllAsync();
    Task<SecurityScoreControl> GetByIdAsync(Guid Id);
    SecurityScoreControl Update(SecurityScoreControl securityScoreControl);
    void Delete(SecurityScoreControl securityScoreControl);
}