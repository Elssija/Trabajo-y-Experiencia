--RELACIONES DE TABLAS--
--RELACIONES TIPO 1:1

USE Prueba;
/*PARA Eliminar tablas que estan establecidas con llaves foraneas, primeramente se borra la tabla hija y luego la tabla padre*/
CREATE TABLE Usuario(
dni_id INT,
nombre varchar(200),
edad int,
PRIMARY KEY(dni_id)
);

CREATE TABLE dni(
dni_id INT,
dni_numbre INT NOT NULL,
userid int,
UNIQUE(userid),
--Para establecer una relacion de 1:1 debemos asignar lo siguiente, un FOREIGN KEY la cual apunta a la llave primaria de la tabla actual
--luego REFERENCES que apunta a la otra llave primaria de la tabla en si lo que estamos haciendo es referenciando la segunda tabla a la
--tabla actual en la referencia debemos ingresar el nombre de la tabla referenciada como funcio y dentro colocamos la llave primaria
FOREIGN KEY(dni_id) REFERENCES Usuario(dni_id)
);

--RELACIONES 1:N
/*para crear realciones 1:N tenemos que crear primeramente la tabla 1 y luego crear la tabla N en donde va ir los comando CONTRAINT
FORIGN KEY (variable) REFERENCES tabla(variable) la constraint no es necesaria colocarla pero por motivos de seguridad es mejor colocarla,
esto debido a que el mismo motor de sql genera una dentro de la tabla con llaves foraneas*/
CREATE TABLE compania(
compania_id int identity(1,1) PRIMARY KEY,
nombre_com varchar(200)
);


CREATE TABLE empleados(
emplaedo_id int IDENTITY(1,1) PRIMARY KEY,
nombre VARCHAR(200) NOT NULL,
dni int NOT NULL UNIQUE,
compania_id int,
CONSTRAINT Fk_COMPANIA
FOREIGN KEY(compania_id) REFERENCES compania(compania_id)
);

--RELACIONES N:M--
/*Para este tipo de relaciones se establece mas de una llave foranea, en este caso son 2 y se crea una tabla intermedia
la cual va a servir como puente para relacionar una tabla con otra, nuestra tabla intermedia va a almacenar las variables
y una va a apuntar a una tabla y otra va a apuntar a la otra, las llaves foraneas N:M se hacen dentro de la tabla intermedia
*/
CREATE TABLE lenguajes(
lenguajes_id INT IDENTITY(1,1) PRIMARY KEY,
nombre varchar(200) not null
);

CREATE TABLE lenguajes_empleado(
lenguajes_id int,
emplaedo_id int,

FOREIGN KEY(lenguajes_id) REFERENCES lenguajes(lenguajes_id),
FOREIGN KEY(emplaedo_id)  REFERENCES empleados(emplaedo_id)
);

--CONSULTAS PARA RELACIONES DE TABLAS--

--RELACION 1:1 
/*
las relaciones sirven para relacionar datos de la tabla hijo con datos ya existentes en la tabla padre en este caso la tabla padre
es la de USUARIO donde justamente se debe insertar primeramente los datos, y luego en la tabla hijo se deben insertar los datos, 
donde la llave foranea FOREIGN KEY, debe concordar con alguna llave foranea de la tabla padre.
*/

INSERT INTO Usuario(dni_id,nombre, edad)
VALUES(1,'Jairo',34),(2,'Jeyson',27),(3,'ISAAC',57);

INSERT INTO dni(dni_id,dni_numbre,userid)
VALUES(3,3,30)

SELECT*FROM Usuario;
SELECT*FROM dni;

--RELACION 1:N--
INSERT INTO compania(nombre_com)
VALUES('GOOGLE'),('GILDAN'),('CREDIRAPID');

INSERT INTO empleados(compania_id,nombre,dni)
VALUES (3,'JAIRO',11111111);

SELECT*FROM empleados;
SELECT*FROM compania;

--RELACION N:M--

/*Sabemos que ya tenemos un empleado que se hace llamar Jairo donde su empleado_id es 1 asi que lo que nosotros vamos a hacer
es que este empleado pueda dominar varios lenguajes*/

--Primeramente vamos a crear unos lenguajes:
INSERT INTO lenguajes(nombre)
VALUES ('PYTHON'),('JAVA'),('C#');

