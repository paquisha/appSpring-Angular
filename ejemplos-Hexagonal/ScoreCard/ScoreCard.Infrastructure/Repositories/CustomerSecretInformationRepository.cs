using Microsoft.EntityFrameworkCore;
using ScoreCard.Domain.Entities;
using ScoreCard.Domain.Interfaces;
using ScoreCard.Domain.Seed;

namespace ScoreCard.Infrastructure.Repositories;

public class CustomerSecretInformationRepository : ICustomerSecretInformationRepository
{
    private readonly ScoreCardDbContext _scoreCardDbContext;

    public CustomerSecretInformationRepository(ScoreCardDbContext scoreCardDbContext)
    {
        _scoreCardDbContext = scoreCardDbContext;
    }

    public IUnitOfWork UnitOfWork => _scoreCardDbContext;

    public CustomerSecretInformation Add(CustomerSecretInformation customerSecretInformation)
    {
        return _scoreCardDbContext.CustomerSecretInformations.Add(customerSecretInformation).Entity;
    }

    public async Task<List<CustomerSecretInformation>> GetAllAsync()
    {
        return await _scoreCardDbContext.CustomerSecretInformations.ToListAsync();
    }

    public async Task<CustomerSecretInformation> GetByIdAsync(Guid Id)
    {
        return (await _scoreCardDbContext.CustomerSecretInformations.FirstOrDefaultAsync(x => x.Id == Id))!;
    }

    public CustomerSecretInformation Update(CustomerSecretInformation customerSecretInformation)
    {
        return _scoreCardDbContext.CustomerSecretInformations.Update(customerSecretInformation).Entity;
    }

    public CustomerSecretInformation UpdateByCustomerId(CustomerSecretInformation customerSecretInformation)
    {
        return _scoreCardDbContext.CustomerSecretInformations.Update(customerSecretInformation).Entity;
    }

    public void Delete(CustomerSecretInformation customerSecretInformation)
    {
        _scoreCardDbContext.CustomerSecretInformations.Remove(customerSecretInformation);
    }

    public async Task<CustomerSecretInformation> GetByCustomerIdAsync(Guid Id)
    {
        return (await _scoreCardDbContext.CustomerSecretInformations.FirstOrDefaultAsync(x => x.CustomerId == Id))!;
    }

    public async Task<List<CustomerSecretInformation>> GetByCustomerIds(List<Guid> ids)
    {
        return await _scoreCardDbContext.CustomerSecretInformations.Where(x => ids.Contains(x.CustomerId))
            .ToListAsync();
    }
}