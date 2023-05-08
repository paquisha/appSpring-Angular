using Microsoft.EntityFrameworkCore;
using ScoreCard.Domain.Entities;
using ScoreCard.Domain.Interfaces;
using ScoreCard.Domain.Seed;

namespace ScoreCard.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ScoreCardDbContext _scoreCardDbContext;

    public CustomerRepository(ScoreCardDbContext scoreCardDbContext)
    {
        _scoreCardDbContext = scoreCardDbContext;
    }

    public IUnitOfWork UnitOfWork => _scoreCardDbContext;

    public Customer Add(Customer customer)
    {
        return _scoreCardDbContext.Customers.Add(customer).Entity;
    }

    public async Task<List<Customer>> GetAllAsync()
    {
        return await _scoreCardDbContext.Customers.ToListAsync();
    }

    public async Task<Customer> GetByIdAsync(Guid Id)
    {
        return (await _scoreCardDbContext.Customers.FirstOrDefaultAsync(x => x.Id == Id))!;
    }

    public async Task<List<Customer>> GetByName(string Name)
    {
        var customerList = await _scoreCardDbContext.Customers.Where(x => x.Name.Contains(Name)).ToListAsync();
        return customerList;
    }

    public Customer Update(Customer customer)
    {
        return _scoreCardDbContext.Customers.Update(customer).Entity;
    }

    public void Delete(Customer customer)
    {
        _scoreCardDbContext.Customers.Remove(customer);
    }
    
    public async Task<List<Customer>> GetActiveCustomers()
    {
        var customerList = await _scoreCardDbContext.Customers.Include(y=>y.CustomerSecretInformation).Include(z => z.Subscriptions).ThenInclude(w => w.SecurityScoreSnapshots).Where(x => x.IsActive).ToListAsync();
        return customerList;
    }
    
}