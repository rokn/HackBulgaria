use HackCompany;

DELETE FROM Product
WHERE Id NOT IN (SELECT [ProductId] FROM OrderProducts);