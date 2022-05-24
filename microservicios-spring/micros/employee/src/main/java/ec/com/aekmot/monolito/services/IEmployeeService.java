package ec.com.aekmot.monolito.services;

import ec.com.aekmot.monolito.entities.Employee;

import java.util.List;

public interface IEmployeeService {
    List<Employee> getAll();
    Employee getById(Long id);
    void remove(Long id);
    void save(Employee employee);
}
