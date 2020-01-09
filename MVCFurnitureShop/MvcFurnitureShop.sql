create database MvcFurnitureShop

create table Clients(
	ClientId int identity(1,1) not null primary key,
	Name nvarchar(30) not null,
	Address nvarchar(100) not null,
	Bulstat varchar(9) not null unique,
	RegisteredVat bit not null,
	Mol nvarchar(35) not null,
	IsDeleted bit default(0)
)

create table Products (
	ProductId int identity(1,1) not null primary key,
	Name nvarchar(35) not null,
	Description nvarchar(150),
	Weight decimal(5,2) not null,
	Barcode varchar(13) not null unique,
	Price decimal(10,2) not null
)

insert into Products
values('Bed', null, 40, 1234567891234, 100.5)

insert into Products
values('Chair', null, 7, 1555557891234, 10)

insert into Products
values('Sofa', null, 30, 4545457891234, 78)

insert into Products
values('Table', null, 15, 1457897891234, 50)

insert into Products
values('Wardrobe', null, 60, 12345777234, 80)

select * from Clients

insert into Clients
values('Ivan OOD','bul. "Tsar Boris III Obedinitel" 128', 123456789, 1,'Ivan Ivanov',0)

insert into Clients
values('Petar OOD','bul. "Tsar Boris III Obedinitel" 12', 987654321, 0,'Petar Dimov',0)

insert into Clients
values('BRR OOD','bul. "Tsar Boris III Obedinitel" 31', 112233789, 1,'Denislav Todorov',0)

update Clients
set IsDeleted = 0
where IsDeleted = 1
