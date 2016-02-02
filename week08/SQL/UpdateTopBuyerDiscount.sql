use HackCompany;

UPDATE Customer
SET Discount=Discount * 2
WHERE Customer.Id = (
SELECT TOP 1 o.CustomerId
FROM HackCompany.dbo.[Order] o
GROUP BY o.CustomerId
ORDER BY count(*) DESC)