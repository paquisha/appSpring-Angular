create table CABECERA(
IdCabecera int primary key identity(1,1),
NombreCliente varchar(50),
NombreEmpresa varchar(50),
Direccion varchar(50),
Telefono varchar(50)
)


create table DETALLE(
Codigo int not null,
IdCabecera  int not null,
Vendedor varchar(20),
OrdenCompra varchar(50),
Enviar varchar(50),
Terminos varchar(50),
)


Create table PRODUCTOS(
Codigo int primary key identity(1,1),
Descripcion varchar(50),
Cantidad int,
Precio decimal(10,2),
Total decimal(10,2)
)

alter table DETALLE
ADD CONSTRAINT FK_Detalle_Productos
FOREIGN KEY (Codigo) REFERENCES PRODUCTOS(Codigo)
	ON UPDATE CASCADE
	ON DELETE CASCADE,
CONSTRAINT FK_Detalle_Facturar
FOREIGN KEY (IdCabecera) REFERENCES CABECERA(IdCabecera)
	ON UPDATE CASCADE
	ON DELETE CASCADE
