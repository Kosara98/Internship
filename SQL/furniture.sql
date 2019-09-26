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
	ClientId int not null references Clients(Id),
	Invoice varchar(10) not null unique,
)

create table ProductSales(
	ProductId int not null references Products(Id),
	SaleId int not null references Sales(Id),
	Quantity int not null,
	Price decimal(10,2) not null,
	TotalPrice as ([Quantity] * [Price]),
	primary key(ProductId, SaleId)
)

insert into ProductSales
values (4, 3, 3, (select price from Products where Id = 4))

insert into ProductSales
values (4, 2, 3, (select price from Products where Id = 4))

insert into ProductSales
values (1, 3, 3, (select price from Products where Id = 1))

insert into ProductSales
values (2, 2, 3, (select price from Products where Id = 2))

insert into ProductSales
values (1, 5, 10, (select price from Products where Id = 1))

insert into ProductSales
values (3, 6, 7, (select price from Products where Id = 3))

insert into ProductSales
values (2, 6, 4, (select price from Products where Id = 2))

insert into ProductSales
values (2, 5, 4, (select price from Products where Id = 2))

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

insert into Clients
values('Ivan OOD','bul. "Tsar Boris III Obedinitel" 128', 123456789, 1,'Ivan Ivanov')

insert into Clients
values('Petar OOD','bul. "Tsar Boris III Obedinitel" 12', 987654321, 0,'Petar Dimov')

insert into Clients
values('BRR OOD','bul. "Tsar Boris III Obedinitel" 31', 112233789, 1,'Denislav Todorov')

insert into Sales
values (convert(datetime, '18-09-2019',105), 1, 12345412)

insert into Sales
values (convert(datetime, '20-08-2019',105), 1, 48545412)

insert into Sales
values (convert(datetime, '15-05-2019',105), 2, 25254412)

insert into Sales
values (convert(datetime, '01-07-2019',105), 3, 65658412)

insert into Sales
values (convert(datetime, '5-09-2019',105), 2, 12333332)

insert into Sales
values (convert(datetime, '25-09-2019',105), 3, 12666332)

/* search product by part of the name*/

select * from Products
where Name like '%ed'

/* search product and their price and buyer by bill*/
		
select pr.Name, pr.Price, c.Name
from ProductSales ps  
join Sales s on s.Id = ps.SaleId
join Products pr on pr.Id = ps.ProductId
join Clients c on c.Id = s.ClientId
where s.Invoice = '48545412'

/* name of the company that bought something for the last month*/

select distinct c.Name as CompanyName
from Clients c join Sales s
on c.Id = s.ClientId
where s.SaleDate > dateadd(month, -1, getdate())

/* quantity of every product that is bought for the last one month*/

select  sum(ps.Quantity), pr.Name
from Products pr
left join ProductSales ps  on pr.Id = ps.ProductId
left join Sales s on (s.Id = ps.SaleId)
and s.SaleDate > dateadd(month, -1, getdate())
--where s.SaleDate > dateadd(month, -1, getdate()) 
group by pr.Id, pr.Name

select pr.Name
from Products pr
left join ProductSales ps  on pr.Id = ps.ProductId
left join Sales s on s.Id = ps.SaleId
--where  s.SaleDate > dateadd(month, -1, getdate())
group by pr.Id, pr.Name
having s.SaleDate >dateadd(month, -1, getdate())

