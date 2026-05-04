--NumeroCuenta=20232001430	Nombre=Jairo Jassiel Aguilera Romero
--EJERCICIO 1
create database Aguilera
go

go
use Aguilera
go
--EJERCICIO 2
go
create table Estudiante(
EstudianteID bigint not null identity(1,1),
Nombre varchar(150) not null,
Cuenta varchar(20) not null,
CiudadOrigen varchar(150) not null,
PaisOrigen varchar(100) not null,
Correo varchar(100) not null,
Peso Decimal(5,2) not null,
Estatura Decimal(3,2) not null,
Observaciones text null,
primary key(EstudianteID)
)
go

insert Estudiante(Nombre,Cuenta,CiudadOrigen,PaisOrigen,Correo,Peso,Estatura,Observaciones)
values('Jairo','20232001430','San Pedro Sula','Honduras','fdafsad@gmail.com',80,1.78,'Callado'),
('Carlos', '20211005432', 'Tegucigalpa', 'Honduras', 'carlos.m@gmail.com', 75, 1.72, 'Alegre'),
('Andrea', '20221008899', 'La Ceiba', 'Honduras', 'andrea_v@yahoo.com', 62, 1.65, 'Creativa'),
('Luis','20242031122', 'Choluteca', 'Honduras', 'luis_hnd@outlook.com', 88, 1.85, 'Sociable'),
('Elena', '20201007744', 'Santa Rosa de Copán', 'Honduras', 'elena.m@gmail.com', 55,1.60, 'Estudiosa')

select EstudianteID,Nombre,Cuenta,CiudadOrigen,PaisOrigen,Correo,Peso,Estatura,Observaciones from Estudiante

update Estudiante set Nombre = 'Laura', Correo = 'laurita.k@gmail.com' where Nombre = 'Carlos'

delete from Estudiante where CiudadOrigen = 'Tegucigalpa'

--EJERCICIO 3
go
create table DatosClientes(
ClienteID bigint not null identity(1,1),
Nombre varchar(200) not null,
Telefono varchar(8) not null,
Correo varchar(200) not null,
Direccion varchar(150) not null,
RTN varchar(14) not null,
primary key(Nombre)
)
go

insert DatosClientes(Nombre,Telefono,Correo,Direccion,RTN)
values('Jairo','95955342','jjaguil@gmail.com','Armenta San Pedro Sula','05012006033039'),
('Mario', '98776655', 'mariocastro@gmail.com', 'Colonia Moderna San Pedro Sula', '0501199012345'),
('Lucia', '33445566', 'lucia.ortez@gmail.com', 'Barrio El Benque San Pedro Sula', '0501199506789'),
('David', '95123456', 'davidsantos@gmail.com', 'Residencial Plaza San Pedro Sula', '0501198801122'),
('Karla', '88223344', 'karlarivera@gmail.com', 'Colonia Ideal San Pedro Sula', '0501200205566'),
('Oscar', '96547891', 'oscarh@gmail.com', 'Barrio Cabañas San Pedro Sula', '0501199308899'),
('Elena', '31122334', 'elenam@gmail.com', 'Colonia Universidad San Pedro Sula', '0501199703344'),
('Victor', '94455667', 'victorg@gmail.com', 'Colonia Satélite San Pedro Sula', '0501199107788'),
('Rosa', '87654321', 'rosap@gmail.com', 'Barrio Medina San Pedro Sula', '0501199602211'),
('Angel', '95958877', 'angelf@gmail.com', 'Colonia Rivera Hernández San Pedro Sula', '0501199404433'),
('Carmen', '32556677', 'carmenl@gmail.com', 'Residencial Macky San Pedro Sula', '0501200009900'),
('Jose', '99881122', 'josez@gmail.com', 'Colonia Prado Alto San Pedro Sula', '0501198906655')

select Nombre,Telefono,Correo,Direccion,RTN from DatosClientes

delete from DatosClientes where RTN='0501200205566'

update DatosClientes set Telefono='97665590' where RTN = '0501199506789'

--EJERCICIO 4
go
create table UsuarioSistema(
ID_Usuario int not null identity(1,1),
CodigoUsuario varchar(5) not null,
NombreC varchar(200) not null,
Clave varchar(30) not null,
Telefono varchar(8) not null,
Correo varchar(150) not null,
Direccion varchar(200) not null,
primary key(CodigoUsuario)
)
go

