/*The order numbers and the names of products made on 1.10.2011*/

select distinct sh.SalesOrderNumber, sh.OrderDate, p.Name
from SalesLT.SalesOrderHeader sh
join SalesLT.SalesOrderDetail sd on sh.SalesOrderId = sd.SalesOrderID
join SalesLT.Product p on sd.ProductID = p.ProductID
where OrderDate = '20111001'

/*The order numbers and the quantity of products made on 1.10.2011*/

select distinct sh.SalesOrderNumber, count(sd.SalesOrderId)
from SalesLT.SalesOrderHeader sh
join SalesLT.SalesOrderDetail sd on sh.SalesOrderId = sd.SalesOrderID
join SalesLT.Product p on sd.ProductID = p.ProductID
where OrderDate = '20111001'
group by sh.SalesOrderNumber


/*Order numbers made on 1.10.2011 with quantity of products between 3 and 9*/

select distinct sh.SalesOrderNumber, count(sd.SalesOrderId)
from SalesLT.SalesOrderHeader sh
join SalesLT.SalesOrderDetail sd on sh.SalesOrderId = sd.SalesOrderID
join SalesLT.Product p on sd.ProductID = p.ProductID
where OrderDate = '20111001'
group by sh.SalesOrderNumber
having count(sd.SalesOrderId) between 3 and 9

/*Order number and the next one*/

select SalesOrderNumber, concat('SO', SalesOrderID + 1) as NextSalesOrderNumber
from SalesLT.SalesOrderHeader
where SalesOrderNumber = 'SO71946'

/*The names of clients made purchase before 30.09.2012 and after 30.06.2013*/

select concat(c.FirstName,' ', c.LastName) as Name, sh.OrderDate
from SalesLT.Customer c 
join SalesLT.SalesOrderHeader sh on sh.CustomerID = c.CustomerID
where sh.OrderDate < '20120930' or sh.OrderDate > '20130630'

/*List of order number and the order number before and after with the dates of Jeffrey Kurtz*/

select sh.SalesOrderNumber, sh.OrderDate, 
lead(SalesOrderNumber, 1) over(order by SalesOrderNumber) as NextOrderNumber,
lead(OrderDate, 1) over(order by SalesOrderNumber) as NextOrderDate,
lag(SalesOrderNumber, 1) over(order by SalesOrderNumber) as PreviousOrderNumber,
lag(OrderDate, 1) over(order by SalesOrderNumber) as PreviousOrderDate
from SalesLT.Customer c 
join SalesLT.SalesOrderHeader sh on sh.CustomerID = c.CustomerID
where c.FirstName = 'Jeffrey' and c.LastName = 'Kurtz'

