create database tutoriales;

create table futbolista(
	id INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
	nombre varchar(300),
	posicion varchar(300),
	nacionalidad varchar(300),
	imagen varchar(max)
);

--select * from futbolista