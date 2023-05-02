package com.viamatica.viamaticaprueba.controllers;

import com.viamatica.viamaticaprueba.entities.Pelicula;
import com.viamatica.viamaticaprueba.entities.PeliculaSalaCine;
import com.viamatica.viamaticaprueba.services.PeliculaSalaCineService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.net.URI;
import java.util.List;

@RestController
@RequestMapping("/peliculasalacine/")
public class PeliculaSalaCineController {

    @Autowired
    private PeliculaSalaCineService peliculaSalaCineService;

    @GetMapping
    private ResponseEntity<List<PeliculaSalaCine>> getAllPeliculas(){
        return ResponseEntity.ok(peliculaSalaCineService.findAll());
    }

    /*@GetMapping("/peliculasalacine/{nombre}/{id}")
    private ResponseEntity<List<PeliculaSalaCine>> getByName(@PathVariable String nombre, @PathVariable Long id){
        try{
            List<PeliculaSalaCine> peliculas = peliculaSalaCineService.buscarPorAtributos(nombre, id);
            return  ResponseEntity.ok(peliculas);
        }catch (Exception e){
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).build();
        }
    }*/


    @PostMapping
    private ResponseEntity<PeliculaSalaCine> savePelicula(@RequestBody PeliculaSalaCine pelicula){
        try{
            PeliculaSalaCine peliculaGuardada = peliculaSalaCineService.save(pelicula);
            return ResponseEntity.created(new URI("/peliculassalacine/"+peliculaGuardada.getIdPeliculaSala())).body(peliculaGuardada);
        }catch(Exception e){
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).build();
        }
    }

    /*@PutMapping("/peliculasalacine/{id}")
    public Pelicula update(@RequestBody Pelicula pelicula, @PathVariable Long id){
        Pelicula peliculaActual = peliculaService.findById(id);
        peliculaActual.setNombre(pelicula.getNombre());
        peliculaActual.setDuracion(pelicula.getDuracion());

        return peliculaService.save(peliculaActual);
    }*/

    @DeleteMapping(value = "delete/{id}")
    @ResponseStatus(HttpStatus.NO_CONTENT)
    private void deletePelicula(@PathVariable Long id){
        peliculaSalaCineService.deleteById(id);
    }
}
