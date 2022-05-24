package ec.com.aekmot.sistema.angular.models.services;

import ec.com.aekmot.sistema.angular.models.entity.Cliente;

import java.util.List;

public interface IClienteService {

    public List<Cliente> findAll();

    public Cliente findById(Long id);

    public Cliente save (Cliente cliente);

    public void delete(Long id);
}
