--Script de SQL server
--Comentario de un renglon
/*Comentario de
varios
renglones
*/

/*
Intrucciones DDL: Data Definition Languaje
son instrucciones usadas para la manipulación de
objetos de base de datos (tablas, base de datos, llaves, usuarios)
las mas conocidas son: CREATE, DROP, ALTER, TRUNCATE, USE
*/

--Crear base de datos
CREATE DATABASE Jairo
GO
--toda instruccion del ddl se recomienda colocar la instruccion go despues de cada una
--de ellas, esto se hace para evitar que se ejecute la instruccion siguiente hasta que se
--termine de procesar la instruccion antes del go

--Eliminar una base de datos
--se recomienda primero reiniciar el SQL SERVER luego ejecuta lo siguiente:

USE master --seleccionar la base de datos de sistema
GO
DROP DATABASE Jairo
GO

--Crear una tabla de la base datos
--Importante: antes de ello debera seleccionar la base de datos
-- donde va a crear la tabla

USE Jairo
GO
CREATE TABLE producto(
	ProductoID bigint NOT NULL IDENTITY(1,1), -- COLUMNA autonumerica de 1 en 1
	Codigo varchar(30) NOT NULL,
	Nombre varchar(200) NOT NULL,
	Costo decimal(12,2) NOT NULL, -- numero decimal de 12 digitos a 2 decimales
	PrecioVenta decimal(12,2) NOT NULL,
	Existencias int NOT NULL, --int es entero de 4 bytes
	Comentarios text NULL, --texto casi ilimitado (como 2 terabytes por registro), es opcional ya que esta el NULL
	PRIMARY KEY(ProductoID)
)
GO

--not null significa que una columna se debe llenar obligatoriamente

--borrar una tabla: Importante destruye la tabla y sus datos anunque esten en uso
--seleccione la base de datos donde esta la tabla:

USE Jairo
GO
DROP TABLE producto
GO

--vaciar el contenido de una tabla (borrar sus datos sin destruir su estructura)
USE Jairo
go
truncate table producto
go
--lo anterior tambien resetea el campo autonumerico
-- por ejemplo: agregar una columna lamada color a la table prouducto, tipo varcahr(15) y que admita nulos
use Jairo
go
alter table producto
add color varchar(15) null
go

--borrar una columna de una tabla existente sin perder los demas datos
use Jairo
go
alter table producto
drop column color 
go
-- cambiar el tamaño de una columna existente sin perder datos
--ampliar el tamaño de la columna nombre a 250 caracteres
use Jairo
go
alter table producto
alter column nombre varchar(250) not null
go