--RECORDAR siempre insertar los datos de la tabla padre en nuestro caso es la de empleado
--Ahora vamos a relacionar los datos con la tabla intermedia que creamos para las dos tablas anteriores
INSERT INTO lenguajes_empleado(emplaedo_id,lenguajes_id)
--En este caso establecemos que el usuario JAIRO sabe el lenguaje 3 osea C#
VALUES(1,3);

INSERT INTO lenguajes_empleado(emplaedo_id,lenguajes_id)
VALUES(1,2),(1,1);

--Asi como hicimos con este usuario podemos crear mas empleados y hacer lo mismo con ellos

INSERT INTO empleados(compania_id,nombre,dni)
VALUES (2,'Jeyson',2222222),(3,'Isaac',3333333);

INSERT INTO lenguajes_empleado(emplaedo_id,lenguajes_id)
VALUES(2,2),(3,3);

--Crearemos otro empleado para darle otro lenguaje
SELECT * FROM empleados;
SELECT * FROM lenguajes;
SELECT * FROM lenguajes_empleado;

--JOIN--
--INNER JOIN
/*este sirve para obtener los datos que estan relacionados entre dos tablas*/

--JUSTAMENTE para hacer un JOIN siempre debemos ejecutar un SELECT en la tabla hija, es decir en donde establecimos la llave foranea
--o en una variable dentro de la tabla, pero si la ejecutamos en la clase padre por si sola habra un error
--RELACION 1:1
SELECT * FROM dni

--El JOIN O INNER JOIN al final son lo mismo, para poder ejecutarlo hacemos el JOIN en una tabla y luego lo antecede un ON
--en el cual vamos a vincular las variables que establecimos como llaves foraneas y asi obtendremos una tabla que vincula las
--dos tablas (NO IMPORTA EL ORDEN EN EL QUE ESTABLECEMOS EL JOIN)
INNER JOIN Usuario ON Usuario.dni_id = dni.dni_id;

SELECT Usuario.nombre FROM dni
INNER JOIN Usuario ON Usuario.dni_id = dni.dni_id;

--RELACION 1:N INNER JOIN

SELECT * FROM empleados
JOIN compania ON compania.compania_id = empleados.compania_id;

SELECT empleados.nombre, compania.nombre_com FROM empleados
JOIN compania ON compania.compania_id = empleados.compania_id;

--RELACION N:M LEFT JOIN
/*Esta relacion lo que hace es traer todos los datos que estan en la Izquierda exceptuando los de la derecha y los que son iguales*/

SELECT * FROM lenguajes_empleado
LEFT JOIN empleados ON empleados.emplaedo_id = lenguajes_empleado.emplaedo_id
LEFT JOIN lenguajes ON lenguajes.lenguajes_id = lenguajes_empleado.lenguajes_id;

--RELACION N:M RIGHT JOIN
/*Funciona igual que lo anterior lo unico que cambia es que solo trae los datos de la derecha*/
SELECT * FROM lenguajes_empleado
RIGHT JOIN empleados ON empleados.emplaedo_id = lenguajes_empleado.emplaedo_id
RIGHT JOIN lenguajes ON lenguajes.lenguajes_id = lenguajes_empleado.lenguajes_id;

--UNION O UNION ALL--
/*Como lo dice su nombre este sirve para unir los join ESTO para poder establecer un FULLJOIN podemos establecer un JOIN de la parte izquierda
y de la parte derecha a la misma vez*/
SELECT empleados.nombre AS empleados_lenguajes FROM lenguajes_empleado
RIGHT JOIN empleados ON empleados.emplaedo_id = lenguajes_empleado.emplaedo_id
UNION
SELECT lenguajes.nombre FROM lenguajes_empleado
RIGHT JOIN lenguajes ON lenguajes.lenguajes_id = lenguajes_empleado.lenguajes_id
;
--Unimos los lenguajes y los nombres de los empleados en una misma tabla

--INDEXES--
/*Los Indexes sirven para traladarnos o econtrar datos en columnas de manera mas rapida y asi evitar usar demasiados recurso y van
de la siguiente manera*/

--Index normal
CREATE INDEX idx_nombre ON empleados(nombre);

--Index UNICO
CREATE UNIQUE INDEX idx_nombre2 ON empleados(nombre);

--Borra index: utilizamos el comando DROP luego INDEX y establecemos del Index que queremos borrar y luego le decimos en tabla se encuentra
DROP INDEX idx_nombre ON empleados;