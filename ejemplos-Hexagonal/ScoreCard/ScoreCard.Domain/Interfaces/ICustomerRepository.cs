using ScoreCard.Domain.Entities;
using ScoreCard.Domain.Seed;

namespace ScoreCard.Domain.Interfaces;

public interface  ICustomerRepository: IRepository
{
    Customer Add(Customer customer);
    Task<List<Customer>> GetAllAsync();
    Task<Customer> GetByIdAsync(Guid Id);
    Task<List<Customer>> GetByName(string Name);
    Customer Update(Customer customer);
    void Delete(Customer customer);
    Task<List<Customer>> GetActiveCustomers();
}