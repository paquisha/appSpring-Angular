package com.ec.aekmot.curso.dao;

import com.ec.aekmot.curso.models.Usuario;

import java.util.List;

public interface UsuarioDao {

    List<Usuario> getUsuario();

    void elimnar(Long id);

    void actualizar(Usuario usuario);

    void registrar(Usuario usuario);

    Usuario verificarEmailPassword(Usuario usuario);
}
