-- Obtener la lista de precios de todos los productos

SELECT Id, Name, SellingPrice FROM FelipEcommerceDB.dbo.Products;

--  Obtener la lista de productos cuya existencia en el inventario haya llegado al mínimo permitido (5 unidades)

SELECT p.Id, p.Name, p.SellingPrice FROM Products p 
INNER JOIN Inventory i ON i.ProductId = p.Id 
WHERE i.Qty >= 5;


-- Obtener una lista de clientes no mayores de 35 años que hayan realizado compras entre el 1 de febrero de 2000 y el 25 de mayo de 2000

SELECT c.FirstName, c.LastName, c.Phone  FROM Clients c
	INNER JOIN Invoices i ON i.ClientId = c.Id 
	INNER JOIN InvoiceDetail iD ON iD.InvoiceId = i.Id
	WHERE c.Age <= 35 AND i.InvoiceDate
	BETWEEN	CONVERT(DATETIME,'2000-02-01') and CONVERT(DATETIME, '2000-05-25')


-- Obtener el valor total vendido por cada producto en el año 2000
		
SELECT p.Name from Products p 

-- Obtener la última fecha de compra de un cliente y según su frecuencia de compra estimar en qué fecha podría volver a comprar.

SELECT p.Id, p.Name, p.SellingPrice FROM Products p 
	INNER JOIN Inventory i ON i.ProductId = p.Id 
	WHERE i.Qty >= 5;
	
