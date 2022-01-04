package com.ec.aekmot.curso.controllers;

import com.ec.aekmot.curso.dao.UsuarioDao;
import com.ec.aekmot.curso.models.Usuario;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class UsuarioController {

    @Autowired
    private UsuarioDao usuarioDao;

    @RequestMapping(value= "api/usuarios")
    public List<Usuario> getUsuarios(){

        return usuarioDao.getUsuario();

        /*List<Usuario> usuarios = new ArrayList<>();
        Usuario usuario = new Usuario();
        usuario.setId(1L);
        usuario.setNombre("Aime");
        usuario.setApellido("Pachacama");
        usuario.setEmail("gina@mail.com");
        usuario.setTelefono("1234567890");

        Usuario usuarioUno = new Usuario();
        usuarioUno.setId(2L);
        usuarioUno.setNombre("Nathalia");
        usuarioUno.setApellido("Pachacama");
        usuarioUno.setEmail("iveth@mail.com");
        usuarioUno.setTelefono("0987654321");

        Usuario usuarioDos = new Usuario();
        usuarioDos.setId(3L);
        usuarioDos.setNombre("Evelyn");
        usuarioDos.setApellido("Benavides");
        usuarioDos.setEmail("evelyn@mail.com");
        usuarioDos.setTelefono("091287456");

        Usuario usuarioTres = new Usuario();
        usuarioTres.setId(4L);
        usuarioTres.setNombre("Grace");
        usuarioTres.setApellido("Chen");
        usuarioTres.setEmail("grace@mail.com");
        usuarioTres.setTelefono("1234567890");

        usuarios.add(usuario);
        usuarios.add(usuarioUno);
        usuarios.add(usuarioDos);
        usuarios.add(usuarioTres);

        return usuarios;*/
    }

    @RequestMapping(value = "api/usuario", method = RequestMethod.POST)
    public void registrarUsuario(@RequestBody Usuario usuario){
        usuarioDao.registrar(usuario);
    }

    @RequestMapping(value= "api/usuario/{id}")
    public Usuario getUnUsuario(@PathVariable Long id){
        Usuario usuario = new Usuario();
        usuario.setId(id);
        usuario.setNombre("Aime");
        usuario.setApellido("Pachacama");
        usuario.setEmail("gina@mail.com");
        usuario.setTelefono("1234567890");
        return usuario;
    }

    @RequestMapping(value = "api/usuario/{id}", method = RequestMethod.DELETE)
    public void eliminar(@PathVariable Long id){
        usuarioDao.elimnar(id);

    }
}
