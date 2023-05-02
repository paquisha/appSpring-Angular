package com.viamatica.viamaticaprueba.repository;

import com.viamatica.viamaticaprueba.entities.PeliculaSalaCine;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface PeliculaSalaCineRepository extends JpaRepository<PeliculaSalaCine, Long> {

    /*@Query("SELECT e FROM pelicula_salacine e WHERE e.pelicula.nombre Like %:nombre% AND e.salaCine.idSala = :id")
    List<PeliculaSalaCine> buscarPorAtributos(@Param("nombre") String nombre, @Param("id_sala") Long id);*/

}
