--por las dudas tengan una base con el mismo nombre
Drop database BilleteraCrypto

CREATE database BilleteraCrypto
use BilleteraCrypto

CREATE Table Provincias (
ID_Provincia int identity(1,1) not null, 
Nom_Provincia varchar (50),
constraint pk_ID_Provincia primary key (ID_Provincia))

CREATE Table Localidades (
ID_Localidad int identity(1,1) not null,
Nom_localidad varchar (50),
ID_provincia int,
constraint pk_ID_Localidad primary key (ID_Localidad),
constraint fk_ID_Provincia foreign key (ID_Provincia)
references provincias(id_provincia))

CREATE Table Usuarios (
ID_Usuario int identity(1,1) not null,
Nombre_usu varchar (50), 
Apellido_usu varchar (50), 
DNI bigint not null,
Fecha_Nac_usu Datetime,
Email_usu varchar (80) not null,
usuario varchar(50) not null,
Contraseña varchar(50) not null,
telefono varchar(50),
FechaAlta_usu datetime, 
FechaBaja_usu datetime,
ID_Localidad int,
constraint pk_ID_Usuario primary key (ID_Usuario), 
constraint fk_ID_Localidad foreign key (ID_Localidad)
references localidades(id_localidad))

CREATE Table Monedas (
ID_Moneda int identity(1,1)not null,
Nombre_mon varchar (50),
constraint pk_ID_Moneda primary key (ID_Moneda))



CREATE Table Usuarios_Monedas (
ID_Usuario_Moneda int identity(1,1)not null,
ID_Moneda int,
ID_Usuario int,
constraint pk_ID_Usuario_Moneda primary key (ID_Usuario_Moneda),
constraint fk_ID_Moneda foreign key (ID_Moneda)
references monedas(id_moneda),
constraint fk_ID_Usuario foreign key (ID_Usuario)
references usuarios(id_usuario))

CREATE Table Estados (
ID_Estado int identity(1,1) not null,
Nombre_est varchar(50),
constraint pk_ID_Estado primary key (ID_Estado))


CREATE Table Billeteras (
ID_Billetera int identity(1,1) not null,
CVU_Bille int,
ID_Usuario int,
ID_Estado int,
constraint pk_ID_Billetera primary key (ID_Billetera),
constraint fk_billetera_ID_Usuario foreign key (ID_Usuario)
references usuarios(id_usuario),
constraint fk_ID_Estado foreign key (ID_Estado)
references estados(id_estado))

CREATE TABLE Tipo_Transferencias(
ID_tipo_transferencia int identity (1,1) not null,
Nom_trasferencia varchar(100)
constraint pk_id_tipo_transferencia primary key (ID_tipo_transferencia)
)

CREATE Table Transferencias (
ID_Transferencia int identity(1,1) not null,
Monto_transf float, 
CVU_Origen_transf int,
CVU_Destino_transf int,
ID_Billetera int,
ID_tipo_transferencia int,
constraint pk_ID_Transferencia primary key (ID_Transferencia),
constraint fk_ID_Billetera foreign key (ID_Billetera)
references billeteras(id_billetera),
constraint fk_id_tipo_transferencia foreign key (id_tipo_transferencia)
references tipo_transferencias(id_tipo_transferencia)
)

select * from Usuarios


create view VistaUsuarios
as
select u.Nombre_usu'Nombre',u.Apellido_usu'Apellido' ,u.dni'DNI',lo.Nom_localidad 'Localidad',pro.Nom_Provincia'Provincia',u.Fecha_Nac_usu'Fecha de nacimiento',u.Email_usu'Email',u.telefono'Telefono'
from Usuarios u 
join Localidades lo on lo.ID_Localidad=u.ID_Localidad
join Provincias pro on pro.ID_Provincia=lo.ID_provincia

select * from VistaUsuarios

