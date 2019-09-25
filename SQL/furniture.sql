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
	Bulstat varchar(9) not null unique,
	RegisteredVat bit not null,
	Mol nvarchar(35) not null
)

create table Sales(
	Id int identity(1,1) not null primary key,
	SaleDate date not null,
	Quantity int not null,
	ClientId int not null references Clients(Id),
	Invoice varchar(10) not null unique,
	Price decimal(18,2) not null
)

create table ProductSales(
	ProductId int not null references Products(Id),
	SaleId int not null references Sales(Id),
	primary key(ProductId, SaleId)
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
values (convert(datetime, '18-09-2019',105), 3, 1, 12345412, 27)

insert into Sales
values (convert(datetime, '20-08-2019',105), 2, 1, 48545412, 201)

insert into Sales
values (convert(datetime, '15-05-2019',105), 3, 2, 25254412, 200)

insert into Sales
values (convert(datetime, '01-07-2019',105), 1, 3, 65658412, 78)

insert into ProductSales
values (1,1)

insert into ProductSales
values (2,1)

insert into ProductSales
values (1,3)

insert into ProductSales
values (3,2)

insert into ProductSales
values (2,2)

/* search product by part of the name*/

select * from Products
where Name like '%ed'

/* search product and their price and buyer by bill*/
		
select pr.Name, pr.Price, c.Name
from ProductSales ps  join Sales s on s.Id = ps.SaleId
					  join Products pr on pr.Id = ps.ProductId
					  join Clients c on c.Id = s.ClientId
where s.Invoice = 48545412
/* name of the company that bought something for the last month*/

select c.Name as CompanyName
from Clients c join Sales s
on c.Id = s.ClientId
where s.SaleDate > '2019-08-18'

/* quantity of every product that is bought for the last one month*/

select s.Quantity, pr.Name
from ProductSales ps join Sales s on s.Id = ps.SaleId
					join Products pr on pr.Id = ps.ProductId
where s.SaleDate > '2019-08-18'