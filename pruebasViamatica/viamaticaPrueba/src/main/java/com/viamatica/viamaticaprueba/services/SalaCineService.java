package com.viamatica.viamaticaprueba.services;

import com.viamatica.viamaticaprueba.entities.Pelicula;
import com.viamatica.viamaticaprueba.entities.SalaCine;
import com.viamatica.viamaticaprueba.repository.SalaCineRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.domain.Sort;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class SalaCineService {

    @Autowired
    private SalaCineRepository salaCineRepository;

    public List<SalaCine> findAll(){
        return salaCineRepository.findAll();
    }

    public List<SalaCine> findAll(Sort sort){
        return salaCineRepository.findAll(sort);
    }

    public Page<SalaCine> findAll(Pageable pageable){
        return salaCineRepository.findAll(pageable);
    }

    public <S extends SalaCine> S save(S entity){
        return salaCineRepository.save(entity);
    }

    public SalaCine findById(Long id){
        return salaCineRepository.findById(id).orElse(null);
    }

    public void deleteById(Long id){
        salaCineRepository.deleteById(id);
    }

    public void delete(SalaCine salacine){
        salaCineRepository.delete(salacine);
    }
}
