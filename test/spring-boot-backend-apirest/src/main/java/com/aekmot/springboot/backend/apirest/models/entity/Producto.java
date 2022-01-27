package com.aekmot.springboot.backend.apirest.models.entity;

import java.io.Serializable;
import java.util.Date;

import javax.persistence.*;

@Entity
@Table(name="productos")
public class Producto implements Serializable{
	
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private long id;
	
	private String nombre;
	private Double precio;
	
	@Column(name="create_at")
	@Temporal(TemporalType.DATE)
	private Date createAt;	
	
	
	@PrePersist
	public void prePersist() {
		this.createAt = new Date();
	}

	public long getId() {
		return id;
	}



	public void setId(long id) {
		this.id = id;
	}



	public String getNombre() {
		return nombre;
	}



	public void setNombre(String nombre) {
		this.nombre = nombre;
	}



	public Double getPrecio() {
		return precio;
	}



	public void setPrecio(Double precio) {
		this.precio = precio;
	}

	public Date getCreateAt() {
		return createAt;
	}



	public void setCreateAt(Date createAt) {
		this.createAt = createAt;
	}





	private static final long serialVersionUID = 1L;

}
