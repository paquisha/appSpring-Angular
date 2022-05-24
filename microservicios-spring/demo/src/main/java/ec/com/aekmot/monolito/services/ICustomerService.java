package ec.com.aekmot.monolito.services;

import ec.com.aekmot.monolito.entities.Customer;

import java.util.List;

public interface ICustomerService {
    List<Customer> getAll();
    Customer getById(Long id);
    void remove(Long id);
    void save(Customer customer);
}
