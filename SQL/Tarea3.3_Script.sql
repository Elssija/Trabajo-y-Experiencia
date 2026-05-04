--Creacion de la tabla Alumnos
create database Aguilera

use Aguilera

go
create table Alumno(
AlumnoID bigint not null identity(1,1),
Cuenta varchar(20) not null,
Nombre varchar(150) not null,
Carrera varchar(100) not null,
Email varchar(50) not null,
Observaciones varchar(255) not null,
primary key(AlumnoID)
)
go

insert Alumno(Cuenta,Nombre,Carrera,Email,Observaciones)
values('20232001430','Jairo Jassiel Aguilera Romero','Ingeniera en Sistemas Computacionales','jjaguilerar@unah.hn','Disciplinado'),
('20241002541','María Fernanda López Ruiz','Ingeniería en Sistemas Computacionales','mflopezr@unah.hn','Proactiva'),
('20222005678','Carlos Alberto Martínez Paz','Ingeniería Industrial','camartinezp@unah.hn','Analítico'),
('20251003210','Ana Lucía Gómez Santos','Ingeniería en Sistemas Computacionales','algomezs@unah.hn','Creativa'),
('20231008942','Ricardo José Fuentes Amaya','Ingeniería Civil','rjfuentesa@unah.hn','Organizado'),
('20242004563','Elena Sofía Mejía Castro','Ingeniería en Sistemas Computacionales','esmejiac@unah.hn','Enfocada'),
('20221007890','Pedro Antonio Vargas Soto','Ingeniería Eléctrica','pavargass@unah.hn','Responsable'),
('20252001123','Laura Isabel Ortega Méndez','Ingeniería en Sistemas Computacionales','liortegam@unah.hn','Colaboradora')