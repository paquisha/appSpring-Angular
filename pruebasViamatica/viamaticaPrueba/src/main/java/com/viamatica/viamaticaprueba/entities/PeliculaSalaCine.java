package com.viamatica.viamaticaprueba.entities;

import javax.persistence.*;
import java.util.Date;
import java.util.List;
import java.util.Set;


@Entity(name = "pelicula_salacine")
public class PeliculaSalaCine {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id_pelicula_sala")
    private Long idPeliculaSala;
    @Column(name = "fecha_publicacion")
    private Date fechaPublicacion;
    @Column(name = "fecha_fin")
    private Date fechaFin;

    @ManyToOne
    @JoinColumn(name = "id_pelicula", referencedColumnName = "id_pelicula")
    private Pelicula pelicula;

    @ManyToOne
    @JoinColumn(name = "id_sala", referencedColumnName = "id_sala")
    private SalaCine salaCine;

    public PeliculaSalaCine() {
    }

    public PeliculaSalaCine(Date fechaPublicacion, Date fechaFin, Pelicula pelicula, SalaCine salaCine) {
        this.fechaPublicacion = fechaPublicacion;
        this.fechaFin = fechaFin;
        this.pelicula = pelicula;
        this.salaCine = salaCine;
    }

    public Long getIdPeliculaSala() {
        return idPeliculaSala;
    }

    public void setIdPeliculaSala(Long idPeliculaSala) {
        this.idPeliculaSala = idPeliculaSala;
    }

    public Date getFechaPublicacion() {
        return fechaPublicacion;
    }

    public void setFechaPublicacion(Date fechaPublicacion) {
        this.fechaPublicacion = fechaPublicacion;
    }

    public Date getFechaFin() {
        return fechaFin;
    }

    public void setFechaFin(Date fechaFin) {
        this.fechaFin = fechaFin;
    }

    public Pelicula getPelicula() {
        return pelicula;
    }

    public void setPelicula(Pelicula pelicula) {
        this.pelicula = pelicula;
    }

    public SalaCine getSalaCine() {
        return salaCine;
    }

    public void setSalaCine(SalaCine salaCine) {
        this.salaCine = salaCine;
    }

    @Override
    public String toString() {
        return "PeliculaSalaCine{" +
                "idPeliculaSala=" + idPeliculaSala +
                ", fechaPublicacion=" + fechaPublicacion +
                ", fechaFin=" + fechaFin +
                ", pelicula=" + pelicula +
                ", salaCine=" + salaCine +
                '}';
    }
}
