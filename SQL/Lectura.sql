--METODOS DE LECTURA

--Select
use Aguilera

--Para obetener todo el contenido de una tabla creada se utiliza el select*from tabla creada
select*from Ventas

--LIMIT o TOP para sql server =Obtener solamente un numero limitado de registros utilizamos el comando reservado limit
select TOP 2 * from Ventas where Precio >= 7 ;

--Distinct: obtiene todos los valores distintos de los registros que se tienen en la base de datos
select Distinct Precio from ventas;

--AND, 0R Y NOT = estos son operadores logicos donde podemos consultar mas regitros de maneras distintas
select*from Ventas where Precio = 20 or Existencias >= 100;

--ORDER BY: permite seleccionar el modo en que se desea ordenar los registros de nuestra tabla
--ASC Y DESC = estos comandos permiten ordenar los regitrso de manera ya sea ascendente o descendente
select*from Ventas where Precio = 20 or Existencias >= 100 order by ProductoID asc;
select*from Ventas where Precio = 20 or Existencias >= 100 order by ProductoID desc;

--LIKE : permite buscar o ordenar de la forma a econtrar algo muy especifico para eso antes de cada cadena o despues
--se agrega % un signo de porcentaje para señalar lo que deseamos buscar y mostrar justamente like va secesivo despues de un where
--practicamente en ves de usar un = utilizamos un LIKE
select*from Ventas where codigo like '%304%';


go 
use Jairo 
go
insert producto(Nombre,Costo,Existencias,PrecioVenta,Codigo,Comentarios)
values ('Amortiguador',300,12,540,'fdsfasdwefa',null)

--IS NULL: bien justamente este se utiliza para obtener registros quue sean nulos.

select*from producto where Comentarios IS NULL order by costo asc;


--------------FUNCIONES---------------

--MIN Y MAX: actuan como funcion de programacion hasta este punto el MAX Y El MIN van secesivos del SELECT

select MAX(Costo) from producto;
select MIN(Costo) from producto;

--COUNT: actua como funcion sirve para contara los registros ya sea en su totalidad o registro por columnas

SELECT COUNT(Existencias) FROM producto;
SELECT COUNT(*) FROM producto;

--SUM: actua como Funcion y sirve para sumar los registros obviamente los que sean de tipo numerico
SELECT SUM(Costo) FROM producto;

--AVG: actua como una funcion que permite obtener la media de un registro (estadistica)
SELECT AVG(Costo) FROM producto;

--IFNULL o ISNULL: actua como una funcion la cual funciona para los elementos son nulos de pueden hacer que cosas con los registros, se seleccion un primer
--registro y luego de la (,) coma, va el resultado que se quiere obtener va siempre despues del SELECT antes del FROM
SELECT ISNULL(Comentarios,'no hay') FROM producto;

--CONCAT: este comando funciona como una funcion el como su nombre lo indica se encarga de concatenar
SELECT CONCAT('numero de producto: ',ProductoID,' Nombre: ',Nombre, 'existencias: ',Existencias) FROM producto WHERE Existencias >= 10;

--HAVING: practicamente sirve para obtener registros un poco mas restringidos teniendo exigencias mas estrictas
SELECT COUNT(Existencias) FROM producto HAVING COUNT(Existencias) > 9

--IN: actua sucesivo de un WHERE esto para econtrar registros especficos
SELECT*FROM producto WHERE Nombre IN ('Amortiguador')

--BETWEEN: este actua para obtener los datos que estan entre en medio de dos datos limites
SELECT*FROM producto WHERE Existencias BETWEEN 5 AND 20 

--AS: este comando sirve para darle un alias a una columna de los registros este justamente va despues del select
SELECT ProductoID AS 'Numero de Producto' FROM producto;	

--CASE: sirve praticamente para abrir un switch de programacion sucesivo del SELECT ingresamos lo que queremos obtener y luego secesivo de una (,)
--coma establecemos los condicionales estableciendo un if como un WHEN y un cout o console.writeline() como THEN y se establece un ELSE y luego se
--Finaliza con un END y si se quiere se puede establecer un Alias osea un AS

SELECT *,
CASE
	WHEN Existencias >= 10 THEN 'existen suficientes existencias'
	ELSE 'No hay suficientes Existencias'
END AS 'Suficiencia'
FROM producto;


