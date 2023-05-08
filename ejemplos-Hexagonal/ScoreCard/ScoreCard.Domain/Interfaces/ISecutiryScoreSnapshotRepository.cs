using ScoreCard.Domain.Entities;
using ScoreCard.Domain.Seed;

namespace ScoreCard.Domain.Interfaces;

public interface ISecutiryScoreSnapshotRepository: IRepository
{
    SecurityScoreSnapshot Add(SecurityScoreSnapshot securityScoreSnapshot);
    Task<List<SecurityScoreSnapshot>> GetAllAsync();
    Task<SecurityScoreSnapshot> GetByIdAsync(Guid Id);
    SecurityScoreSnapshot Update(SecurityScoreSnapshot securityScoreSnapshot);
    void Delete(SecurityScoreSnapshot securityScoreSnapshot);
    
    
}