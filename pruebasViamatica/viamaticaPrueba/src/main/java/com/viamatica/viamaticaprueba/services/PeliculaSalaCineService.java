package com.viamatica.viamaticaprueba.services;

import com.viamatica.viamaticaprueba.entities.Pelicula;
import com.viamatica.viamaticaprueba.entities.PeliculaSalaCine;
import com.viamatica.viamaticaprueba.repository.PeliculaSalaCineRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.domain.Sort;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class PeliculaSalaCineService {

    @Autowired
    private PeliculaSalaCineRepository peliculaSalaCineRepository;

    public List<PeliculaSalaCine> findAll(){
        return peliculaSalaCineRepository.findAll();
    }

    public List<PeliculaSalaCine> findAll(Sort sort){
        return peliculaSalaCineRepository.findAll(sort);
    }

    /*public List<PeliculaSalaCine> buscarPorAtributos(String nombre, Long id){
        return peliculaSalaCineRepository.buscarPorAtributos(nombre, id);
    }*/

    public Page<PeliculaSalaCine> findAll(Pageable pageable){
        return peliculaSalaCineRepository.findAll(pageable);
    }

    public <S extends PeliculaSalaCine> S save(S entity){
        return peliculaSalaCineRepository.save(entity);
    }

    public PeliculaSalaCine findById(Long id){
        return peliculaSalaCineRepository.findById(id).orElse(null);
    }

    public void deleteById(Long id){
        peliculaSalaCineRepository.deleteById(id);
    }
}
