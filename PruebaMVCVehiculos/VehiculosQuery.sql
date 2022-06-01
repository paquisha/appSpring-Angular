CREATE TABLE [dbo].[vh_vehiculosTest](
	[id]			int identity(1,1) primary key,
	[codigo]		varchar(20) NOT NULL,
	[chasis]		varchar(20) NULL,
	[marca]		varchar(50) NULL,
	[modelo]		varchar(50) NULL,
	[anio_modelo]		int NULL,
	[color]		varchar(50) NULL,
	[estado]		varchar(50) NULL,
	[fecha_registro]	datetime null)
GO

create procedure sp_Listar
as
begin
	select * from vh_vehiculosTest
end

create procedure sp_Obtener(
@id int
)
as
begin
	select * from vh_vehiculosTest where id = @id
end

create procedure sp_Guardar(
@codigo varchar(20),
@chasis varchar(20),
@marca varchar(50),
@modelo varchar(50),
@anio_modelo int,
@color varchar(50),
@estado varchar(50),
@fecha_registro datetime
)
as
begin
	insert into vh_vehiculosTest(codigo,chasis,marca,modelo,anio_modelo,color,estado,fecha_registro) values(@codigo,@chasis,@marca,@modelo,@anio_modelo,@color,@estado,@fecha_registro)
end

create procedure sp_Editar(
@id int,
@codigo varchar(20),
@chasis varchar(20),
@marca varchar(50),
@modelo varchar(50),
@anio_modelo int,
@color varchar(50),
@estado varchar(50),
@fecha_registro datetime
)
as
begin
	update vh_vehiculosTest set codigo = @codigo, chasis = @chasis, marca = @marca, modelo = @modelo, anio_modelo = @anio_modelo, color = @color, estado = @estado, fecha_registro = @fecha_registro where id = @id
end

create procedure sp_Eliminar(
@id int
)
as
begin
	delete from vh_vehiculosTest where id = @id
end


select * from vh_vehiculosTest