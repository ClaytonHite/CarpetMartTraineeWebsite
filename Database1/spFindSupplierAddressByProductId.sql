CREATE PROCEDURE [dbo].[spFindSupplierAddressByProductId]
	@ProductId int
AS
SELECT Address FROM [Suppliers]
INNER JOIN Products prod ON Suppliers.SupplierID = prod.SupplierID
WHERE prod.ProductID = @ProductId