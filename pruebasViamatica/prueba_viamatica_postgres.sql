create table pelicula(
    id_pelicula INTEGER PRIMARY KEY,
    nombre text,
    duracion integer
);

create table sala_cine(
    id_sala INTEGER PRIMARY KEY,
    nombre text,
    estado integer
);

create table pelicula_sala_cine(
    id_pelicula_sala INTEGER PRIMARY KEY,
    id_sala_cine INTEGER REFERENCES sala_cine(id_sala),
    fecha_publicacion timestamp,
    fecha_fin timestamp,
    id_pelicula INTEGER REFERENCES  pelicula(id_pelicula)
);