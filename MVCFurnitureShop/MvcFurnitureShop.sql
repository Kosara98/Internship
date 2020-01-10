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

create table Sales(
	SaleId int identity(1,1) not null primary key,
	SaleDate date not null,
	ClientName nvarchar(30) not null,
	Invoice varchar(10) not null
)

create table ProductSales(
	ProductName nvarchar(35) not null,
	SaleId int not null,
	Quantity int not null,
	Price decimal(10,2) not null,
	TotalPrice as ([Quantity] * [Price])
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

insert into Sales
values (convert(datetime, '18-09-2019',105), 'Ivan OOD', 12345412)

insert into Sales
values (convert(datetime, '20-08-2019',105), 'Ivan OOD', 48545412)

insert into Sales
values (convert(datetime, '15-05-2019',105), 'Petar OOD', 25254412)

insert into Sales
values (convert(datetime, '01-07-2019',105), 'BRR OOD', 65658412)

insert into Sales
values (convert(datetime, '5-09-2019',105), 'Petar OOD', 12333332)

insert into Sales
values (convert(datetime, '25-09-2019',105), 'BRR OOD', 12666332)

insert into ProductSales
values ('Bed', 3, 3, (select Price from Products where ProductId = 1))

insert into ProductSales
values ('Chair', 2, 3, (select Price from Products where ProductId = 2))

insert into ProductSales
values ('Bed', 5, 10, (select Price from Products where ProductId = 1))

insert into ProductSales
values ('Sofa', 6, 7, (select Price from Products where ProductId = 3))

insert into ProductSales
values ('Chair', 6, 4, (select Price from Products where ProductId = 2))

insert into ProductSales
values ('Chair', 5, 4, (select Price from Products where ProductId = 2))

delete from Sales
where Invoice = '12345412'