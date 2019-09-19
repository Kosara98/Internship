create database furniture

create table product (
	id int identity(1,1) primary key,
	name nvarchar(35),
	description nvarchar(150),
	weight decimal(5,2),
	barcode numeric(13),
	price decimal(10,2)
)

create table client(
	id int identity(1,1) primary key,
	name nvarchar(30),
	address nvarchar(100),
	bulstat numeric(9),
	registered_vat tinyint,
	mol nvarchar(35)
)

create table sale(
	id int identity(1,1) primary key,
	sale_date date,
	product_id int not null references product(id),
	quantity int,
	client_id int not null references client(id),
	invoice int,
	price decimal(13,2)
)

insert into product(name, price)
values('Bed', 100.5)

insert into product(name, price)
values('Chair', 10)

insert into product(name, price)
values('Sofa', 78)

insert into product(name, price)
values('Table', 50)

insert into client(name, bulstat, mol)
values('Ivan OOD', 123456789,'Ivan Ivanov')

insert into client(name, bulstat, mol)
values('Petar OOD', 987654321,'Petar Dimov')

insert into client(name, bulstat, mol)
values('BRR OOD', 112233789,'Denislav Todorov')

insert into sale
values (convert(datetime, '18-09-2019',105), 2, 3, 1, 12345412, 27)

insert into sale
values (convert(datetime, '20-08-2019',105), 1, 2, 1, 48545412, 201)

insert into sale
values (convert(datetime, '15-05-2019',105), 4, 3, 2, 25254412, 200)

insert into sale
values (convert(datetime, '01-07-2019',105), 3, 1, 3, 65658412, 78)

select * from sale

/* search product by part of the name*/

select * from product
where name like '%ed'

/* search product and their price and buyer by bill*/

select pr.name as product_name, pr.price, cs.name as client_name
from product pr join (select c.name, s.product_id, s.invoice
						from client c join sale s
						on c.id = s.client_id) as cs
on pr.id = cs.product_id
where cs.invoice = 12345412

/* name of the company that bought something for the last month*/

select c.name as company_name
from client c join sale s
on c.id = s.client_id
where s.sale_date > '2019-08-18'

/* quantity of every product that is bought for the last one month*/

select pr.name as product_name, s.quantity 
from product pr join sale s
on pr.id = s.product_id
where s.sale_date > '2019-08-18'
