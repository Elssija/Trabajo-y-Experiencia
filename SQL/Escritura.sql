--CREATE--
/*
CREATE se utiliza como bien su nombre lo indica con este comando podemos crear ya sea
tablas y base de datos:

CREATE DATABASE Aguilera
*/
CREATE DATABASE Prueba;
USE Prueba;

CREATE TABLE test1(
estudianteID INT not null IDENTITY(1,1) PRIMARY KEY,--->PRIMARY KEY actua como la llave primaria -->IDENTITY sirve como el autoincrement
nombre varchar(150) not null,
edad int not null CHECK(edad>=18), --->CHECK es una funcion que permite dar condiciones a ciertos parametros a la hora de ingresar un dato
comentarios VARCHAR(150) DEFAULT('SIN COMENTARIOS'), ---> DEFAULT sirve para darle un valor predeterminado al registro
UNIQUE(estudianteID),--->UNIQUE es para establecer que no pueden haber datos repetidos dentro de los registros
);
--INSERT--
/*INSERT sirve para ingresar registros dentro de la tabla como su nombre bien lo indica*/
INSERT INTO test1(nombre, edad, comentarios)
VALUES ('Jairo',90,'Buen Alumno'),
('Javier',20,'Excelente Atleta'),
('Isabel',18,DEFAULT)
--UPDATE--
/*UPDATE como su nombre lo indica sive para actualizar los registros de la tabla, "no la tabla"*/
UPDATE test1 SET comentarios = 'MAL ALUMNO' WHERE comentarios = 'Buen Alumno'; 

--DELETE--
/*DELETE sirve para borrar registro de una tabla*/
DELETE FROM test1 WHERE comentarios = 'SIN COMENTARIOS';

--ALTER--
/*ALTER sirve para alterar la tabla funciona como el update pero este no se enfoca en los registro sino mas bien en las tablas

EN MYSQL el alter funciona con un CHANGE para modificar los atributos, un RENANAME para la tabla, y un MODIFY para
modificar los atributos de las columnas

EN SQL SERVER el alte funcina como un para renombrar ya sea la tabla o las columnas se usa el EXEC SP_RENAME 'nombre1','nombre2' esto
para renombrar la tabla y para renombrar una columna se usa EXEC SP_RENAME 'nombre1','nombre2', 'COLUMN', y para modificar los atributos
de la tabla se usa el alter;

ADD para agregar una columna con atributos.

ALTER COLUMN para alterar una columna.

EXEC sp_rename 'nombre1','nombre2', 'COLUMN'

Estas dos van debajo del alter estableciendo la tabla que se desea alterar solo se puede agregar 1 intruccion por cada alter
*/
ALTER TABLE test1
ADD apellido VARCHAR(80) NOT NULL;

ALTER TABLE test1
ALTER COLUMN comentarios varchar(200);

EXEC sp_rename 'estudianteID','NumEstudiante','COLUMN';