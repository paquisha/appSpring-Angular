package com.viamatica.viamaticaprueba.controllers;

import com.viamatica.viamaticaprueba.entities.Pelicula;
import com.viamatica.viamaticaprueba.services.PeliculaService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.net.URI;
import java.util.List;

@RestController
@RequestMapping("/pelicula/")
public class PeliculaController {

    @Autowired
    private PeliculaService peliculaService;

    @GetMapping
    private ResponseEntity<List<Pelicula>> getAllPeliculas(){
        return ResponseEntity.ok(peliculaService.findAll());
    }

    @PostMapping
    private ResponseEntity<Pelicula> savePelicula(@RequestBody Pelicula pelicula){
        try{
            Pelicula peliculaGuardada = peliculaService.save(pelicula);
            return ResponseEntity.created(new URI("/peliculas/"+peliculaGuardada.getIdPelicula())).body(peliculaGuardada);
        }catch(Exception e){
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).build();
        }
    }

    @PutMapping("/pelicula/{id}")
    public Pelicula update(@RequestBody Pelicula pelicula, @PathVariable Long id){
        Pelicula peliculaActual = peliculaService.findById(id);
        peliculaActual.setNombre(pelicula.getNombre());
        peliculaActual.setDuracion(pelicula.getDuracion());

        return peliculaService.save(peliculaActual);
    }

    @DeleteMapping(value = "delete/{id}")
    @ResponseStatus(HttpStatus.NO_CONTENT)
    private void deletePelicula(@PathVariable Long id){
        peliculaService.deleteById(id);
    }
}
