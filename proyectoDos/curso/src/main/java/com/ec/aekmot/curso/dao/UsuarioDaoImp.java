package com.ec.aekmot.curso.dao;

import com.ec.aekmot.curso.models.Usuario;
import org.springframework.stereotype.Repository;

import java.util.List;


@Repository
@Transactional
public class UsuarioDaoImp implements UsuarioDao{

    @Override
    public List<Usuario> getUsuario() {
        return null;
    }
}
