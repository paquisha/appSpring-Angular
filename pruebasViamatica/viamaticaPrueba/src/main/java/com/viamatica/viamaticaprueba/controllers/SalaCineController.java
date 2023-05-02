package com.viamatica.viamaticaprueba.controllers;
import com.viamatica.viamaticaprueba.entities.Pelicula;
import com.viamatica.viamaticaprueba.entities.SalaCine;
import com.viamatica.viamaticaprueba.services.SalaCineService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.net.URI;
import java.util.List;

@RestController
@RequestMapping("/salacine/")
public class SalaCineController {

    @Autowired
    private SalaCineService salaCineService;

    @GetMapping
    private ResponseEntity<List<SalaCine>> getAllSalaCines(){
        return ResponseEntity.ok(salaCineService.findAll());
    }

    @PostMapping
    private ResponseEntity<SalaCine> saveSalaCine(@RequestBody SalaCine salaCine){
        try{
            SalaCine salaGuardada = salaCineService.save(salaCine);
            return ResponseEntity.created(new URI("/salacine/"+salaGuardada.getIdSala())).body(salaGuardada);
        }catch(Exception e){
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).build();
        }
    }

    @PutMapping("/salacine/{id}")
    public SalaCine update(@RequestBody SalaCine salaCine, @PathVariable Long id){
        SalaCine salaActual = salaCineService.findById(id);
        salaActual.setNombre(salaCine.getNombre());
        salaActual.setEstado(salaCine.getEstado());

        return salaCineService.save(salaActual);
    }

    @DeleteMapping(value = "delet/{id}")
    @ResponseStatus(HttpStatus.NO_CONTENT)
    private void deleteSala(@PathVariable Long id){
        salaCineService.deleteById(id);
    }

}
