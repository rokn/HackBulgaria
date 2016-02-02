use HackCompany;

SELECT TOP 1 o.Id,
		o.CustomerId,
		o.TotalPrice
FROM OrderProducts op
JOIN [Order] o
ON op.OrderId = o.Id
GROUP BY o.Id,o.CustomerId,o.TotalPrice
ORDER BY count(o.Id) DESC;