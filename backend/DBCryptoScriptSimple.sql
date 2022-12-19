--por las dudas tengan una base con el mismo nombre
Drop database BilleteraCrypto

CREATE database BilleteraCrypto
use BilleteraCrypto


CREATE Table Operaciones (
ID_Transferencia int identity(1,1) not null,
Monto_ars_transf decimal(10,2),
Monto_btc_trans decimal(10,6),
ID_Billetera int,
constraint pk_ID_Transferencia primary key (ID_Transferencia),
constraint fk_ID_Billetera foreign key (ID_Billetera)
references Billeteras(ID_Billetera))

CREATE Table Billeteras (
ID_Billetera int identity(1,1) not null,
CVU_Bille int not null,
Saldo_ars_bille decimal(10,2),
Saldo_btc_bille decimal(10,6),
Estado_bille bit,
ID_Usuario int,
constraint pk_ID_Billetera primary key (ID_Billetera),
constraint fk_ID_Usuario foreign key (ID_Usuario)
references Usuarios(ID_Usuario))

CREATE Table Usuarios (
ID_Usuario int identity(1,1) not null,
Nombre_usu varchar (50), 
Apellido_usu varchar (50), 
DNI_usu varchar(10) not null,
Fecha_Nac_usu Datetime,
Email_usu varchar (80) not null,
Password_usu varchar(50) not null,
FechaAlta_usu datetime,
FechaBaja_usu datetime,
constraint pk_ID_Usuario primary key (ID_Usuario))