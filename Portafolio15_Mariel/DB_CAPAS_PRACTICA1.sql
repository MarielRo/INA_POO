CREATE DATABASE CAPAS_PRACTICA1
GO

USE CAPAS_PRACTICA1
GO

--Drop DATABASE CAPAS_PRACTICA1;*/

CREATE TABLE CLIENTES(
	ID_CLIENTE int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	NOMBRE varchar(80) NOT NULL,
	TELEFONO varchar(11) NULL,
	DIRECCION varchar(80) NULL,
)

CREATE TABLE ENCABEZADO_FACTURA(
	ID_FACTURA int IDENTITY NOT NULL PRIMARY KEY, 
	FECHA datetime NOT NULL, 
	ID_CLIENTE INT NOT NULL FOREIGN KEY REFERENCES CLIENTES(ID_CLIENTE), 
	SUBTOTAL DECIMAL NOT NULL, 
	IMPUESTO DECIMAL NOT NULL, 
	MONTO_DESCUENTO DECIMAL
)

CREATE TABLE PRODUCTOS(
	ID_PRODUCTO int IDENTITY NOT NULL PRIMARY KEY, 
	DESCRIPCION varchar(40) NOT NULL, 
	PRECIO_COMPRA varchar(40) NOT NULL, 
	PRECIO_VENTA varchar(40) NOT NULL, 
	GRAVADO varchar(40) NOT NULL
)

CREATE TABLE DETALLE_FACTURA(
	ID_FACTURA INT not null FOREIGN KEY REFERENCES ENCABEZADO_FACTURA(ID_FACTURA), 
	ID_PRODUCTO INT not null FOREIGN KEY REFERENCES PRODUCTOS(ID_PRODUCTO),
	CANTIDAD int NOT NULL
)

select * from clientes;
select * from PRODUCTOS;