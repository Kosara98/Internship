create database Furniture

create table Products (
	Id int identity(1,1) primary key,
	Name nvarchar(35),
	Description nvarchar(150),
	Weight decimal(5,2),
	Barcode varchar(13),
	Price decimal(10,2)
)

create table Clients(
	Id int identity(1,1) primary key,
	Name nvarchar(30),
	Address nvarchar(100),
	Bulstat varchar(9),
	RegisteredVat bit,
	Mol nvarchar(35)
)

create table Sales(
	Id int identity(1,1) primary key,
	SaleDate date,
	ProductId int not null references Products(Id),
	Quantity int,
	ClientId int not null references Clients(Id),
	Invoice varchar(10),
	Price decimal(18,2)
)

insert into Products(Name, Price)
values('Bed', 100.5)

insert into Products(Name, Price)
values('Chair', 10)

insert into Products(Name, Price)
values('Sofa', 78)

insert into Products(Name, Price)
values('Table', 50)

insert into Clients(Name, Bulstat, Mol)
values('Ivan OOD', 123456789,'Ivan Ivanov')

insert into Clients(Name, Bulstat, Mol)
values('Petar OOD', 987654321,'Petar Dimov')

insert into Clients(Name, Bulstat, Mol)
values('BRR OOD', 112233789,'Denislav Todorov')

insert into Sales
values (convert(datetime, '18-09-2019',105), 2, 3, 1, 12345412, 27)

insert into Sales
values (convert(datetime, '20-08-2019',105), 1, 2, 1, 48545412, 201)

insert into Sales
values (convert(datetime, '15-05-2019',105), 4, 3, 2, 25254412, 200)

insert into Sales
values (convert(datetime, '01-07-2019',105), 3, 1, 3, 65658412, 78)

select * from Sales

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
