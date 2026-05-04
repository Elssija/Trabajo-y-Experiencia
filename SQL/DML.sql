/*
DML = data manipulation languaje : lenguaje de manipulacion de datos
son las instrucciones que se usar para interactiar con los datos almacenados
en la diferentes tablas de nuestra basa de datos
las mas utilizadas son: SELECT, INSERT, UPDATE, DELETE
*/

-- las intrucciones del dml no necesitan del uso del go

use Jairo
go


--INSTRUCCION INSERT
-- agrega uno o mas registros de tabla
-- 1) en INSERT debe incluir todoos los campo/columnas que sean not null
-- 2) los campos que son null son opciones usted decide si los coloca o no en insert
-- 3) la columna definida como IDENTIFY no se coloca en el INSERT debido a que este tipo de columna es autoenumerada
--    por la BD

--INSERT que llena todas las columnas de la table producto

insert producto(Codigo, Nombre, Costo, PrecioVenta, Existencias, Comentarios)
values('CC01','Coca Cola 3L',60,70,0,'Mala para la Salud')

--INSERT no necesita que pongamos los nombres de las columnas en el orden que estan en la tabla
insert producto(Costo, Codigo, PrecioVenta, Nombre, Comentarios, Existencias)
values (40,'BB01',55,'Sprite 2L','tambien es malo para la salud',80)

--INSERT que no inlcuye el campo opcional null (comentarios)
insert producto(codigo,nombre,costo,precioVenta,existencias)
values('BB02','Fresca 3L',62,75,50)

--INSERT Multiregistro
insert producto(Codigo, Nombre, Costo, PrecioVenta,Existencias,Comentarios)
values ('FV01','Manzana Unidad',6.5,8,200,'Buena para la salud'),
('FV02','Lechuga Unidad',14,25.5,0,'Mucho mejor para la salud'),
('BO01','Chetos azules',17,20,89,null),
('BB03','Agua en bolsa',3,4,2000,'Nutritiva para la salud')


-- consultar los registros de la tabla


/*El uso de * en select cuando ya se esta en un ambiente de produccion es considerado
una mala practica. lo que se recomienda es colocar los nombre de las columnas a consultar
porque el * hace que el motor de base de datos trabaje de más, esto porque el * obliga a
ir a consultar los metadatos de la tabla, en cambio si usted menciona las columnas entonces
no se realiza la consulta de metadatos*/
select ProductoID,Codigo,Nombre,PrecioVenta,Existencias,Comentarios from producto

--select premite que digamos que columnas nos interesan:
select Codigo, Nombre, PrecioVenta from producto

--Selecto permite filtrar que columnas deseamos consultar, esto se logra mediante la clusula WHERE
select ProductoID,Codigo,Nombre,PrecioVenta,Existencias,Comentarios 
from producto
where Codigo = 'BB01' or Codigo = 'BO02'

--Mostrar aquellos productos cuyo precio de venta sea mayor o igual a 40 y sus existencias sena mayores a 10
select ProductoID,Codigo,Nombre,PrecioVenta,Existencias,Comentarios 
from producto
where PrecioVenta >=40 and Existencias>10


--mostrar productos cuyo codigo sea BB03, FV01, CC01
select ProductoID,Codigo,Nombre,PrecioVenta,Existencias,Comentarios 
from producto
where Codigo in ('BB01','BB02','FV02')

--mostrara valores cuyo precio de venta este entre 25 y 40
select ProductoID,Codigo,Nombre,PrecioVenta,Existencias,Comentarios 
from producto
where PrecioVenta between 25 and 40

/*DELETE
 elimina uno o vario s registros de una tabla dependiendo del where utilizado
 -> consideraciones importantes
 1) La instruccion DELETE no altera la numeracion de la columna IDENTITY
 2) Siempre acompañe a DELETE con la clausula where
 3) Es muy recomendado, que antes de hacer un DELETE, primero haga un select
 para hacer una vista previa de que va a borrar
 4) si algun registro involucrado en el DELETE se asocia a otra tabla por medio de una llave
 foranea entonces no se eliminara
*/

--Borrar todos los registor de una tabla:
select * from producto
delete from producto

--Eliminar el producto cuyo codigo sea CC01
select * from producto where codigo = 'CC01'
delete from producto where codigo ='CC01'

/*
Instruccion Update
permite realizar cambios a registros ya existentes
al igual con Delete, al hacer UPDATE tambien se recomienda realiza una vista previa por medio de SELECT
--aumentar en 1 las existencias del producto

*/
select * from producto where codigo = 'BB02'

--actualizacion
update producto set existencias = existencias +1 where codigo = 'BB02'

UPDATE producto set Existencias = 100 where Codigo = 'BB01'
--Aumentar un 10% el precio de venta de todos los productos
--vista previa:

select * from producto
update producto set PrecioVenta = PrecioVenta*1.10

-- agregar la palabra REVISADO  a los comentarios de todos los productos

select * from producto
--actualizacion
update producto set comentarios = concat(comentarios,'REVISADO')

--deja en null el comentario del producto cuyo codigo sea BB02
--vista previa
select*from producto where codigo = 'BB02'
update producto set comentarios = null where codigo = 'BB02'

--update permite cambiar varias columnas a la vez
--aumentar en 10 las existencias y colocar null al comentario del producto cuyo codigo sea BB01
select*from producto where codigo = 'BB01'
update producto set Existencias=+10, comentarios = null where codigo = 'BB01'