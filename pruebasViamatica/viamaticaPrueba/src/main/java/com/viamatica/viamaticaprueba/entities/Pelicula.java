package com.viamatica.viamaticaprueba.entities;

import javax.persistence.*;
import java.util.List;

@Entity(name = "pelicula")
public class Pelicula {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id_pelicula")
    private Long idPelicula;
    private String nombre;
    private int duracion;

    @OneToMany(mappedBy = "pelicula")
    private List<PeliculaSalaCine> peliculaSalaCines;

    public Pelicula() {
    }

    public Pelicula(String nombre, int duracion, List<PeliculaSalaCine> peliculaSalaCines) {
        this.nombre = nombre;
        this.duracion = duracion;
        this.peliculaSalaCines = peliculaSalaCines;
    }

    public Long getIdPelicula() {
        return idPelicula;
    }

    public void setIdPelicula(Long idPelicula) {
        this.idPelicula = idPelicula;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public int getDuracion() {
        return duracion;
    }

    public void setDuracion(int duracion) {
        this.duracion = duracion;
    }

    public List<PeliculaSalaCine> getPeliculaSalaCines() {
        return peliculaSalaCines;
    }

    public void setPeliculaSalaCines(List<PeliculaSalaCine> peliculaSalaCines) {
        this.peliculaSalaCines = peliculaSalaCines;
    }

    @Override
    public String toString() {
        return "Pelicula{" +
                "idPelicula=" + idPelicula +
                ", nombre='" + nombre + '\'' +
                ", duracion=" + duracion +
                ", peliculaSalaCines=" + peliculaSalaCines +
                '}';
    }
}
