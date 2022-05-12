package com.aekmot.web.controllers;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;

@Controller
@RequestMapping("/params")
public class EjemploParamsController {
	
	@GetMapping("/string")
	public String param(@RequestParam(name="texto", required=false) String texto,Model model) {
		model.addAttribute("resultado", "el parametro enviado es: " + texto);
		model.addAttribute("titulo", "Paso de parametros");
		return "params/ver";
	}
}
