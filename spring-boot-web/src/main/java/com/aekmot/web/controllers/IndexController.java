package com.aekmot.web.controllers;

import java.util.ArrayList;
import java.util.List;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;

import com.aekmot.web.models.Usuario;

@Controller
@RequestMapping("/app")
public class IndexController {
	
	@GetMapping({"/index", "/", "/home"})
	public String index(Model model) {
		model.addAttribute("titulo", "Hola mundo");
		return "index";
	}
	
	@RequestMapping("/perfil")
	public String perfil(Model model) {
		Usuario usuario = new Usuario();
		usuario.setNombre("Andres");
		usuario.setApellido("Grijalva");
		usuario.setEmail("andres.grijalvap@gmail.com");
		model.addAttribute("usuario", usuario);
		model.addAttribute("titulo", "Perfil del usuario: ".concat(usuario.getNombre()));
		return "perfil";
	}
	
	@RequestMapping("/listar")
	public String listar(Model model) {
		List<Usuario> usuarios = new ArrayList<>();
		usuarios.add(new Usuario("Aime", "Pachacama", "aime@gmail.com"));
		usuarios.add(new Usuario("Nathalia", "Pachacama", "natalia@gmail.com"));
		usuarios.add(new Usuario("Alejandra", "Cadena", "Alejandra@gmail.com"));
		usuarios.add(new Usuario("Evelyn", "Benavides", "evelyn@gmail.com"));
		model.addAttribute("titulo", "Listado usuarios");
		model.addAttribute("usuarios", usuarios);
		return "listar";
	}
	
	
}
