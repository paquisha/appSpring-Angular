package com.viamatica.viamaticaprueba.services;

import com.viamatica.viamaticaprueba.entities.Pelicula;
import com.viamatica.viamaticaprueba.repository.PeliculaRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.domain.Sort;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;


@Service
public class PeliculaService {

    @Autowired
    private PeliculaRepository peliculaRepository;

    public List<Pelicula> findAll(){
        return peliculaRepository.findAll();
    }

    public List<Pelicula> findAll(Sort sort){
        return peliculaRepository.findAll(sort);
    }

    public Page<Pelicula> findAll(Pageable pageable){
        return peliculaRepository.findAll(pageable);
    }

    public <S extends Pelicula> S save(S entity){
        return peliculaRepository.save(entity);
    }

    public Pelicula findById(Long id){
        return peliculaRepository.findById(id).orElse(null);
    }

    public void deleteById(Long id){
        peliculaRepository.deleteById(id);
    }

    public void delete(Pelicula pelicula){
        peliculaRepository.delete(pelicula);
    }
}
