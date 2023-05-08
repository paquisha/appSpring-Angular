using Microsoft.EntityFrameworkCore;
using ScoreCard.Domain.Entities;
using ScoreCard.Domain.Interfaces;
using ScoreCard.Domain.Seed;

namespace ScoreCard.Infrastructure.Repositories;

public class SubscriptionRepository: ISubscriptionRepository
{
    private readonly ScoreCardDbContext _scoreCardDbContext;

    public SubscriptionRepository(ScoreCardDbContext scoreCardDbContext)
    {
        _scoreCardDbContext = scoreCardDbContext;
    }

    public IUnitOfWork UnitOfWork => _scoreCardDbContext;
   
    public Subscription Add(Subscription subscription)
    {
        return _scoreCardDbContext.Subscriptions.Add(subscription).Entity;
    }

    public async Task<List<Subscription>> GetAllAsync()
    {
        return await _scoreCardDbContext.Subscriptions.ToListAsync();
    }

    public async Task<Subscription> GetByIdAsync(Guid Id)
    {
        return (await _scoreCardDbContext.Subscriptions.FirstOrDefaultAsync(x => x.Id == Id))!;

    }

    public async Task<List<Subscription>> GetByCustomerIdAsync(Guid Id)
    {
        var result = await _scoreCardDbContext.Subscriptions.Where(s => s.CustomerId == Id).ToListAsync();

        return (result);
    }

    public Subscription Update(Subscription subscription)
    {
        return _scoreCardDbContext.Subscriptions.Update(subscription).Entity;
 
    }

    public void Delete(Subscription subscription)
    {
        _scoreCardDbContext.Subscriptions.Remove(subscription);
    }
}