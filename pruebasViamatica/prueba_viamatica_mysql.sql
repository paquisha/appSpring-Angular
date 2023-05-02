create database prueba_viamatica;

create table pelicula(
	id_pelicula int primary key auto_increment,
    nombre varchar(200),
    duracion int
);

create table sala_cine(
	id_sala int primary key auto_increment,
    nombre varchar(200),
    estado int
);

create table pelicula_sala_cine(
	id_pelicula_sala int primary key auto_increment,
    id_sala int,
    fecha_publicacion date,
    fecha_fin date,
    id_pelicula int,
    foreign key(id_sala) references sala_cine(id_sala),
    foreign key(id_pelicula) references pelicula(id_pelicula)
);