--TRIGGERS--
/*Los TRIGGERS sirven para dar instruciones o ejecutar algo cuando suceda alguna accion en especifico
Para crear un TRIGGER debemos crear una tabla intermdiaria donde se vallan alamcenando los cambios o ajustes que vamos a hacer
en una tabla especifica.
En este caso vamos a realizar una tabla intermediaria para la tabla de empleados que hicimos anteriormente.
*/
USE Prueba;

CREATE TABLE empleados_inter(
nombre VARCHAR(200) NOT NULL,
dni int NOT NULL UNIQUE
);

/*De esta manera se relizan los triggers en MYSQL*/
CREATE TRIGGER TG_empleado AFTER INSERT
ON empleados
delimiter |
BEGIN

	IF OLD.dni <> NEW.dni THEN
		INSERT INTO empleados_inter(nombre,dni)
		VALUES(OLD.nombre,OLD.dni)
	END IF;
END;
delimiter |

/*La manera de crearla en SQL SERVER */

--EN SQL SERVER el OLD Y EL NEW se establece con un select es un poco mas complicado pero mas o menos quedaria asi:
CREATE TRIGGER TG_empleado ON empleados
AFTER INSERT
AS
BEGIN
	INSERT INTO empleados_inter(nombre,dni)
	SELECT nombre,dni FROM inserted;
END;

INSERT INTO empleados(nombre,dni)
VALUES('Meylin',5555555)

SELECT * FROM empleados_inter;

--ELIMINACION de un trigger se hace de manera muy sencilla.

DROP TRIGGER TG_empleado;


--VIEWS o vistas--
/*La creacion de las vistas sireve para apartar registro de una manera mas comoda y crear una tabla solo de vista
para ver los registro de buena manerea se utiliza normal CREATE VIEW [nombre_view] AS y un SELECT */

CREATE VIEW v_user_edad AS 
SELECT nombre, edad FROM Usuario
WHERE edad>=18;

SELECT * FROM v_user_edad;
--ELIMAR VISTAS
DROP VIEW v_user_edad;

--PROCEDIMIENTOS ALMACENADOS
/*EN MYSQL los procedimientos actuan como una funcion void con  parentesis y luego se establece las intruccion en
cambio en SQL SERVER solamente se declara el nombre y dentro del procedimiento se establce las intrucciones*/

--Asi nos quedaria en SQL SERVER
CREATE PROCEDURE obtener_edad
@edad_p int
AS
BEGIN
	SELECT * FROM Usuario WHERE edad = @edad_p;
END;
GO
--ASI MANDAMOS A EJECUTAR EL PROCEDIMIENTO
EXEC obtener_edad @edad_p=27;

--En cambio en MYSQL nos quedaria de la siguiente manera
CREATE PROCEDURE obtener_edad(IN edad_p int)
AS
BEGIN
	SELECT * FROM Usuario WHERE edad = edad_p;
END;
GO
--ASI MANDAMOS A EJECUTAR EL PROCEDIMIENTO EN MYSQL
CALL obtener_edad(27);

--TRANSACCIONES--
--STAR TRANSACTION
--COMMT
--ROLLBACK
