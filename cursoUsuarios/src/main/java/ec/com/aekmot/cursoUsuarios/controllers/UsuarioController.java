package ec.com.aekmot.cursoUsuarios.controllers;


import ec.com.aekmot.cursoUsuarios.models.Usuario;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.ArrayList;
import java.util.List;

@RestController
public class UsuarioController {

    @RequestMapping(value = "usuario/{id}")
    public Usuario getusuario(@PathVariable Long id){
        Usuario usuario = new Usuario();
        usuario.setId(id);
        usuario.setNombre("Andres");
        usuario.setApellido("Grijalva");
        usuario.setEmail("andres.grijalval@mail.com");
        usuario.setTelefono("1234567890");
        return usuario;
    }

    @RequestMapping(value = "usuarios")
    public List<Usuario> getusuarios(){
        List<Usuario> usuarios = new ArrayList<>();

        Usuario usuario = new Usuario();
        usuario.setId(1L);
        usuario.setNombre("Andres");
        usuario.setApellido("Grijalva");
        usuario.setEmail("andres.grijalval@mail.com");
        usuario.setTelefono("1234567890");

        Usuario usuario1 = new Usuario();
        usuario1.setId(2L);
        usuario1.setNombre("Aime");
        usuario1.setApellido("Pachacama");
        usuario1.setEmail("aime@mail.com");
        usuario1.setTelefono("1234567890");

        Usuario usuario2 = new Usuario();
        usuario2.setId(3L);
        usuario2.setNombre("Nathalia");
        usuario2.setApellido("Pachacama");
        usuario2.setEmail("naty@mail.com");
        usuario2.setTelefono("1234567890");

        usuarios.add(usuario);
        usuarios.add(usuario1);
        usuarios.add(usuario2);

        return usuarios;
    }

    @RequestMapping(value = "usuario")
    public Usuario editar(){
        Usuario usuario = new Usuario();
        usuario.setNombre("Andres");
        usuario.setApellido("Grijalva");
        usuario.setEmail("andres.grijalval@mail.com");
        usuario.setTelefono("1234567890");
        return usuario;
    }

    @RequestMapping(value = "usuario")
    public Usuario eliminar(){
        Usuario usuario = new Usuario();
        usuario.setNombre("Andres");
        usuario.setApellido("Grijalva");
        usuario.setEmail("andres.grijalval@mail.com");
        usuario.setTelefono("1234567890");
        return usuario;
    }

    @RequestMapping(value = "usuario")
    public Usuario buscar(){
        Usuario usuario = new Usuario();
        usuario.setNombre("Andres");
        usuario.setApellido("Grijalva");
        usuario.setEmail("andres.grijalval@mail.com");
        usuario.setTelefono("1234567890");
        return usuario;
    }


}
