CREATE PROCEDURE [dbo].[spFindCustomerNameByOrderID]
	@OrderId int
AS
SELECT cm.CustomerName FROM Customers cm
INNER JOIN Orders ON Orders.CustomerID = cm.CustomerID
WHERE Orders.OrderID = @OrderId
ORDER BY CustomerName ASC;
