package com.viamatica.viamaticaprueba.entities;

import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.*;
import java.util.List;

@Entity(name = "sala_cine")
public class SalaCine {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id_sala")
    private Long idSala;
    private String nombre;
    private int estado;

    @OneToMany(mappedBy = "salaCine")
    private List<PeliculaSalaCine> peliculaSalaCines;

    public SalaCine() {
    }

    public SalaCine(String nombre, int estado, List<PeliculaSalaCine> peliculaSalaCines) {
        this.nombre = nombre;
        this.estado = estado;
        this.peliculaSalaCines = peliculaSalaCines;
    }

    public Long getIdSala() {
        return idSala;
    }

    public void setIdSala(Long idSala) {
        this.idSala = idSala;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public int getEstado() {
        return estado;
    }

    public void setEstado(int estado) {
        this.estado = estado;
    }

    public List<PeliculaSalaCine> getPeliculaSalaCines() {
        return peliculaSalaCines;
    }

    public void setPeliculaSalaCines(List<PeliculaSalaCine> peliculaSalaCines) {
        this.peliculaSalaCines = peliculaSalaCines;
    }

    @Override
    public String toString() {
        return "SalaCine{" +
                "idSala=" + idSala +
                ", nombre='" + nombre + '\'' +
                ", estado=" + estado +
                ", peliculaSalaCines=" + peliculaSalaCines +
                '}';
    }
}