insert UsuarioSistema(CodigoUsuario,NombreC,Clave,Telefono,Correo,Direccion)
values ('09989', 'Mauricio Andres Lopez Castro', '124455', '98772211', 'mlopez88@gmail.com', 'Colonia Altiplano San Pedro Sula'),
('98801', 'Daniela Maria Vallecillo Gomez', '112233', '33449988', 'daniv@outlook.com', 'Residencial Plaza San Pedro Sula'),
('74882', 'Roberto Jose Hernandez Pineda', '119988', '95663322', 'robertoh@gmail.com', 'Barrio Rio de Piedras San Pedro Sula'),
('62711', 'Cristina Elena Torres Maldonado', '127766', '88554433', 'cristyt@gmail.com', 'Colonia Universidad San Pedro Sula'),
('12441', 'Santiago David Martinez Flores', '113344', '94221100', 'smartinez@gmail.com', 'Colonia Moderna San Pedro Sula')

select CodigoUsuario,NombreC,Clave,Telefono,Correo,Direccion from UsuarioSistema

delete from UsuarioSistema where CodigoUsuario = '12441'

update UsuarioSistema set Clave = '987761' where ID_Usuario = 3

--EJERCICIO 5
go
create table FlotaVehiculos(
ID_Vehiculo int not null identity(1,1),
NumPlaca varchar(10) not null,
Marca varchar(50) not null,
Modelo varchar(50) not null,
Color varchar(15) not null,
Anio int not null,
TipoVehiculo varchar(100) not null,
NumMotor varchar(6) not null,
NumChasis varchar(6) not null,
Kilometraje bigint not null,
Comentarios varchar(200),
primary key(ID_Vehiculo)
)
go
insert FlotaVehiculos(NumPlaca,Marca,Modelo,Color,Anio,TipoVehiculo,NumMotor,NumChasis,Kilometraje,Comentarios)
values('H DV 9056','Nissan','X-trail','Rojo Vino',2004,'Camioneta','988311','901211',88000,'Es un auto para la familia'),
('P DG 4521','Toyota','Hilux','Blanco',2018,'Pick-up','455612','100233',485000,'Excelente para el trabajo y terreno difícil'),
('H BK 2231','Honda','Civic','Azul Marino',2012,'Turismo','332211','998877',165000,'Motor económico y bien cuidado'),
('P EC 1102','Hyundai','Elantra','Gris Metálico',2015,'Turismo','774455','221133',190000,'Full extras, aire al cien y poco recorrido'),
('H AA 5589','Kia','Sportage','Negro',2017,'Camioneta','889900','554433',350000,'Espaciosa, cómoda y lista para viajar'),
('P BM 7741','Ford','Ranger','Plateado',2021,'Pick-up','112255','665544',620000,'Prácticamente nuevo, único dueño y poco millaje'),
('H CD 3040','Mazda','BT-50','Verde Olivo',2014,'Pick-up','445566','332211',280000,'Fuerte y resistente para carga pesada'),
('P AB 9080','Mitsubishi','L200','Rojo',2019,'Pick-up','998811','776655',510000,'Doble cabina con todos sus mantenimientos al día'),
('H BL 4412','Toyota','Corolla','Blanco',2010,'Turismo','556677','110022',145000,'Un carro nítido que no falla nunca'),
('P CH 1526','Nissan','Frontier','Gris',2016,'Pick-up','223344','887766',380000,'Potente, mecánico y listo para cualquier prueba'),
('H DF 6070','Jeep','Grand Cherokee','Negro',2013,'Camioneta','667788','443322',240000,'Lujo y mucha potencia en cada viaje')

select NumPlaca,Marca,Modelo,Color,Anio,TipoVehiculo,NumMotor,NumChasis,Kilometraje,Comentarios from FlotaVehiculos

delete from FlotaVehiculos where NumPlaca = 'P AB 9080'

update FlotaVehiculos set Kilometraje= '120000' where ID_Vehiculo = 10

--EJERCICIO 6
go
alter table UsuarioSistema
add comentarios varchar(200) null
select*from UsuarioSistema
go

--EJERCICIO 7
go
truncate table Estudiante
truncate table DatosClientes
truncate table UsuarioSistema
truncate table FlotaVehiculos
go

--EJERCICIO 8
go
drop table Estudiante
drop table DatosClientes
drop table UsuarioSistema
drop table FlotaVehiculos
go
