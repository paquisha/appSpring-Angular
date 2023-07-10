create table personal(
    idpersonal SERIAL PRIMARY KEY,
    cedula VARCHAR(255) NOT NULL,
    apellido1 VARCHAR(100),
    apellido2 VARCHAR(100),
    nombres VARCHAR(100),
    genero varchar(1)
);

insert into personal(cedula, apellido1, apellido2, nombres, genero)
values('1718979625', 'Grijalva', 'Pincay', 'Andres', 'M');

select * from personal