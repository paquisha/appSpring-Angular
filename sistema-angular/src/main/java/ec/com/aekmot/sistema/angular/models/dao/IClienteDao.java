package ec.com.aekmot.sistema.angular.models.dao;

import ec.com.aekmot.sistema.angular.models.entity.Cliente;
import org.springframework.data.repository.CrudRepository;

public interface IClienteDao extends CrudRepository<Cliente, Long> {
}
