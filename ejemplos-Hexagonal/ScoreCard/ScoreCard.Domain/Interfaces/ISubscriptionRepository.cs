using ScoreCard.Domain.Entities;
using ScoreCard.Domain.Seed;

namespace ScoreCard.Domain.Interfaces;

public interface ISubscriptionRepository: IRepository
{
    Subscription Add(Subscription subscription);
    Task<List<Subscription>> GetAllAsync();
    Task<Subscription> GetByIdAsync(Guid Id);
    Task<List<Subscription>> GetByCustomerIdAsync(Guid Id);
    Subscription Update(Subscription subscription);
    void Delete(Subscription subscription);
}