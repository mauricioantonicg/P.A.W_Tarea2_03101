create database BD_Tarea2_PAW_03101
go 

use BD_Tarea2_PAW_03101
go

create table pais(
idPais int primary key identity,
nombrePais varchar(45) not null
) 
go

insert into pais (nombrePais) values 
('Belice'), ('Costa rica'), ('El Salvador'), ('Guatemala'),
('Honduras'), ('Nicaragua'), ('Panamá')
go

create table rolPersona(
idRol int primary key identity,
nombreRol varchar(45) not null
) 
go

insert into rolPersona (nombreRol) values 
('Programador Front-end'), ('Programador Back-end'), ('Analista de sistemas'),
('Diseñador gráfico'), ('Administrador de proyectos de TI')
go

create table lenguajeProgramacion(
idLenguajeProgram int primary key identity,
nombreLenguajeProgram varchar(45) not null,
puntuacionLenguaje decimal (7,2) not null
) 
go

insert into lenguajeProgramacion (nombreLenguajeProgram, puntuacionLenguaje) values 
('Java', 0), ('C', 0), ('Python', 0), ('C++', 0), ('C#', 0), ('Visual Basic. NET', 0), ('SQL', 0), ('PHP', 0), ('Ruby', 0), ('R', 0), 
('Rust', 0), ('TypeScript', 0), ('Swift', 0), ('Perl', 0), ('Kotlin', 0), ('Go', 0), (' Scheme', 0), ('Erlang', 0), ('Pascal', 0), ('Postscript', 0)
go

create table persona(
idPersona int primary key identity,
nombrePersona varchar(45) not null,
apellido1 varchar(45) not null,
idPais int references pais(idPais) not null,
idRolPersona int references rolPersona(idRol) not null,
idLenguajeProgPrimario int references lenguajeProgramacion(idLenguajeProgram) not null,
idLenguajeProgSecundario int references lenguajeProgramacion(idLenguajeProgram) not null
)
go

create proc sp_AgregarEncuesta(
@nombrePersona varchar,
@apellido1 varchar,
@idPais int,
@idRolPersona int,
@idLenguajeProgPrimario int,
@idLenguajeProgSecundario int
)
as
begin
   insert into persona(nombrePersona, apellido1, idPais, idRolPersona, idLenguajeProgPrimario, idLenguajeProgSecundario) 
        values (@nombrePersona, @apellido1, @idPais, @idRolPersona, @idLenguajeProgPrimario, @idLenguajeProgSecundario)
end

create proc sp_PuntuarLenguaje(
@idLenguajeProgram int,
@puntuacionLenguaje decimal (7,2)
)
as
begin
   UPDATE lenguajeProgramacion SET puntuacionLenguaje = @puntuacionLenguaje WHERE idLenguajeProgram = @idLenguajeProgram
end





