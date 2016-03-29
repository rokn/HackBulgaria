SELECT	FirstName,
		LastName,
		[address].City
FROM Person.Person p
INNER JOIN Person.BusinessEntityAddress entity
ON p.BusinessEntityID = entity.BusinessEntityID 
INNER JOIN Person.[Address] [address]
ON entity.AddressID = [address].AddressId
WHERE [address].City != 'Payson'