create procedure ObtenerUsuarios
@dni bigint = null,
@apellido varchar(50)=null
as
select Nombre,Apellido,DNI,Localidad
from VistaUsuarios
where(@dni is null or dni=@dni) or
@apellido is null or apellido like '%'+@apellido+'%'

exec ObtenerUsuarios


create procedure EliminarUsuarios
@id_usuario int
as
update Usuarios SET FechaBaja_usu=GETDATE()
where ID_Usuario=@id_usuario

exec EliminarUsuarios


create procedure AgregarLocalidad
@nombre varchar(50),
@id_provincia int
as
insert into Localidades(Nom_localidad,ID_provincia)
             values (@nombre,@id_provincia)


create procedure ModificarLocalidad
@id_localidad int,
@nombre varchar(50),
@id_provincia int
as
update Localidades
set Nom_localidad=@nombre,
    ID_provincia=@id_provincia
where ID_Localidad=@id_localidad

insert into Provincias (Nom_Provincia)
             values ('Buenos aires'),
					('Corrientes'),
					('Santa Cruz'),
					('Tierra del Fuego'),
					('Entre Rios'),
					('Salta')
select * from Provincias


insert into Localidades (Nom_localidad,ID_provincia)
             values ('Capital Federal',1),
					('La plata',1),
					('Otra localidad de BSAS',1),
					('Corrientes',2),
					('Santo Tome',2),
					('Otra localidad de Corrientes',2),
					('Caleta Olivia',3),
					('Puerto Deseado',3),
					('Otra localidad de Santa Cruz',3),
					('Ushuaia',4),
					('Rio grande',4),
					('Otra localidad de Tierra del fuego',4),
					('Parana',5),
					('Concordia',5),
					('Otra localidad de Entre rios',5),
					('Salta',6),
					('Tartagal',6),
					('Otra localidad de Salta',6)

set dateformat dmy
Insert into Usuarios (Nombre_usu,Apellido_usu,DNI,Fecha_Nac_usu,Email_usu,usuario,Contraseña,telefono,FechaAlta_usu,ID_Localidad) 
values('Ronnie James', 'Dio', 05415577,'10/07/1942','RonnieJames@gmail.com','Ronnie','123456',3516789456,'13/12/2022',1),
('Bruce','Dickinson',06456789,'07/08/1958','BruceDickinson@gmail.com','Brucie','456789',3518147258,'13/12/2022',1),
('Steve','Harris',05789456,'12/03/1956','SteveHarris@gmail.com','Steve','789456',3517123456,'13/12/2022',1)

INSERT INTO Usuarios(Nombre_usu, Apellido_usu, DNI, Fecha_Nac_usu, Email_usu, usuario, Contraseña, telefono, ID_Localidad)
					VALUES('Nicolas', 'Farias', 111111, '01/01/1991', 'nfarias@gmail.com', 'nfarias','1234', '111111', 1)

INSERT INTO Usuarios(Nombre_usu, Apellido_usu, DNI, Fecha_Nac_usu, Email_usu, usuario, Contraseña, telefono, ID_Localidad)
					VALUES('Nicolas', 'Farias', 111111, '01/01/1991', 'nfarias@gmail.com', 'nfarias','1234', '111111', 1)

Insert into Billeteras(CVU_Bille,ID_Usuario,ID_Estado)
values(1212,6,1),(5565,7,1),(9696,8,1)

Insert into Billeteras(CVU_Bille,ID_Usuario,ID_Estado)
values (2525,6,1),(2628,7,1)

Insert into Estados(Nombre_est)
values('Habilitado'),('Deshabilitado')

insert into Monedas (Nombre_mon)
values('Bitcoin'),('Pesos')

insert into Tipo_Transferencias(Nom_trasferencia)
values ('Deposito'),('Retiro')

insert into Transferencias(Monto_transf,CVU_Destino_transf,CVU_Origen_transf,ID_Billetera,ID_tipo_transferencia)
values(1000,'12345','12346',4,1)

insert into Usuarios_Monedas(ID_Moneda,ID_Usuario)
Values(1,6)