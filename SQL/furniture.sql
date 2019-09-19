create database Furniture

create table Products (
	Id int identity(1,1) not null primary key,
	Name nvarchar(35) not null,
	Description nvarchar(150),
	Weight decimal(5,2) not null,
	Barcode varchar(13) not null,
	Price decimal(10,2) not null
)

create table Clients(
	Id int identity(1,1) not null primary key,
	Name nvarchar(30) not null,
	Address nvarchar(100) not null,
	Bulstat varchar(9) not null,
	RegisteredVat bit not null,
	Mol nvarchar(35) not null
)

create table Sales(
	Id int identity(1,1) not null primary key,
	SaleDate date not null,
	ProductId int not null references Products(Id),
	Quantity int not null,
	ClientId int not null references Clients(Id),
	Invoice varchar(10) not null,
	Price decimal(18,2) not null
)

insert into Products
values('Bed', null, 40, 1234567891234, 100.5)

insert into Products
values('Chair', null, 7, 1555557891234, 10)

insert into Products
values('Sofa', null, 30, 4545457891234, 78)

insert into Products
values('Table', null, 15, 1457897891234, 50)

insert into Clients
values('Ivan OOD','bul. "Tsar Boris III Obedinitel" 128', 123456789, 1,'Ivan Ivanov')

insert into Clients
values('Petar OOD','bul. "Tsar Boris III Obedinitel" 12', 987654321, 0,'Petar Dimov')

insert into Clients
values('BRR OOD','bul. "Tsar Boris III Obedinitel" 31', 112233789, 1,'Denislav Todorov')

insert into Sales
values (convert(datetime, '18-09-2019',105), 2, 3, 1, 12345412, 27)

insert into Sales
values (convert(datetime, '20-08-2019',105), 1, 2, 1, 48545412, 201)

insert into Sales
values (convert(datetime, '15-05-2019',105), 4, 3, 2, 25254412, 200)

insert into Sales
values (convert(datetime, '01-07-2019',105), 3, 1, 3, 65658412, 78)

/* search product by part of the name*/

select * from Products
where Name like '%ed'

/* search product and their price and buyer by bill*/

select pr.Name as ProductName, pr.Price, cs.Name as ClientName
from Products pr join (select c.Name, s.ProductId, s.Invoice
						from Clients c join Sales s
						on c.Id = s.ClientId) as cs
on pr.Id = cs.ProductId
where cs.Invoice = 12345412

/* name of the company that bought something for the last month*/

select c.Name as CompanyName
from Clients c join Sales s
on c.Id = s.ClientId
where s.SaleDate > '2019-08-18'

/* quantity of every product that is bought for the last one month*/

select pr.Name as ProductName, s.Quantity 
from Products pr join Sales s
on pr.Id = s.ProductId
where s.SaleDate > '2019-08-18'
