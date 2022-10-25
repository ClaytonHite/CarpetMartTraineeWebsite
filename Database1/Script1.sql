SELECT cm.CustomerName FROM Customers cm
INNER JOIN Orders ON Orders.CustomerID = cm.CustomerID
WHERE Orders.OrderID = 10310
ORDER BY CustomerName ASC;
