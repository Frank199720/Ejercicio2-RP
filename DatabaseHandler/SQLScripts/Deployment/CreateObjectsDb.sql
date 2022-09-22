DROP TABLE IF EXISTS Product;

CREATE TABLE Product
( 
	id						int IDENTITY ( 1,1 ) ,
	nombre					varchar(120)  NOT NULL ,
	precio					decimal(9,2)  NOT NULL ,
	stock					int  NULL  default(0),
	fechaRegistro           datetime default(getdate())
)
go


ALTER TABLE Product
	ADD CONSTRAINT XPKProduct PRIMARY KEY  CLUSTERED (id ASC)
go